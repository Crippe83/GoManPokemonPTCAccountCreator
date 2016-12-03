using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoManPTCAccountCreator.Model
{
    public enum LoggerTypes { Debug, Success, Warning, Exception };

    public class LogModel
    {
        public LoggerTypes LoggerType { get; }
        //public DateTime Date { get; } = DateTime.Now;
        public string ExceptionMessage { get; }
        public string StackTrace { get; }
        public string Message { get; }
        public string Html { get; }

        public LogModel(LoggerTypes loggerType, string message, string html = "", Exception exception = null) 
        {
            this.LoggerType = loggerType;
            this.Message = string.Intern(message);
            this.Html = html;

            if (exception == null) return;
            if (exception.StackTrace != null) this.StackTrace = string.Intern(exception.StackTrace);
            this.ExceptionMessage = string.Intern(exception.Message);
        }

        public Color GetLogColor()
        {
            switch (LoggerType)
            {
                case LoggerTypes.Success:
                    return Color.Green;
                case LoggerTypes.Warning:
                    return Color.Yellow;
                case LoggerTypes.Exception:
                    return Color.Red;
                case LoggerTypes.Debug:
                    return Color.DarkGray;
            }

            return SystemColors.WindowText;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(ExceptionMessage))
            {
                return $"Type: {LoggerType} Message: {Message} Exception: {ExceptionMessage}";
            }

            return $"Type: {LoggerType} Message: {Message}";
        }
    }
}
