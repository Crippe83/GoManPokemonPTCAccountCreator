using System.Collections.Concurrent;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using GoManPTCAccountCreator.Model;

namespace GoManPTCAccountCreator.Controller
{
    partial class Account
    {
   
        public delegate void AccountAdded(AccountModel account);
        public event AccountAdded EventAccountAdded;

        public delegate void RefreshAccount(AccountModel account);
        public static event RefreshAccount EventRefreshAccount;

        private static readonly ConcurrentQueue<Account.Model> ConcurrentQueue = new ConcurrentQueue<Account.Model>();
        private static int QueueCounter;
        private static StreamWriter _streamWriter;
        private static readonly System.Timers.Timer timer = new System.Timers.Timer(200);

        private int _maxCreationAtTime;

        public int MaxCreationAtTime {
            get { return _maxCreationAtTime; }
            set { _maxCreationAtTime = value < 0 ? 5 : value;}
        }

        public static string CaptchaKey { get; set; }

        public Account(string captchakey)
        {
            CaptchaKey = captchakey;
            timer.Elapsed += new ElapsedEventHandler(Timer_tick);
            timer.Enabled = true;
            timer.Start();
        }

    }
}
