using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoManPTCAccountCreator.Model;

namespace GoManPTCAccountCreator.Controller
{
    public partial class Account
    {
        private class Model : AccountModel
        {
            public string Lt = "";
            public string Execution = "";
            public string EventId = "";
            public string Csrf = "";
            public string CaptchaId = "";
            public string CaptchaResponse = "";

            public Model(WordBankModel words) : base(Generator.GenerateCombinedUsername(words), Generator.GeneratePassword(), Generator.GenerateCountry(), Generator.GenerateDateOfBirth())
            {
                AccountModel.PendingCount++;
                this.TypeOfTask = TaskType.Create;
                //Status = StatusType.Pending;
            }
            public Model(string username, string password) : base(username, password)
            {
                AccountModel.PendingCount++;
                this.TypeOfTask = TaskType.Verify;
                //Status = StatusType.Pending;
            }
            public void CleanUp()
            {
                Lt = null;
                Execution = null;
                EventId = null;
                Csrf = null;
                CaptchaId = null;
                CaptchaResponse = null;
                ScreenName = null;
            }
        }
    }
}
