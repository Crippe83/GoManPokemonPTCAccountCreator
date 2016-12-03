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
        private class Generator
        {
            private static readonly ApplicationModel Settings = ApplicationModel.Settings();

            public static string GenerateDateOfBirth()
            {
                if (ApplicationModel.Settings().RandomDateOfBirth)
                    return RandomNumber(Settings.RandomMinDateOfBirthYear, Settings.RandomMaxDateOfBirthYear) + "-" +
                           RandomNumber(Settings.RandomMinDateOfBirthMonth, Settings.RandomMaxDateOfBirthMonth)
                               .ToString()
                               .PadLeft(2, '0') + "-" +
                           RandomNumber(Settings.RandomMinDateOfBirthDay, Settings.RandomMaxDateOfBirthDay)
                               .ToString()
                               .PadLeft(2, '0');
                else
                    return Settings.DateOfBirthYear + "-" + Settings.DateOfBirthMonth.ToString().PadLeft(2, '0') + "-" +
                           Settings.DateOfBirthDay.ToString().PadLeft(2, '0');
            }

            public static string GenerateCountry()
            {
                if (Settings.RandomCountry)
                    return ((CountryModel) RandomNumber(0, Enum.GetNames(typeof(CountryModel)).Length)).ToString();
                else
                    return Settings.Country.ToString();
            }

            public static string GenerateCombinedUsername(WordBankModel words)
            {
                string middle = GenerateMiddle(words);
                int max = 15 - middle.Length;
                ;

                if (Settings.RandomPostfix && Settings.RandomPrefix)
                    max /= 2;


                if (max > 6) max = 6;

                string prefix = "";
                string postfix = "";

                if (max == 1 || max == 2)
                {
                    prefix = RandomString(max);
                    postfix = RandomString(max);
                }
                else if (max > 2)
                {
                    prefix = GeneratePrefix(words, max);
                    postfix = GeneratePostfix(words, max);
                }


                string username = FirstLetterToUpper(prefix) + FirstLetterToUpper(middle) + FirstLetterToUpper(postfix);

                if (username.Length > 15)
                    username = username.Substring(0, 15);

                return username;
            }

            private static string GenerateMiddle(WordBankModel words)
            {
                if (Settings.RandomUsername)
                {
                    int middleLength = RandomNumber(3, 6);

                    return words[middleLength][RandomNumber(0, words[middleLength].Count - 1)] + "";
                }
                else
                    return Settings.Username;
            }

            private static string GeneratePrefix(WordBankModel words, int max)
            {
                if (Settings.RandomPrefix)
                {
                    int prefixLength = RandomNumber(3, max);
                    return words[prefixLength][RandomNumber(0, words[prefixLength].Count - 1)] + "";
                }
                else
                    return Settings.UsernamePerfix;
            }

            private static string GeneratePostfix(WordBankModel words, int max)
            {
                if (Settings.RandomPostfix)
                {
                    int postLength = RandomNumber(3, max);
                    return words[postLength][RandomNumber(0, words[postLength].Count - 1)] + "";
                }
                else
                    return Settings.UsernamePostfix;
            }

            public static string GeneratePassword()
            {
                if (Settings.RandomPassword)
                    return RandomPassword(Settings.RandomPasswordLength);
                else
                    return Settings.Password;
            }


            private static string FirstLetterToUpper(string str)
            {
                if (str == null)
                    return null;

                if (str.Length > 1)
                    return char.ToUpper(str[0]) + str.Substring(1);

                return str.ToUpper();
            }

            private static readonly Random Random = new Random();

            public static int RandomNumber(int min, int max)
            {
                return Random.Next(min, max);
            }

            public static string RandomString(int length)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_";
                return new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[Random.Next(s.Length)]).ToArray());
            }

            public static string RandomPassword(int length)
            {
                const string chars = "ABCDEFGHJKMNPQRSTUVWXYZabcdefghjkmnpqrstuvwxyz123456789_!@#$%?";
                return new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[Random.Next(s.Length)]).ToArray());
            }
        }
    }
}
