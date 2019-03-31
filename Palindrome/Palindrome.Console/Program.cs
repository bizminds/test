using System;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            var checker = new PalindromeChecker();

            var result = checker.IsPalindrome("p'eep");
            Console.WriteLine(result);
        }
    }
}
