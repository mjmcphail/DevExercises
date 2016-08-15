using Moq;
using NUnit.Framework;
using q5.Implementations;
using RS.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace q5.UnitTests
{
    [TestFixture]
    public class MatrixDataLoaderUnitTests
    {
        private void MatrixDataLoaderTestHelper(IEnumerable<string> dataLines, Action<string[,]> assertAction)
        {
            const string filePath = "test";
            var fileFacadeMock = new Mock<IFileFacade>();
            fileFacadeMock.Setup(ff => ff.ReadLines(filePath)).Returns(dataLines);
            var matrixDataLoader = new MatrixDataLoader(fileFacadeMock.Object);
            var dataArray = matrixDataLoader.Load(filePath);
            assertAction(dataArray);
        }
        
        [Test]
        public void MatrixDataLoader_TestLoadEmptyData()
        {
            MatrixDataLoaderTestHelper(new List<string>(), 
                dataArray => Assert.IsTrue(dataArray.LongLength == 0));
        }

        [Test]
        public void MatrixDataLoader_TestSingleItemInData()
        {
            var data = new List<string> {"a"};
            MatrixDataLoaderTestHelper(data,
                dataArray => Assert.IsTrue(dataArray.LongLength == 1));
        }

        [Test]
        public void MatrixDataLoader_TestSingleLine()
        {
            var data = new List<string> {"  1  sj  2 sjw  2"};
            MatrixDataLoaderTestHelper(data,
                dataArray => Assert.IsTrue(dataArray.LongLength == 5));

            data = new List<string> { "  1  sj  2 sjw  2      " };
            MatrixDataLoaderTestHelper(data,
                dataArray => Assert.IsTrue(dataArray.LongLength == 5));
        }

        [Test]
        public void MatrixDataLoader_TestMultipleLine()
        {
            var data = new List<string>
            {
                "  1  sj  2 sjw  2",
                " hhhh  2222 2 3 5",
                "6 7 8 9 10"
            };
            MatrixDataLoaderTestHelper(data,
                dataArray =>
                {
                    Assert.IsTrue(dataArray.LongLength == 15);
                    Assert.IsTrue(dataArray.GetLength(0) == 3);
                    Assert.IsTrue(dataArray.GetLength(1) == 5);
                });
        }

        [Test]
        public void MatrixDataLoader_TestSampleData()
        {
            var data = new List<string>
            {
                "1 2 3 ",
                "4 5 6         ",
                "7 8 9 "
            };
            MatrixDataLoaderTestHelper(data,
                dataArray =>
                {
                    Assert.IsTrue(dataArray.LongLength == 9);
                    Assert.IsTrue(dataArray.GetLength(0) == 3);
                    Assert.IsTrue(dataArray.GetLength(1) == 3);
                    Assert.IsTrue(dataArray[0, 0] == "1");
                    Assert.IsTrue(dataArray[0, 1] == "2");
                    Assert.IsTrue(dataArray[0, 2] == "3");
                    Assert.IsTrue(dataArray[1, 0] == "4");
                    Assert.IsTrue(dataArray[1, 1] == "5");
                    Assert.IsTrue(dataArray[1, 2] == "6");
                    Assert.IsTrue(dataArray[2, 0] == "7");
                    Assert.IsTrue(dataArray[2, 1] == "8");
                    Assert.IsTrue(dataArray[2, 2] == "9");
                });
        }
    }
}
