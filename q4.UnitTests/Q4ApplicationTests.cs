using Moq;
using NUnit.Framework;
using q4.Implementations;
using q4.Interfaces;
using RS.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace q4.UnitTests
{
    [TestFixture]
    public class Q4ApplicationTests
    {
        
        /// <summary>
        /// For this test we will use Moq to 
        /// moq up dependencies and verify behavior
        /// of the Application run
        /// </summary>
        [Test]
        public void Q4Application_TestRun()
        {
            var fileFacadeMock = new Mock<IFileFacade>();
            var whitespaceRemoverMock = new Mock<IWhitespaceRemover>();
            var duplicateCharRemoverMock = new Mock<IDuplicateCharRemover>();
            Func<IEnumerable<string>> getEnumerableStrings = delegate()
            {
                var strings = new List<string>();
                strings.Add("abcdefg");
                return strings;
            };
            fileFacadeMock.Setup(ff => 
                ff.ReadLines(It.IsAny<string>())).Returns(getEnumerableStrings);
            char[] charArray = {'a','b','c','d','e','f','g'};
            whitespaceRemoverMock.Setup(ws => ws.RemoveWhiteSpace(charArray));
            duplicateCharRemoverMock.Setup(dcr => dcr.RemoveDuplicateCharacters(charArray));
            
            var q4Application = new Q4Application("test", 
                fileFacadeMock.Object, 
                whitespaceRemoverMock.Object,
                duplicateCharRemoverMock.Object);

            q4Application.Run();

            whitespaceRemoverMock.Verify(wsr => wsr.RemoveWhiteSpace(charArray), Times.AtLeastOnce());
            duplicateCharRemoverMock.Verify(dcrm => dcrm.RemoveDuplicateCharacters(charArray), Times.AtLeastOnce());
        }
    }
}
