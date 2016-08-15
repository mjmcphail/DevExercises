using NUnit.Framework;
using q6.Implementations;

namespace q6.UnitTests
{
    /// <summary>
    /// These tests test the tree comparer against 
    /// various combinations of 
    /// tree structures
    /// </summary>
    [TestFixture]
    public class TreeComparerUnitTests
    {
        [Test]
        public void TreeComparer_TestBothTreesNull()
        {
            var comparer = new TreeComparer();
            var result = comparer.IsSubtree(null, null);
            Assert.IsTrue(result);
        }

        [Test]
        public void TreeComparer_TestMainTreeNullSubTreeNotNull()
        {
            var comparer = new TreeComparer();
            var result = comparer.IsSubtree(null, UnitTestHelpers.BuildSmallSubTree("4", "2", "5").Root);
            Assert.IsFalse(result);
        }

        [Test]
        public void TreeComparer_TestMainTreeNotNullSubTreeNull()
        {
            var comparer = new TreeComparer();
            var result = comparer.IsSubtree(UnitTestHelpers.BuildSmallSubTree("4", "2", "5").Root, null);
            Assert.IsTrue(result);
        }

        [Test]
        public void TreeComparer_TestBothTreesOneNode()
        {
            var comparer = new TreeComparer();
            var mainTree = UnitTestHelpers.BuildSmallSubTree("4", "2", "5").Root;
            mainTree.Left = null;
            mainTree.Right = null;
            var subTree = UnitTestHelpers.BuildSmallSubTree("4", "2", "5").Root;
            subTree.Left = null;
            subTree.Right = null;
            var result = comparer.IsSubtree(mainTree, subTree);
            Assert.IsTrue(result);
        }

        [Test]
        public void TreeComparer_TestBothTreesSame()
        {
            var comparer = new TreeComparer();
            var mainTree = UnitTestHelpers.BuildSmallSubTree("4", "2", "5").Root;
            mainTree.Left = UnitTestHelpers.BuildSmallSubTree("1", "2", "3").Root;
            mainTree.Right = UnitTestHelpers.BuildSmallSubTree("4", "5", "6").Root;
            var subTree = UnitTestHelpers.BuildSmallSubTree("4", "2", "5").Root;
            subTree.Left = UnitTestHelpers.BuildSmallSubTree("1", "2", "3").Root;
            subTree.Right = UnitTestHelpers.BuildSmallSubTree("4", "5", "6").Root;
            var result = comparer.IsSubtree(mainTree, subTree);
            Assert.IsTrue(result);
        }

        [Test]
        public void TreeComparer_TestBothTreesDifferent()
        {
            var comparer = new TreeComparer();
            var mainTree = UnitTestHelpers.BuildSmallSubTree("4", "2", "5").Root;
            mainTree.Left = UnitTestHelpers.BuildSmallSubTree("1", "2", "3").Root;
            mainTree.Right = UnitTestHelpers.BuildSmallSubTree("4", "5", "6").Root;
            var subTree = UnitTestHelpers.BuildSmallSubTree("5", "6", "7").Root;
            subTree.Left = UnitTestHelpers.BuildSmallSubTree("8", "9", "10").Root;
            subTree.Right = UnitTestHelpers.BuildSmallSubTree("11", "12", "13").Root;
            var result = comparer.IsSubtree(mainTree, subTree);
            Assert.IsFalse(result);
        }

        [Test]
        public void TreeComparer_TestSubtreeAtTopOfMainTree()
        {
            var comparer = new TreeComparer();
            var mainTree = UnitTestHelpers.BuildSmallSubTree("4", "2", "5").Root;
            mainTree.Right.Left = UnitTestHelpers.BuildSmallSubTree("6", "4", "2").Root;
            mainTree.Right.Right = UnitTestHelpers.BuildSmallSubTree("8", "7", "1").Root;
            mainTree.Left.Left = UnitTestHelpers.BuildSmallSubTree("9", "9", "9").Root;
            mainTree.Left.Right = UnitTestHelpers.BuildSmallSubTree("10", "10", "10").Root;
            var subTree = UnitTestHelpers.BuildSmallSubTree("4", "2", "5").Root;
            var result = comparer.IsSubtree(mainTree, subTree);
            Assert.IsTrue(result);
        }

