using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GoManPTCAccountCreator.Model;

namespace GoManPTCAccountCreator.Controller
{
    public partial class Account
    {
        private static class Tasks
        {
            private const string AgeVerifyUrl = "https://club.pokemon.com/us/pokemon-trainer-club/sign-up/";
            private const string SignUpUrl = "https://club.pokemon.com/us/pokemon-trainer-club/parents/sign-up";
            private const string GoSettings = "https://club.pokemon.com/us/pokemon-trainer-club/go-settings";
            private const string Activated = "https://club.pokemon.com/us/pokemon-trainer-club/activated";
            private const string CaptchaIn = "http://2captcha.com/in.php?";
            private const string CaptchaOut = "http://2captcha.com/res.php?";
            private const string RecaptchaSiteKey = "6LdpuiYTAAAAAL6y9JNUZzJ7cF3F8MQGGKko1bCy";

            private static readonly Regex RegexCsrf =
                new Regex("<input type='hidden' name='csrfmiddlewaretoken' value='(\\w+)' />");

            private static readonly Regex RegexLt =
                new Regex("<input type=\\\"hidden\\\" name=\\\"lt\\\" value=\\\"([A-Za-z0-9-]+)\\\" />");

            private static readonly Regex RegexExecution =
                new Regex("<input type=\\\"hidden\\\" name=\\\"execution\\\" value=\\\"(\\w+)\\\" />");

            private static readonly Regex RegexEventId =
                new Regex("<input type=\\\"hidden\\\" name=\\\"_eventId\\\" value=\\\"(\\w+)\\\" />");

