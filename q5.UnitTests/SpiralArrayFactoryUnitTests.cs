using System.Linq;
using NUnit.Framework;
using q5.Implementations;

namespace q5.UnitTests
{
    [TestFixture]
    public class SpiralArrayFactoryUnitTests
    {
        
        [Test]
        public void SpiralArrayFactory_TestEmptyData()
        {
            var factory = new SpiralArrayFactory();
            var result = factory.Create(new string[,] {});
            Assert.IsTrue(!result.Any());
        }

        [Test]
        public void MatrixDataLoader_TestSingleItemInData()
        {
            var factory = new SpiralArrayFactory();
            var dataArray = new[,] {{"a"}};
            var result = factory.Create(dataArray);
            Assert.IsTrue(result.ToArray()[0] == "a");
        }

        [Test]
        public void MatrixDataLoader_TestSingleLine()
        {
            var factory = new SpiralArrayFactory();
            var dataArray = new[,] { { "1",  "sj", "2", "sjw",  "2" } };
            var result = factory.Create(dataArray);
            var enumerable = result as string[] ?? result.ToArray();
            Assert.IsTrue(enumerable[0] == "1");
            Assert.IsTrue(enumerable[1] == "sj");
            Assert.IsTrue(enumerable[2] == "2");
            Assert.IsTrue(enumerable[3] == "sjw");
            Assert.IsTrue(enumerable[4] == "2");
        }

        [Test]
        public void MatrixDataLoader_TestMultipleLine()
        {
            var factory = new SpiralArrayFactory();
            var dataArray = new[,]
            {
                { "1", "sj", "2", "sjw", "2" },
                {"hhhh","2222","2", "3", "5"},
                {"6", "7", "8", "9", "10"}
            };
            var result = factory.Create(dataArray);
            var enumerable = result as string[] ?? result.ToArray();
            Assert.IsTrue(enumerable[0] == "1");
            Assert.IsTrue(enumerable[1] == "sj");
            Assert.IsTrue(enumerable[2] == "2");
            Assert.IsTrue(enumerable[3] == "sjw");
            Assert.IsTrue(enumerable[4] == "2");
            Assert.IsTrue(enumerable[5] == "5");
            Assert.IsTrue(enumerable[6] == "10");
            Assert.IsTrue(enumerable[7] == "9");
            Assert.IsTrue(enumerable[8] == "8");
            Assert.IsTrue(enumerable[9] == "7");
            Assert.IsTrue(enumerable[10] == "6");
            Assert.IsTrue(enumerable[11] == "hhhh");
            Assert.IsTrue(enumerable[12] == "2222");
            Assert.IsTrue(enumerable[13] == "2");
            Assert.IsTrue(enumerable[14] == "3");
        }

        [Test]
        public void MatrixDataLoader_TestSampleData()
        {
            var factory = new SpiralArrayFactory();
            var dataArray = new[,]
            {
                { "1", "2", "3" },
                { "4", "5", "6"},
                { "7", "8", "9"}
            };
            var result = factory.Create(dataArray);
            var enumerable = result as string[] ?? result.ToArray();
            Assert.IsTrue(enumerable[0] == "1");
            Assert.IsTrue(enumerable[1] == "2");
            Assert.IsTrue(enumerable[2] == "3");
            Assert.IsTrue(enumerable[3] == "6");
            Assert.IsTrue(enumerable[4] == "9");
            Assert.IsTrue(enumerable[5] == "8");
            Assert.IsTrue(enumerable[6] == "7");
            Assert.IsTrue(enumerable[7] == "4");
            Assert.IsTrue(enumerable[8] == "5");
        }
    }
}