        [Test]
        public void TreeComparer_TestSubtreeAtBottomRightOfMainTree()
        {
            var comparer = new TreeComparer();
            var mainTree = UnitTestHelpers.BuildSmallSubTree("4", "2", "5").Root;
            mainTree.Right.Left = UnitTestHelpers.BuildSmallSubTree("6", "4", "2").Root;
            mainTree.Right.Right = UnitTestHelpers.BuildSmallSubTree("8", "7", "1").Root;
            mainTree.Left.Left = UnitTestHelpers.BuildSmallSubTree("9", "9", "9").Root;
            mainTree.Left.Right = UnitTestHelpers.BuildSmallSubTree("10", "10", "10").Root;
            var subTree = UnitTestHelpers.BuildSmallSubTree("8", "7", "1").Root;
            var result = comparer.IsSubtree(mainTree, subTree);
            Assert.IsTrue(result);
        }

        [Test]
        public void TreeComparer_TestSubtreeAtBottomLeftOfMainTree()
        {
            var comparer = new TreeComparer();
            var mainTree = UnitTestHelpers.BuildSmallSubTree("4", "2", "5").Root;
            mainTree.Right.Left = UnitTestHelpers.BuildSmallSubTree("6", "4", "2").Root;
            mainTree.Right.Right = UnitTestHelpers.BuildSmallSubTree("8", "7", "1").Root;
            mainTree.Left.Left = UnitTestHelpers.BuildSmallSubTree("9", "9", "9").Root;
            mainTree.Left.Right = UnitTestHelpers.BuildSmallSubTree("10", "10", "10").Root;
            var subTree = UnitTestHelpers.BuildSmallSubTree("9", "9", "9").Root;
            var result = comparer.IsSubtree(mainTree, subTree);
            Assert.IsTrue(result);
        }

        [Test]
        public void TreeComparer_TestSubtreeAtMiddleLeftOfMainTree()
        {
            var comparer = new TreeComparer();
            var mainTree = UnitTestHelpers.BuildSmallSubTree("4", "2", "5").Root;
            mainTree.Right.Left = UnitTestHelpers.BuildSmallSubTree("6", "4", "2").Root;
            mainTree.Right.Right = UnitTestHelpers.BuildSmallSubTree("8", "7", "1").Root;
            mainTree.Left.Left = UnitTestHelpers.BuildSmallSubTree("9", "9", "9").Root;
            mainTree.Left.Right = UnitTestHelpers.BuildSmallSubTree("10", "10", "10").Root;
            var subTree = UnitTestHelpers.BuildSmallSubTree("2", "9", "10").Root;
            subTree.Left = UnitTestHelpers.BuildSmallSubTree("9", "9", "9").Root;
            var result = comparer.IsSubtree(mainTree, subTree);
            Assert.IsTrue(result);
        }

        [Test]
        public void TreeComparer_TestSubtreeAtMiddleRightOfMainTree()
        {
            var comparer = new TreeComparer();
            var mainTree = UnitTestHelpers.BuildSmallSubTree("4", "2", "5").Root;
            mainTree.Right.Left = UnitTestHelpers.BuildSmallSubTree("6", "4", "2").Root;
            mainTree.Right.Right = UnitTestHelpers.BuildSmallSubTree("8", "7", "1").Root;
            mainTree.Left.Left = UnitTestHelpers.BuildSmallSubTree("9", "9", "9").Root;
            mainTree.Left.Right = UnitTestHelpers.BuildSmallSubTree("10", "10", "10").Root;
            var subTree = UnitTestHelpers.BuildSmallSubTree("5", "6", "8").Root;
            subTree.Right = UnitTestHelpers.BuildSmallSubTree("8", "7", "1").Root;
            var result = comparer.IsSubtree(mainTree, subTree);
            Assert.IsTrue(result);
        }

    }
}
