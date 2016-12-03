using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using GoManPTCAccountCreator.Model;

namespace GoManPTCAccountCreator.Controller
{
    public partial class Account
    {
        private class Actions
        {
            private static readonly Func<Model, HttpClient, Task<MethodResult>> GetCsrfAction = async (model, client) => await Tasks.GetCsrfTask(model, client);
            private static readonly Func<Model, HttpClient, Task<MethodResult>> AgeVerifyAction = async (model, client) => await Tasks.AgeVerifyTask(model, client);
            private static readonly Func<Model, Task<MethodResult>> StartSolveCaptchaAction = async (model) => await Tasks.StartSolveCaptchaTask(model);
            private static readonly Func<Model, Task<MethodResult>> GetSolvedCaptchaAction = async (model) => await Tasks.GetSolvedCaptchaTask(model);
            private static readonly Func<Model, HttpClient, Task<MethodResult>> ProfileSettingsAction = async (model, client) => await Tasks.ProfileSettingsTask(model, client);

            private static readonly Func<Model, HttpClient, Task<MethodResult>> VerifyAction = async (model, client) => await Tasks.VerifyTask(model, client);

            private static readonly Func<Model, HttpClient, Task<MethodResult>> SetLoginVariablesAction = async (model, client) => await Tasks.SetLoginVariablesTask(model, client);
            private static readonly Func<Model, HttpClient, Task<MethodResult>> LoginAction = async (model, client) => await Tasks.LoginTask(model, client);
            private static readonly Func<Model, HttpClient, Task<MethodResult>> SubmitTosAction = async (model, client) => await Tasks.SubmitTosTask(model, client);

            private static readonly object LockObj = new object();

            internal static async void Verify(Model account)
            {
                Interlocked.Increment(ref QueueCounter);
                account.Status = AccountModel.StatusType.Running;

                OnEventRefreshAccount(account);

                using (var client = new HttpClient())
                {
                    var csrfRetryResults = await RetryAction(GetCsrfAction, "GetCsrfAction", account, client, 5);
                    if (csrfRetryResults.Success)
                    {
                        await RetryAction(VerifyAction, "VerifyAction", account, client, 5);
                    }
                }

                account.Status = AccountModel.StatusType.Created;
                Interlocked.Decrement(ref QueueCounter);
                account.CleanUp();
                OnEventRefreshAccount(account);
            }
            internal static async void SignUp(Model account)
            {

                if (_streamWriter == null) lock (LockObj)
                {
                    _streamWriter = new StreamWriter("Export.txt", true);
                }

                Interlocked.Increment(ref QueueCounter);
                account.Status = AccountModel.StatusType.Running;

                OnEventRefreshAccount(account);
                var signUpRetryResults = await SignUp1(account);

                if (signUpRetryResults.Success)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var setLoginVariablesRetryResults =
                            await RetryAction(SetLoginVariablesAction, "SetLoginVariablesAction", account, client, 15);
                        if (setLoginVariablesRetryResults.Success)
                        {
                            var loginRetryResults = await RetryAction(LoginAction, "LoginAction", account, client, 15);
                            if (loginRetryResults.Success)
                            {
                                var submitTosRetryResults = await RetryAction(SubmitTosAction, "SubmitTosAction", account, client, 15);

                                account.TosAccepted = submitTosRetryResults.Success.ToString();
                            }
                        }
                    }
                }

                Interlocked.Decrement(ref QueueCounter);
                account.CleanUp();
                OnEventRefreshAccount(account);

                if (signUpRetryResults.Success)
                {
                    account.Status = AccountModel.StatusType.Created;
                    lock (LockObj)
                    {
                        _streamWriter.WriteLine(account.Username + ":" + account.Password);
                        _streamWriter.Flush();
                    }
                }
                else
                    account.Status = AccountModel.StatusType.Failed;