            internal static async Task<MethodResult> GetCsrfTask(Model account, HttpClient client)
            {
                var methodResult = new MethodResult();
                try
                {
                    using (var httpResponseMessage = await client.GetAsync(AgeVerifyUrl))
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            var result = await httpResponseMessage.Content.ReadAsStringAsync();
                            methodResult.Value = result;
                            var match = RegexCsrf.Match(result);
                            if (match.Success)
                                account.Csrf = match.Groups[1].Value;

                            methodResult.Success = !string.IsNullOrEmpty(account.Csrf);
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

            internal static async Task<MethodResult> AgeVerifyTask(Model account, HttpClient client)
            {
                var methodResult = new MethodResult();
                try
                {
                    var keyValuePairArray = new KeyValuePair<string, string>[4]
                    {
                        new KeyValuePair<string, string>("csrfmiddlewaretoken", account.Csrf),
                        new KeyValuePair<string, string>("dob", account.DateOfBirth),
                        new KeyValuePair<string, string>("country", account.Country),
                        new KeyValuePair<string, string>("country", account.Country)
                    };
                    var urlEncodedContent = new FormUrlEncodedContent(keyValuePairArray);

                    if (!client.DefaultRequestHeaders.Contains("Referer"))
                        client.DefaultRequestHeaders.Add("Referer", AgeVerifyUrl);

                    using (
                        var responseMessage = await client.PostAsync(AgeVerifyUrl, urlEncodedContent))
                    {
                        methodResult.Success = responseMessage.IsSuccessStatusCode;
                        var results = await responseMessage.Content.ReadAsStringAsync();
                        methodResult.Value = results;
                    }
                }
                catch (Exception ex)
                {
                    methodResult.Error = ex;
                    methodResult.Success = false;
                }

                return methodResult;
            }

            internal static async Task<MethodResult> StartSolveCaptchaTask(Model account)
            {
                var methodResult = new MethodResult();
                var postData =
                    $"key={CaptchaKey}&method=userrecaptcha&googlekey={RecaptchaSiteKey}&proxy={ApplicationModel.Settings().ProxyDomain}:{ApplicationModel.Settings().ProxyPort}&proxytype=SOCKS4&pageurl={SignUpUrl}";
                try
                {
                    string result = await SendRecaptchav2RequestTask(CaptchaIn, postData);
                    methodResult.Value = result;
                    if (result.Contains("OK|"))
                    {
                        account.CaptchaId = result.Substring(3, result.Length - 3);
                        methodResult.Success = true;
                    }
                    else
                    {
                        methodResult.Error = new Exception(result);
                        methodResult.Success = false;
                    }
                }
                catch (Exception ex)
                {
                    methodResult.Error = ex;
                    methodResult.Success = false;
                }

                return methodResult;
            }

            internal static async Task<MethodResult> GetSolvedCaptchaTask(Model account)
            {
                var methodResult = new MethodResult();
                var postData = $"key={CaptchaKey}&action=get&id={account.CaptchaId}";

                try
                {
                    string result = await SendRecaptchav2RequestTask(CaptchaOut, postData);
                    while (result.Contains("CAPCHA_NOT_READY"))
                    {
                        await Task.Delay(3000);
                        result = await SendRecaptchav2RequestTask(CaptchaOut, postData);
                    }

                    methodResult.Value = result;
                    if (result.Contains("OK|"))
                    {
                        account.CaptchaResponse = result.Substring(3, result.Length - 3);
                        methodResult.Success = true;
                    }
                    else
                    {
                        methodResult.Error = new Exception(result);
                        methodResult.Success = false;
                    }
                }
                catch (Exception ex)
                {
                    methodResult.Error = ex;
                    methodResult.Success = false;
                }

                return methodResult;
            }

            internal static async Task<MethodResult> ProfileSettingsTask(Model account, HttpClient client)
            {
                var methodResult = new MethodResult();
                try
                {
                    var keyValuePairArray = new[]
                    {
                        new KeyValuePair<string, string>("csrfmiddlewaretoken", account.Csrf),
                        new KeyValuePair<string, string>("username", account.Username),
                        new KeyValuePair<string, string>("password", account.Password),
                        new KeyValuePair<string, string>("confirm_password", account.Password),
                        new KeyValuePair<string, string>("email", account.Email),
                        new KeyValuePair<string, string>("confirm_email", account.Email),
                        new KeyValuePair<string, string>("public_profile_opt_in", account.PublicProfileOptIn.ToString()),
                        new KeyValuePair<string, string>("screen_name", account.ScreenName),
                        new KeyValuePair<string, string>("terms", "on"),
                        new KeyValuePair<string, string>("g-recaptcha-response", account.CaptchaResponse)
                    };
                    using (
                        var httpResponseMessage =
                            await client.PostAsync(SignUpUrl, new FormUrlEncodedContent(keyValuePairArray)))

                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            if (httpResponseMessage.RequestMessage.RequestUri.ToString().Contains("exists"))
                            {
                                methodResult.Error = new Exception("Account Already Exists");
                                methodResult.Success = false;
                            }
                            else if (httpResponseMessage.RequestMessage.RequestUri.ToString().Contains("email"))
                            {
                                methodResult.Success = true;
                            }
                            else
                            {
                                methodResult.Error = new Exception("Unknown Error");
                                methodResult.Success = false;
                            }

                            var result = await httpResponseMessage.Content.ReadAsStringAsync();
                            methodResult.Value = result;
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

            internal static async Task<MethodResult> SetLoginVariablesTask(Model account,
                HttpClient client)
            {
                var methodResult = new MethodResult();
                try
                {
                    using (var httpResponseMessage = await client.GetAsync(GoSettings))
                    {
                        if (!httpResponseMessage.IsSuccessStatusCode)
                            return null;
                        var result = await httpResponseMessage.Content.ReadAsStringAsync();
                        methodResult.Value = result;

                        var matchLt = RegexLt.Match(result);
                        var matchExecution = RegexExecution.Match(result);
                        var matchEventId = RegexEventId.Match(result);

                        if (matchLt.Success && matchExecution.Success && matchEventId.Success)
                        {
                            account.Lt = matchLt.Groups[1].Value;
                            account.Execution = matchExecution.Groups[1].Value;
                            account.EventId = matchEventId.Groups[1].Value;

                            methodResult.Success = true;
                        }
                        else
                        {
                            methodResult.Error = new Exception("Failed to retrieve login variables");
                            methodResult.Success = false;
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

            internal static async Task<MethodResult> LoginTask(Model account, HttpClient client)
            {
                var methodResult = new MethodResult();
                try
                {
                    var urlEncodedContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("lt", account.Lt),
                        new KeyValuePair<string, string>("execution", account.Execution),
                        new KeyValuePair<string, string>("_eventId", account.EventId),
                        new KeyValuePair<string, string>("username", account.Username),
                        new KeyValuePair<string, string>("password", account.Password)
                    });
                    if (!client.DefaultRequestHeaders.Contains("Referer"))
                        client.DefaultRequestHeaders.Add("Referer", GoSettings);
                    using (
                        var httpResponseMessage =
                            await client.PostAsync("https://sso.pokemon.com/sso/login", urlEncodedContent))
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            var result = await httpResponseMessage.Content.ReadAsStringAsync();
                            methodResult.Value = result;

                            var match = RegexCsrf.Match(result);
                            if (match.Success)
                                account.Csrf = match.Groups[1].Value;

                            methodResult.Success = !string.IsNullOrEmpty(account.Csrf);
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
            internal static async Task<MethodResult> VerifyTask(Model account, HttpClient client)
            {
                var methodResult = new MethodResult();
                try
                {
                    var keyValuePairArray = new KeyValuePair<string, string>[3]
                    {
                        new KeyValuePair<string, string>("csrfmiddlewaretoken", account.Csrf),
                        new KeyValuePair<string, string>("username", account.Username),
                        new KeyValuePair<string, string>("password", account.Password)
                    };
                    if (!client.DefaultRequestHeaders.Contains("Referer"))
                        client.DefaultRequestHeaders.Add("Referer", Activated);
                    using (
                        var httpResponseMessage =
                            await client.PostAsync(Activated, new FormUrlEncodedContent(keyValuePairArray)))
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            methodResult.Value = await httpResponseMessage.Content.ReadAsStringAsync();
                            methodResult.Success = true;
                        }
                        else
                        {
                            methodResult.Error = new Exception("Failed to re-verify");
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
            internal static async Task<MethodResult> SubmitTosTask(Model account, HttpClient client)
            {
                var methodResult = new MethodResult();
                try
                {
                    var keyValuePairArray = new KeyValuePair<string, string>[2]
                    {
                        new KeyValuePair<string, string>("csrfmiddlewaretoken", account.Csrf),
                        new KeyValuePair<string, string>("go_terms", "on")
                    };
                    using (
                        var httpResponseMessage =
                            await client.PostAsync(GoSettings, new FormUrlEncodedContent(keyValuePairArray)))
                    {
                        if (httpResponseMessage.IsSuccessStatusCode)
                        {
                            var result = await httpResponseMessage.Content.ReadAsStringAsync();
                            methodResult.Value = result;

                            if (!result.ToLower().Contains("id_go_terms"))
                            {
                                methodResult.Success = true;
                            }
                            else
                            {
                                methodResult.Error = new Exception("Failed to submit terms of service");
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

            private static async Task<string> SendRecaptchav2RequestTask(string url, string post)
            {
                //POST

                return await Task.Run(() =>
                {
                    ServicePointManager.Expect100Continue = false;
                    var request = (HttpWebRequest) WebRequest.Create(url + post);
                    var data = Encoding.ASCII.GetBytes(post);

                    request.Method = "POST";
                    request.ContentLength = data.Length;

                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }

                    using (var response = (HttpWebResponse) request.GetResponse())
                    {
                        var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                        return responseString;
                    }
                });
            }
        }
    }
}