using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Spotgen
{
    internal class Functions
    {
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string GUUID()
        {
            Guid id = Guid.NewGuid();
            return id.ToString();
        }

        public static IEnumerable<string> LR(string input, string left, string right, bool recursive = false, bool useRegex = false)
        {
            bool flag = left == string.Empty && right == string.Empty;
            IEnumerable<string> result;
            if (flag)
            {
                result = new string[]
                {
                    input
                };
            }
            else
            {
                bool flag2 = (left != string.Empty && !input.Contains(left)) || (right != string.Empty && !input.Contains(right));
                if (flag2)
                {
                    result = new string[0];
                }
                else
                {
                    string text = input;
                    List<string> list = new List<string>();
                    if (recursive)
                    {
                        if (useRegex)
                        {
                            try
                            {
                                string pattern = BuildLRPattern(left, right);
                                MatchCollection matchCollection = Regex.Matches(text, pattern);
                                foreach (object obj in matchCollection)
                                {
                                    Match match = (Match)obj;
                                    list.Add(match.Value);
                                }
                            }
                            catch
                            {
                            }
                        }
                        else
                        {
                            try
                            {
                                while (left == string.Empty || (text.Contains(left) && (right == string.Empty || text.Contains(right))))
                                {
                                    int startIndex = (left == string.Empty) ? 0 : (text.IndexOf(left) + left.Length);
                                    text = text.Substring(startIndex);
                                    int length = (right == string.Empty) ? (text.Length - 1) : text.IndexOf(right);
                                    string text2 = text.Substring(0, length);
                                    list.Add(text2);
                                    text = text.Substring(text2.Length + right.Length);
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    else if (useRegex)
                    {
                        string pattern2 = BuildLRPattern(left, right);
                        MatchCollection matchCollection2 = Regex.Matches(text, pattern2);
                        bool flag3 = matchCollection2.Count > 0;
                        if (flag3)
                        {
                            list.Add(matchCollection2[0].Value);
                        }
                    }
                    else
                    {
                        try
                        {
                            int startIndex = (left == string.Empty) ? 0 : (text.IndexOf(left) + left.Length);
                            text = text.Substring(startIndex);
                            int length = (right == string.Empty) ? text.Length : text.IndexOf(right);
                            list.Add(text.Substring(0, length));
                        }
                        catch
                        {
                        }
                    }
                    result = list;
                }
            }
            return result;
        }

        private static string BuildLRPattern(string ls, string rs)
        {
            var left = string.IsNullOrEmpty(ls) ? "^" : Regex.Escape(ls);
            var right = string.IsNullOrEmpty(rs) ? "$" : Regex.Escape(rs);
            return "(?<=" + left + ").+?(?=" + right + ")";
        }

        public static string RandomString(string Randomize)
        {
            string text = "";
            string text2 = "123456789abcdef"; //H
            string text3 = "abcdefghijklmnopqrstuvwxyz";
            string text4 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string text5 = "1234567890";
            string text6 = "!@#$%^&*()_+";
            string text7 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string text8 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random random = new Random();
            for (int i = 0; i < Randomize.Length - 1; i++)
            {
                if ((Randomize[i].ToString() + Randomize[i + 1].ToString()).Equals("?h"))
                {
                    text += text2[random.Next(0, text2.Length)].ToString();
                }
                else if ((Randomize[i].ToString() + Randomize[i + 1].ToString()).Equals("?l"))
                {
                    text += text3[random.Next(0, text3.Length)].ToString();
                }
                else if ((Randomize[i].ToString() + Randomize[i + 1].ToString()).Equals("?u"))
                {
                    text += text4[random.Next(0, text4.Length)].ToString();
                }
                else if ((Randomize[i].ToString() + Randomize[i + 1].ToString()).Equals("?d"))
                {
                    text += text5[random.Next(0, text5.Length)].ToString();
                }
                else if ((Randomize[i].ToString() + Randomize[i + 1].ToString()).Equals("?m"))
                {
                    text += text7[random.Next(0, text7.Length)].ToString();
                }
                else if ((Randomize[i].ToString() + Randomize[i + 1].ToString()).Equals("?i"))
                {
                    text += text8[random.Next(0, text8.Length)].ToString();
                }
                else if ((Randomize[i].ToString() + Randomize[i + 1].ToString()).Equals("?s"))
                {
                    text += text6[random.Next(0, text6.Length)].ToString();
                }
                else if (Randomize[i].ToString().Contains("-"))
                {
                    text += "-";
                }
                else if (Randomize[i - 1].ToString().Equals("-") && !Randomize[i].ToString().Equals("?"))
                {
                    text += Randomize[i].ToString();
                }
            }
            return text;
        }


    }
}