                if (QueueCounter != 0) return;
                lock (LockObj)
                {
                    _streamWriter.Close();
                    _streamWriter = null;
                }
                

            }
            private static void OnEventRefreshAccount(AccountModel account)
            {
                EventRefreshAccount?.Invoke(account);
            }

            private static async Task<MethodResult> SignUp1(Account.Model account)
            {
                MethodResult methodResult = new MethodResult();
                try
                {
                    using (var client = new HttpClient())
                    {
                        var csrfRetryResults = await RetryAction(GetCsrfAction, "GetCsrfAction", account, client, 5);
                        if (csrfRetryResults.Success)
                        {
                            var verifyAgeRetryResults = await RetryAction(AgeVerifyAction, "AgeVerifyAction", account, client, 5);
                            if (verifyAgeRetryResults.Success)
                            {
                                var startSolveCaptchaRetryResults =
                                    await RetryCaptchaAction(StartSolveCaptchaAction, "StartSolveCaptchaAction", account, 5);
                                if (startSolveCaptchaRetryResults.Success)
                                {
                                    var getSolvedCaptchaRetryResults =
                                        await RetryCaptchaAction(GetSolvedCaptchaAction, "GetSolvedCaptchaAction", account, 15);
                                    if (getSolvedCaptchaRetryResults.Success)
                                    {
                                        var profileSettingsRetryResults =
                                            await
                                                RetryAction(ProfileSettingsAction, "ProfileSettingsAction", account, client, 5);

                                        methodResult.Success = profileSettingsRetryResults.Success;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    methodResult.Error = ex;
                    methodResult.Success = false;
                }

                return methodResult;
            }

            private static async Task<MethodResult> RetryCaptchaAction(Func<Model, Task<MethodResult>> action, string actionName, Account.Model account, int tryCount)
            {
                int tries = 1;
                MethodResult methodResult = new MethodResult();
                account.AddLog(LoggerTypes.Debug, $"Starting {actionName}");

                while (tries < tryCount)
                {
                    methodResult = await action(account);

                    var tryMsg = " Try #" + tries;

                    if (methodResult.Success)
                    {
                        account.AddLog(LoggerTypes.Success, actionName + tryMsg);
                    }
                    else
                    {
                        tries++;
                        account.AddLog(LoggerTypes.Exception, actionName + tryMsg, "", methodResult.Error);

                    }

                    OnEventRefreshAccount(account);

                    if (account.EventLog.Count > 30)
                        account.EventLog.RemoveAt(0);


                    bool noneRecoverableError = methodResult.Error != null && (methodResult.Error.Message.Equals("ERROR_KEY_DOES_NOT_EXIST") ||
                                                methodResult.Error.Message.Equals("ERROR_ZERO_BALANCE"));

                    if (noneRecoverableError) break;
                    if (methodResult.Success) break;
                }

                return methodResult;
            }

            private static async Task<MethodResult> RetryAction(Func<Model, HttpClient, Task<MethodResult>> action , string actionName, Account.Model account, HttpClient client, int tryCount)
            {
                int tries = 1;
                MethodResult methodResult = new MethodResult();
                account.AddLog(LoggerTypes.Debug, $"Starting {actionName}");

                while (tries < tryCount)
                {
                    methodResult = await action(account, client);

                    var tryMsg = " Try #" + tries;

                    if (methodResult.Success)
                    {
                        account.AddLog(LoggerTypes.Success, actionName + tryMsg);
                    }
                    else
                    {
                        tries++;
                        account.AddLog(LoggerTypes.Exception, actionName + tryMsg, "", methodResult.Error);

                    }

                    OnEventRefreshAccount(account);

                    if (account.EventLog.Count > 30)
                        account.EventLog.RemoveAt(0);

                    if (methodResult.Error != null && methodResult.Error.Message.Equals("Account Already Exists")) break;
                    if (methodResult.Success) break;
                }

                return methodResult;
            }
        }
    }
}
