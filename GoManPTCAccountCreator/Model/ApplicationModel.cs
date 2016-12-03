using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GoManPTCAccountCreator.Model
{
    class ApplicationModel
    {
        private static ApplicationModel _instance;

        private ApplicationModel()
        {   
        }

        public static ApplicationModel Settings()
        {
            if (_instance != null)
                return _instance;
            else
            {
                if (File.Exists("GOMANPtcAccountCreator.settings"))
                    _instance = LoadSetting();
                else
                {
                    _instance = new ApplicationModel();
                    _instance.SaveSetting();
                }

                return _instance;
            }
        }


        public string EmailDomain { get; set; } = "mail.goman.io";
        public int MaxThreads { get; set; } = 15;
        public string ProxyDomain { get; set; } = "chancity.hopto.org";
        public int ProxyPort { get; set; } = 1080;
        public string CaptchaKey { get; set; } = "Enter your 2Captcha Key";
        public string Username { get; set; } = "chancity";
        public  string UsernamePerfix { get; set; } = "GoMan";
        public  string UsernamePostfix { get; set; } = "q";
        public string Password { get; set; } = "GoManP@ssw0rd";
        public int DateOfBirthDay { get; set; } = 22;
        public int DateOfBirthMonth { get; set; } = 9;
        public int DateOfBirthYear { get; set; } = 1988;
        public CountryModel Country { get; set; } = CountryModel.US;
        public bool RandomPassword { get; set; } = true;
        public int RandomPasswordLength { get; set; } = 7;
        public bool RandomUsername { get; set; } = true;
        public bool RandomPrefix { get; set; } = false;
        public bool RandomPostfix { get; set; } = true;
        public  bool RandomDateOfBirth { get; set; } = true;
        public bool RandomCountry { get; set; } = false;
        private static int _randomMaxDateOfBirthYear = 2002;
        public  int RandomMaxDateOfBirthYear
        {
            get { return _randomMaxDateOfBirthYear;}
            set { _randomMaxDateOfBirthYear = (value >= _randomMinDateOfBirthYear && value <= 2002) ? value : 2002; }
        }
        private static int _randomMinDateOfBirthYear = 1910;
        public  int RandomMinDateOfBirthYear
        {
            get { return _randomMinDateOfBirthYear; }
            set { _randomMinDateOfBirthYear = (value <= _randomMaxDateOfBirthYear && value >= 1910) ? value : 1910; }
        }
        private static int _randomMaxDateOfBirthMonth = 12;
        public  int RandomMaxDateOfBirthMonth
        {
            get { return _randomMaxDateOfBirthMonth; }
            set { _randomMaxDateOfBirthMonth = (value >= _randomMinDateOfBirthMonth && value <= 12) ? value : 12; }
        }
        private static int _randomMinDateOfBirthMonth = 1;
        public  int RandomMinDateOfBirthMonth
        {
            get { return _randomMinDateOfBirthMonth; }
            set { _randomMinDateOfBirthMonth = (value <= _randomMaxDateOfBirthMonth && value >= 1) ? value : 1; }
        }
        private static int _randomMaxDateOfBirthDay = 31;
        public  int RandomMaxDateOfBirthDay
        {
            get { return _randomMaxDateOfBirthDay; }
            set { _randomMaxDateOfBirthDay = (value >= _randomMinDateOfBirthDay && value <= 31) ? value : 31; }
        }
        private static int _randomMinDateOfBirthDay = 1;
        public  int RandomMinDateOfBirthDay
        {
            get { return _randomMinDateOfBirthDay; }
            set { _randomMinDateOfBirthDay = (value <= _randomMaxDateOfBirthDay && value >= 1) ? value : 1; }
        }
        public void SaveSetting()
        {
            string settings = JsonConvert.SerializeObject(this, Formatting.Indented);

            using (StreamWriter sw = new StreamWriter("GOMANPtcAccountCreator.settings", false))
            {
                sw.WriteLine(settings);
            }
        }
        private static ApplicationModel LoadSetting()
        {
            using (StreamReader sr = new StreamReader("GOMANPtcAccountCreator.settings"))
            {

                return JsonConvert.DeserializeObject<ApplicationModel>(sr.ReadToEnd());
            }
        }

    }
}
