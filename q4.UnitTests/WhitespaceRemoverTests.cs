using System;
using NUnit.Framework;
using q4.Implementations;

namespace q4.UnitTests
{
    [TestFixture]
    public class WhitespaceRemoverTests
    {
        //These tests are classical form
        //state based tests.  No moq'ing required here

        //only need one test method 
        //use NUnit TestCase attribute to help define the cases
        [TestCase(new char[] { },
            Result = new char[] { },
            TestName = "WhitespaceRemover_TestEmpty")]

        [TestCase(new char[] {' '}, 
            Result= new char[] {'\0'}, 
            TestName="WhitespaceRemover_TestSingleWhiteSpace")]
        
        [TestCase(new char[] {'a','b','c','d','e','f','g','h','i','j','k','l','m','o','n','p'}, 
            Result = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'o', 'n', 'p' },
            TestName = "WhitespaceRemover_TestNoDupesNoSpaces")]

        [TestCase(new char[] { 'a', 'b', 'c', ' ', 'c', 'd'},
            Result = new char[] { 'a', 'b', 'c', 'c', 'd', '\0'},
            TestName = "WhitespaceRemover_TestSpaceBetweenDupeChars")]
        
        [TestCase(new char[] {' ','a','b','c','d',' '},
            Result = new char[] { 'a', 'b', 'c', 'd', '\0', '\0' },
            TestName = "WhitespaceRemover_TestWhitespaceFirstAndLast")]

        [TestCase(new char[] {'a','b','c','d',' '},
            Result = new char[] { 'a', 'b', 'c', 'd', '\0' },
            TestName = "WhitespaceRemover_TestWhitespaceLast")]

        [TestCase(new char[] { ' ', 'a', 'b', 'c', 'd'},
            Result = new char[] { 'a', 'b', 'c', 'd', '\0' },
            TestName = "WhitespaceRemover_TestWhitespaceFirst")]

        [TestCase(new char[] { 'a', 'b', ' ', ' ', ' ', 'c', 'd' },
            Result = new char[] { 'a', 'b', 'c', 'd', '\0', '\0', '\0' },
            TestName = "WhitespaceRemover_TestWhitespaceMultipleMiddle")]

        [TestCase(new char[] { 'a', ' ', 'b', ' ', 'c', ' ', 'd' },
            Result = new char[] { 'a', 'b', 'c', 'd', '\0', '\0', '\0' },
            TestName = "WhitespaceRemover_TestWhitespaceBetweenEachChar")]

        [TestCase(new char[] { ' ', 'a', ' ', 'b', ' ', 'c', ' ', 'd', ' ' },
            Result = new char[] { 'a', 'b', 'c', 'd', '\0', '\0', '\0', '\0', '\0' },
            TestName = "WhitespaceRemover_TestWhitespaceBetweenEachCharAndFirstLast")]
        public char[] TestStrings(char[] value)
        {
            var whiteSpaceRemover = new WhitespaceRemover();
            whiteSpaceRemover.RemoveWhiteSpace(value);
            return value;
        }
    }
}
