using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using GoManPTCAccountCreator.Model;
using Microsoft.Win32;

namespace GoManPTCAccountCreator.Controller
{


    public partial class Account
    {
        private readonly AutoResetEvent _queueNotifier = new AutoResetEvent(false);
        private readonly AutoResetEvent _queueNotifier1 = new AutoResetEvent(false);
        private  int _maxThreads = 0;
        private  void Timer_tick(object sender, ElapsedEventArgs e)
        {
            if (QueueCounter < _maxThreads)
                _queueNotifier1.Set();
        }
        public async Task<bool> CreateAccounts(int accountCount)
        {
            await Task.Run(() =>
            {
                using (WordBankModel words = new WordBankModel())
                {
                    for (var i = 0; i < accountCount; i++)
                    {
                        Model account = new Model(words);
                        OnEventAccountAdded(account);
                        ConcurrentQueue.Enqueue(account);
                    }
                }
            });

            _queueNotifier.Set();
            return true;
        }

        public async Task<bool> ImportAccounts(string path)
        {
            await Task.Run(() =>
            {
                using (var fileStream = File.OpenRead(path))
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, 128))
                {
                    String line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        Debug.WriteLine(line);
                        if (string.IsNullOrEmpty(line)) break;
                        string[] accountInfo = line.Split(':');
                        if (accountInfo.Length != 2) break;

                        Model account = new Model(accountInfo[0], accountInfo[1]);
                        OnEventAccountAdded(account);
                        ConcurrentQueue.Enqueue(account);
                    }

                  }
            });

            _queueNotifier.Set();
            return true;
        }
        public void Start(int maxThreads)
         {
             _maxThreads = maxThreads;
             Task.Run(() =>
             {
                 while (true)
                 {
                     _queueNotifier.WaitOne();
                     while (!ConcurrentQueue.IsEmpty)
                     {
                         if (QueueCounter >= maxThreads) _queueNotifier1.WaitOne();
                         Model account;
                         if (!ConcurrentQueue.TryDequeue(out account)) continue;

                         if (account.TypeOfTask == AccountModel.TaskType.Create) Actions.SignUp(account);
                         if (account.TypeOfTask == AccountModel.TaskType.Verify) Actions.Verify(account);


                     }
                 }
             });
        }

        protected virtual void OnEventAccountAdded(AccountModel account)
        {
            EventAccountAdded?.Invoke(account);
        }
    }
}