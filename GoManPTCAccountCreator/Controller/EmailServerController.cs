using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Simple.MailServer;
using Simple.MailServer.Smtp;
using Simple.MailServer.Smtp.Config;

namespace GoManPTCAccountCreator.Controller
{
    class EmailServerController
    {
        private const string RootMailDir = @"Mail";
        private static SmtpServer _smtpServer = null;
        private static PortListener _portListener = null;
        public static void Start()
        {
           _smtpServer = StartSmtpServer();
        }


        private static SmtpServer StartSmtpServer()
        {
            var smtpServer = new SmtpServer
            {
                Configuration =
                {
                    DefaultGreeting = "Goman.MailServer"
                }
            };
            smtpServer.DefaultResponderFactory =
                new SmtpResponderFactory(smtpServer.Configuration)
                {
                    DataResponder = new ExampleDataResponder(smtpServer.Configuration, RootMailDir)
                };

            smtpServer.BindAndListenTo(IPAddress.Any, 25);
            return smtpServer;
        }
    }


    class ExampleDataResponder : SmtpDataResponder
    {
        private readonly string _mailDir;

        public ExampleDataResponder(ISmtpServerConfiguration configuration, string mailDir)
            : base(configuration)
        {
            _mailDir = mailDir;
            EnsureDirExists(mailDir);
        }

        private static void EnsureDirExists(string directory)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        public override SmtpResponse DataStart(ISmtpSessionInfo sessionInfo)
        {
            Console.WriteLine("Start receiving mail: {0}", GetFileNameFromSessionInfo(sessionInfo));
            return SmtpResponses.DataStart;
        }

        private string GetFileNameFromSessionInfo(ISmtpSessionInfo sessionInfo)
        {
            var fileName = sessionInfo.CreatedTimestamp.ToString("yyyy-MM-dd_HHmmss_fff") + ".eml";
            var fullName = Path.Combine(_mailDir, fileName);
            return fullName;
        }

        public override SmtpResponse DataLine(ISmtpSessionInfo sessionInfo, byte[] lineBuf)
        {
            try
            {
                var fileName = GetFileNameFromSessionInfo(sessionInfo);

                using (var stream = File.OpenWrite(fileName))
                {
                    stream.Seek(0, SeekOrigin.End);
                    stream.Write(lineBuf, 0, lineBuf.Length);

                    stream.WriteByte(13);
                    stream.WriteByte(10);
                }

                return SmtpResponses.None;
            }
            catch (Exception)
            {

                return SmtpResponses.None;
            }
        }

        private Regex _reg = new Regex("https://club.pokemon.com/.*/pokemon-trainer-club/activated/\\w+", RegexOptions.IgnoreCase);

        public override SmtpResponse DataEnd(ISmtpSessionInfo sessionInfo)
        {
            try
            {
                var fileName = GetFileNameFromSessionInfo(sessionInfo);
                var size = GetFileSize(fileName);
                VerifyAccount(fileName);

                File.Delete(fileName);

                var successMessage = String.Format("{0} bytes received", size);
                var response = SmtpResponses.OK.CloneAndChange(successMessage);

                return response;
            }
            catch (Exception)
            {

                return null;
            }


        }

        private void VerifyAccount(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string logDump = sr.ReadToEnd();
                Match m = _reg.Match(logDump);
                if (m.Success)
                {
                    String url = m.Value.ToString();

                    using (StreamWriter sw = new StreamWriter("activationURLs.log", true))
                    {
                        sw.WriteLine(url);
                    }

                    
                    WebRequest myWebRequest = WebRequest.Create(url);
                    WebResponse myWebResponse = myWebRequest.GetResponse();
                    myWebResponse.Close();
                }
            }
        }
        private long GetFileSize(string fileName)
        {
            return new FileInfo(fileName).Length;
        }
    }
}
