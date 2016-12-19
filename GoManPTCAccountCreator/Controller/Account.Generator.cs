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
                    return RandomPassword(Settings.RandomPasswordLength, 4);
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

            private static int RandomNumber(int min, int max)
            {
                return Random.Next(min, max);
            }

            private static string RandomString(int length)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_";
                return new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[Random.Next(s.Length)]).ToArray());
            }

            /// <summary>
            /// Creates a pseudo-random password containing the number of character classes
            /// defined by complexity, where 2 = alpha, 3 = alpha+num, 4 = alpha+num+special.
            /// </summary>
            public static string RandomPassword(int length, int complexity)
            {
                System.Security.Cryptography.RNGCryptoServiceProvider csp =
                new System.Security.Cryptography.RNGCryptoServiceProvider();
                // Define the possible character classes where complexity defines the number
                // of classes to include in the final output.
                char[][] classes =
                {
                    @"abcdefghjkmnpqrstuvwxyz".ToCharArray(),
                    @"ABCDEFGHJKMNPQRSTUVWXYZ".ToCharArray(),
                    @"123456789".ToCharArray(),
                    @"_!@#$%?".ToCharArray(),
                    };

                complexity = Math.Max(1, Math.Min(classes.Length, complexity));
                if (length < complexity)
                    throw new ArgumentOutOfRangeException("length");

                // Since we are taking a random number 0-255 and modulo that by the number of
                // characters, characters that appear earilier in this array will recieve a
                // heavier weight. To counter this we will then reorder the array randomly.
                // This should prevent any specific character class from recieving a priority
                // based on it's order.
                char[] allchars = classes.Take(complexity).SelectMany(c => c).ToArray();
                byte[] bytes = new byte[allchars.Length];
                csp.GetBytes(bytes);
                for (int i = 0; i < allchars.Length; i++)
                {
                    char tmp = allchars[i];
                    allchars[i] = allchars[bytes[i] % allchars.Length];
                    allchars[bytes[i] % allchars.Length] = tmp;
                }

                // Create the random values to select the characters
                Array.Resize(ref bytes, length);
                char[] result = new char[length];

                while (true)
                {
                    csp.GetBytes(bytes);
                    // Obtain the character of the class for each random byte
                    for (int i = 0; i < length; i++)
                        result[i] = allchars[bytes[i] % allchars.Length];

                    // Verify that it does not start or end with whitespace
                    if (Char.IsWhiteSpace(result[0]) || Char.IsWhiteSpace(result[(length - 1) % length]))
                        continue;

                    string testResult = new string(result);
                    // Verify that all character classes are represented
                    if (0 != classes.Take(complexity).Count(c => testResult.IndexOfAny(c) < 0))
                        continue;

                    return testResult;
                }
            }
        }
    }
}
