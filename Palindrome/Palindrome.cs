using System;

namespace Palindrome
{
    public class PalindromeChecker
    {
        public bool IsPalindrome(string InputStr) {

            var chars = InputStr.ToLower().ToCharArray();
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
    }
}