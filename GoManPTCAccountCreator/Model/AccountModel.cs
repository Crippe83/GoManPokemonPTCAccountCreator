using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using GoManPTCAccountCreator.Controller;
using Newtonsoft.Json;

namespace GoManPTCAccountCreator.Model
{
    public class AccountModel
    {
        public enum StatusType { Pending, Running, Failed, Created };
        public enum TaskType { Create, Verify, ChangePassword };
        public delegate void LogAdded(LogModel log);
        public event LogAdded EventLogAdded;
        private static int _runningCount = 0;
        private static int _failedCount = 0;
        private static int _createdCount = 0;
        private static int _pendingCount = 0;

        public static int RunningCount { get { return _runningCount; } set { _runningCount = value; } }
        public static int FailedCount { get { return _failedCount; } set { _failedCount = value; } }
        public static int CreatedCount { get { return _createdCount; } set { _createdCount = value; } }
        public static int PendingCount { get { return _pendingCount; } set { _pendingCount = value; } }

        public string TosAccepted { get; set; } = "False";
        private StatusType _status = StatusType.Pending;
        public StatusType Status
        {
            get
            {
                return _status;
            }
            set
            {
                IncreaseCount(value);
                DecreaseCount(_status);



                _status = value;
            } 
        } 

        public TaskType TypeOfTask { get; set; }
        public string Username { get; }
        public string Password { get; }
        public string Email { get; } = "imported account";
        public string Country { get;} = "imported account";
        public string DateOfBirth { get;} = "imported account";


        private string _log;

        [JsonIgnore]
        public string Log
        {
            get { return _log; } 
            set { _log = string.Intern(value); }
        } 


        public string ScreenName;
        public bool PublicProfileOptIn = false;

        public List<LogModel> EventLog = new List<LogModel>();
        public AccountModel(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public AccountModel(string username, string password, string country, string dateOfBirth, string email = "", string screenname = "")
        {
            Username = username;
            Password = password;
            Email = (string.IsNullOrEmpty(email)) ? username + "@" + ApplicationModel.Settings().EmailDomain : email;
            ScreenName = (string.IsNullOrEmpty(screenname)) ? username : screenname;
            Country = country;
            DateOfBirth = dateOfBirth;
        }

        public void AddLog(LoggerTypes type, string message, string html = "", Exception exception = null)
        {
            LogModel newLog = new LogModel(type, message, html, exception);
            EventLog.Add(newLog);
            OnEventLogAdded(newLog);
            this.Log = newLog.ToString();
        }


        public Color GetLogColor()
        {
            switch (Status)
            {
                case StatusType.Running:
                    return Color.Green;
                case StatusType.Failed:
                    return Color.Yellow;
                case StatusType.Pending:
                    return Color.LightGreen;
                case StatusType.Created:
                    return Color.DodgerBlue;
            }

            return SystemColors.WindowText;
        }

        private void IncreaseCount(StatusType stats)
        {
            switch (stats)
            {
                case StatusType.Pending:
                    Interlocked.Increment(ref _pendingCount);
                    break;
                case StatusType.Running:
                    Interlocked.Increment(ref _runningCount);
                    break;
                case StatusType.Failed:
                    Interlocked.Increment(ref _failedCount);
                    break;
                case StatusType.Created:
                    Interlocked.Increment(ref _createdCount);
                    break;
            }
        }

        private void DecreaseCount(StatusType stats)
        {
            switch (stats)
            {
                case StatusType.Pending:
                    Interlocked.Decrement(ref _pendingCount);
                    break;
                case StatusType.Running:
                    Interlocked.Decrement(ref _runningCount);
                    break;
                case StatusType.Failed:
                    Interlocked.Decrement(ref _failedCount);
                    break;
                case StatusType.Created:
                    Interlocked.Decrement(ref _createdCount);
                    break;
            }
        }

        protected virtual void OnEventLogAdded(LogModel log)
        {
            EventLogAdded?.Invoke(log);
        }
    }
}