using NUnit.Framework;
using q4.Implementations;

namespace q4.UnitTests
{
    [TestFixture]
    public class DuplicateCharRemoverTests
    {
        //These tests are classical form
        //state based tests.  No moq'ing required here

        //only need one test method 
        //use NUnit to help define the cases
        [TestCase(new char[] { },
            Result = new char[] { },
            TestName = "DuplicateCharRemover_TestEmpty")]

        [TestCase(new char[] { '\0' },
            Result = new char[] { '\0' },
            TestName = "DuplicateCharRemover_TestSingleEmptyChar")]

        [TestCase(new char[] { '\0', '\0', '\0'},
            Result = new char[] { '\0', '\0', '\0' },
            TestName = "DuplicateCharRemover_TestMultipleEmptyChar")]

        [TestCase(new char[] { 'a' },
            Result = new char[] { 'a' },
            TestName = "DuplicateCharRemover_TestSingleCharacter")]

        [TestCase(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'o', 'n', 'p' },
            Result = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'o', 'n', 'p' },
            TestName = "DuplicateCharRemover_TestNoDupesNoSpaces")]

        [TestCase(new char[] { 'a', 'b', 'c', 'c', 'c', 'd' },
            Result = new char[] { 'a', 'b', 'c', 'd', '\0', '\0' },
            TestName = "DuplicateCharRemover_TestDuplicateMiddle")]

        [TestCase(new char[] { 'a', 'a', 'b', 'c', 'd', 'd' },
            Result = new char[] { 'a', 'b', 'c', 'd', '\0', '\0' },
            TestName = "DuplicateCharRemover_TestDuplicateFirstAndLast")]

        [TestCase(new char[] { 'a', 'b', 'c', 'd', '\0' },
            Result = new char[] { 'a', 'b', 'c', 'd', '\0' },
            TestName = "DuplicateCharRemover_TestEmptyCharLast")]

        [TestCase(new char[] { 'a', 'a', 'b', 'c', 'd' },
            Result = new char[] { 'a', 'b', 'c', 'd', '\0' },
            TestName = "DuplicateCharRemover_TestDuplicateCharFirst")]

        [TestCase(new char[] { 'a', 'b', 'b', 'b', 'c', 'c', 'd' },
            Result = new char[] { 'a', 'b', 'c', 'd', '\0', '\0', '\0' },
            TestName = "DuplicateCharRemover_TestDuplicateMultipleMiddle")]

        [TestCase(new char[] { 'a', 'a', 'b', 'b', 'c', 'c', 'd' },
            Result = new char[] { 'a', 'b', 'c', 'd', '\0', '\0', '\0' },
            TestName = "DuplicateCharRemover_TestDuplicateBetweenEachChar")]

        [TestCase(new char[] { 'a', 'a', 'b', 'b', 'c', 'c', 'c', 'd', 'd' },
            Result = new char[] { 'a', 'b', 'c', 'd', '\0', '\0', '\0', '\0', '\0' },
            TestName = "DuplicateCharRemover_TestDuplicateBetweenEachCharAndFirstLast")]

        [TestCase(new char[] { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a' },
            Result = new char[] { 'a', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0' },
            TestName = "DuplicateCharRemover_TestAllSameCharacterMultiple")]
        
        // abbbbbb cddpddef gh 
        [TestCase(new char[] { 'a', 'b', 'b', 'b', 'b', 'b', 'b', 'c', 'd', 'd', 'p', 'd', 'd', 'e', 'f', 'g', 'h', '\0', '\0', '\0' },
            Result = new char[] { 'a', 'b', 'c', 'd', 'p', 'd', 'e', 'f', 'g', 'h', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0' },
            TestName = "DuplicateCharRemover_TestMultipleDupesAndSpaces")]
        public char[] TestStrings(char[] value)
        {
            var duplicateCharRemover = new DuplicateCharRemover();
            duplicateCharRemover.RemoveDuplicateCharacters(value);
            return value;
        }
    }
}
