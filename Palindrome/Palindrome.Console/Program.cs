using System;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            var checker = new PalindromeChecker();
            string word = "De-leveled";
            var result = checker.IsPalindrome(word);
            Console.WriteLine("Result for " +  word + " is: {0}",result);
        }
    }
}
