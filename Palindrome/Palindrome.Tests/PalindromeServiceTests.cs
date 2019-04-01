using System;
using Xunit;
using Palindrome;

namespace Palindrome.Tests
{
    public class PalindromeServiceShould
    {
        private readonly PalindromeChecker _palindromeChecker;

        public PalindromeServiceShould()
        {
            _palindromeChecker = new PalindromeChecker();
        }

        [Fact]
        public void ReturnTrueGivenTheWorddeleveled()
        {
            var result = _palindromeChecker.IsPalindrome("deleveled");

            Assert.True(result, "deleveled is a palindrome");
        }

        [Fact]
        public void ReturnFalseGivenTheWordhello()
        {
            var result = _palindromeChecker.IsPalindrome("hello");

            Assert.False(result, "hello is not palindrome");
        }

        [Fact]
        public void ReturnTrueIfAPalindromeAndContainsUpperCase()
        {
            var result = _palindromeChecker.IsPalindrome("Deleveled");

            Assert.True(result, "Uppercase characters should be ignored");
        }

        [Fact]
        public void ReturnTrueIfAPalindromeAndContainsSpecialCharacters()
        {
            var result = _palindromeChecker.IsPalindrome("De-leveled");

            Assert.True(result, "Special characters should be ignored");
        }



    }
}
