using System;
using System.Text.RegularExpressions;

namespace Palindrome
{
    public class PalindromeChecker
    {
        public bool IsPalindrome(string InputStr) {

            var filteredString = RemoveSpecialCharacters(InputStr.ToLower());
            var chars = filteredString.ToCharArray();
            var length = chars.Length;

            for(int index = 0; index < length / 2; index++)
            {
                if(chars[index] != chars[length - index - 1])
                {
                    return false;
                }
            }
            return true;

        }

        private static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-z]+", "", RegexOptions.Compiled);
        }

    }
}