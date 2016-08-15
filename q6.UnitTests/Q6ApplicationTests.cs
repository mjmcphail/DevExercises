using Moq;
using NUnit.Framework;
using q6.Implementations;
using q6.Interfaces;
using RS.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace q6.UnitTests
{
    /// <summary>
    /// These tests are Moq tests which 
    /// test the behavior of the main application code
    /// all non .NET dependancies are covered by 
    /// thier respective unit tests.
    /// </summary>
    [TestFixture]
    public class Q6ApplicationTests
    {
        /// <summary>
        /// This helper method will do all the mocking
        /// and setup for the different test cases.
        /// The parameters passed allow this code to be
        /// reused to execute different test cases
        /// </summary>
        /// <param name="mainTreeString">main tree input string</param>
        /// <param name="subTreeString">sub tree input string</param>
        /// <param name="mainTree">The main tree Binary tree structure</param>
        /// <param name="expectedReturnValue">Should the comparison return true or false</param>
        private void TestRunHelper(string mainTreeString, string subTreeString, IBinaryTree<string> mainTree, bool expectedReturnValue)
        {
            var fileFacadeMock = new Mock<IFileFacade>();
            var binaryTreeFactoryMock = new Mock<IBinaryTreeFactory>();
            var treeComparerMock = new Mock<ITreeComparer>();

            Func<IEnumerable<string>> getEnumerableStrings = delegate
            {
                var strings = new List<string> { mainTreeString, subTreeString };
                return strings;
            };
            //setup fileFacade mock
            fileFacadeMock.Setup(ff =>
                ff.ReadLines(It.IsAny<string>())).Returns(getEnumerableStrings);

            var subTree = UnitTestHelpers.BuildSmallSubTree("4", "2", "5");

            //setup binaryTreeFactoryMock for different calls to Create
            binaryTreeFactoryMock.Setup(btf =>
                btf.Create(mainTreeString)).Returns(mainTree);

            binaryTreeFactoryMock.Setup(btf =>
                btf.Create(subTreeString)).Returns(subTree);

            //setup treeComparerMock for IsSubtree call
            treeComparerMock.Setup(tc =>
                tc.IsSubtree(mainTree.Root, subTree.Root)).Returns(expectedReturnValue);

            //create the app class and run it
            var q6Application = new Q6Application("test",
               fileFacadeMock.Object,
               binaryTreeFactoryMock.Object,
               treeComparerMock.Object);

            q6Application.Run();

            //verify all calls were run during the test
            binaryTreeFactoryMock.Verify(btf => btf.Create(mainTreeString), Times.AtLeastOnce());
            binaryTreeFactoryMock.Verify(btf => btf.Create(mainTreeString), Times.AtLeastOnce());
            treeComparerMock.Verify(tc => tc.IsSubtree(mainTree.Root, subTree.Root), Times.AtLeastOnce());
        }

        [Test]
        public void Q6Application_TestRunValidTree()
        {
            TestRunHelper("1,5,4,,3,2,5,,,,,,,0,8", "4,2,5", UnitTestHelpers.BuildMainTree(), true);
        }

        [Test]
        public void Q6Application_TestRunInvalidTree()
        {
            TestRunHelper("1,5,4,,3,2,9,,,,,,,0,8", "4,2,5", UnitTestHelpers.BuildOtherMainTree(), false);
        }
    }
}
