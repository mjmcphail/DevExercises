using System.Net;
using Moq;
using NUnit.Framework;
using q5.Implementations;
using q5.Interfaces;
using RS.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace q5.UnitTests
{
    [TestFixture]
    public class Q5ApplicationUnitTests
    {
        /// <summary>
        /// Q5 application run is 
        /// very simple so not much to test here
        /// other than each injected dependency 
        /// is called once.
        /// </summary>
        [Test]
        public void Q5Application_TestRun()
        {
            var matrixDataLoaderMock = new Mock<IMatrixDataLoader>();
            var spiralArrayFactoryMock = new Mock<ISpiralArrayFactory>();
            const string filePath = "test";
            Func<IEnumerable<string>> getEnumerableStrings = () => new List<string>();
            var testArray = new string[,]{};
            matrixDataLoaderMock.Setup(mdl => mdl.Load(filePath)).Returns(testArray);
            spiralArrayFactoryMock.Setup(saf => saf.Create(testArray)).Returns(getEnumerableStrings);
            
            //create the app class and run it
            var q5Application = new Q5Application("test",
               matrixDataLoaderMock.Object,
               spiralArrayFactoryMock.Object);

            q5Application.Run();

            //verify all calls were run during the test
            matrixDataLoaderMock.Verify(mdl => mdl.Load(filePath), Times.Once);
            spiralArrayFactoryMock.Verify(saf => saf.Create(testArray), Times.Once);
        }
    }
}
