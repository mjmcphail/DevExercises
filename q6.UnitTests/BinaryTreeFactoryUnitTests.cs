using NUnit.Framework;
using q6.Implementations;
using q6.Interfaces;

namespace q6.UnitTests
{
    /// <summary>
    /// These tests test the creation of the 
    /// binary tree structure from string data input
    /// The BinaryTreeFactory provides the functionality
    /// to create the binary tree
    /// Various tree shapes are tested to determine if the
    /// BinaryTreeFactory is working as expected
    /// </summary>
    [TestFixture]
    public class BinaryTreeFactoryUnitTests
    {
        /// <summary>
        /// Tree shape [null]
        /// </summary>
        [Test]
        public void BinaryTreeFactory_TestCreateEmptyTree()
        {
            string data = "";
            BinaryTreeFactory btf = new BinaryTreeFactory();
            IBinaryTree<string> binaryTree = btf.Create(data);
            Assert.NotNull(binaryTree);
            Assert.IsNull(binaryTree.Root);
        }

        /// <summary>
        /// Tree shape [*] single node
        /// </summary>
        [Test]
        public void BinaryTreeFactory_TestCreateSingleNodeTree()
        {
            string data = "1";
            BinaryTreeFactory btf = new BinaryTreeFactory();
            IBinaryTree<string> binaryTree = btf.Create(data);
            Assert.NotNull(binaryTree);
            Assert.NotNull(binaryTree.Root);
            Assert.IsTrue(binaryTree.Root.Value.Equals("1"));
        }

        /// <summary>
        /// Tree shape
        ///     [4]
        ///    /   \
        ///  [2]   [5]
        /// </summary>
        [Test]
        public void BinaryTreeFactory_TestCreateSimpleTree()
        {
            string data = "4,2,5";
            BinaryTreeFactory btf = new BinaryTreeFactory();
            IBinaryTree<string> binaryTree = btf.Create(data);
            Assert.NotNull(binaryTree);
            Assert.NotNull(binaryTree.Root);
            Assert.IsTrue(binaryTree.Root.Value == "4");
            Assert.NotNull(binaryTree.Root.Left);
            Assert.IsTrue(binaryTree.Root.Left.Value == "2");
            Assert.NotNull(binaryTree.Root.Right);
            Assert.IsTrue(binaryTree.Root.Right.Value == "5");
        }

        /// <summary>
        /// Tree shape
        ///          [1]
        ///          /
        ///         [2]
        ///         /
        ///        [3]
        /// </summary>
        [Test]
        public void BinaryTreeFactory_TestCreateTreeWithOnlyLeftNodes()
        {
            string data = "1,2,,3";
            BinaryTreeFactory btf = new BinaryTreeFactory();
            IBinaryTree<string> binaryTree = btf.Create(data);
            Assert.NotNull(binaryTree);
            Assert.NotNull(binaryTree.Root);
            Assert.IsTrue(binaryTree.Root.Value == "1");
            //test left side
            Assert.IsNotNull(binaryTree.Root.Left);
            Assert.IsTrue(binaryTree.Root.Left.Value == "2");
            Assert.IsNull(binaryTree.Root.Left.Right);
            Assert.IsNotNull(binaryTree.Root.Left.Left);
            Assert.IsTrue(binaryTree.Root.Left.Left.Value == "3");
            
            //test right side
            Assert.IsNull(binaryTree.Root.Right);
        }

        /// <summary>
        /// Tree shape
        ///       [1]
        ///         \
        ///          [2]
        ///            \
        ///            [3]
        /// </summary>
        [Test]
        public void BinaryTreeFactory_TestCreateTreeWithOnlyRightNodes()
        {
            string data = "1,,2,,,,3";
            BinaryTreeFactory btf = new BinaryTreeFactory();
            IBinaryTree<string> binaryTree = btf.Create(data);
            Assert.NotNull(binaryTree);
            Assert.NotNull(binaryTree.Root);
            Assert.IsTrue(binaryTree.Root.Value == "1");
            //test left side
            Assert.IsNull(binaryTree.Root.Left);
            
            //test right side
            Assert.IsNotNull(binaryTree.Root.Right);
            Assert.IsTrue(binaryTree.Root.Right.Value == "2");
            Assert.IsNull(binaryTree.Root.Right.Left);
            Assert.IsNotNull(binaryTree.Root.Right.Right);
            Assert.IsTrue(binaryTree.Root.Right.Right.Value == "3");
        }

        /// <summary>
        /// Tree shape
        ///     [1]
        ///    /    \
        ///  [2]    [3]
        ///   \      /
        ///   [4]  [5]
        /// </summary>
        [Test]
        public void BinaryTreeFactory_TestCreateTreeDiamondShape()
        {
            string data = "1,2,3,,4,5,";
            BinaryTreeFactory btf = new BinaryTreeFactory();
            IBinaryTree<string> binaryTree = btf.Create(data);
            Assert.NotNull(binaryTree);
            Assert.NotNull(binaryTree.Root);
            Assert.IsTrue(binaryTree.Root.Value == "1");
            //test left side
            Assert.NotNull(binaryTree.Root.Left);
            Assert.IsTrue(binaryTree.Root.Left.Value == "2");
            Assert.IsNull(binaryTree.Root.Left.Left);
            Assert.IsNotNull(binaryTree.Root.Left.Right);
            Assert.IsTrue(binaryTree.Root.Left.Right.Value == "4");
            Assert.IsNull(binaryTree.Root.Left.Left);
            //test right side
            Assert.IsNotNull(binaryTree.Root.Right);
            Assert.IsTrue(binaryTree.Root.Right.Value == "3");
            Assert.IsNotNull(binaryTree.Root.Right.Left);
            Assert.IsNull(binaryTree.Root.Right.Right);
            Assert.IsTrue(binaryTree.Root.Right.Left.Value == "5");
        }

        /// <summary>
        /// Tree shape
        ///            [1]
        ///          /     \
        ///        [2]     [3]
        ///       /   \    /  \
        ///      [4]  [5] [6] [7]
        /// </summary>
        [Test]
        public void BinaryTreeFactory_TestCreateTreeFullTree()
        {
            string data = "1,2,3,4,5,6,7";
            BinaryTreeFactory btf = new BinaryTreeFactory();
            IBinaryTree<string> binaryTree = btf.Create(data);
            Assert.NotNull(binaryTree);
            Assert.NotNull(binaryTree.Root);
            Assert.IsTrue(binaryTree.Root.Value == "1");
            //test left side
            Assert.NotNull(binaryTree.Root.Left);
            Assert.IsTrue(binaryTree.Root.Left.Value == "2");
            Assert.IsNotNull(binaryTree.Root.Left.Left);
            Assert.IsTrue(binaryTree.Root.Left.Left.Value == "4");
            Assert.IsNotNull(binaryTree.Root.Left.Right);
            Assert.IsTrue(binaryTree.Root.Left.Right.Value == "5");
            
            //test right side
            Assert.IsNotNull(binaryTree.Root.Right);
            Assert.IsTrue(binaryTree.Root.Right.Value == "3");
            Assert.IsNotNull(binaryTree.Root.Right.Left);
            Assert.IsNotNull(binaryTree.Root.Right.Right);
            Assert.IsTrue(binaryTree.Root.Right.Left.Value == "6");
            Assert.IsTrue(binaryTree.Root.Right.Right.Value == "7");
        }

        /// <summary>
        /// Tree shape
        ///             [1]
        ///           /     \
        ///        [2]      [3]
        ///       /   \     /  \
        ///      [4]  []  []   [5]
        /// </summary>
        [Test]
        public void BinaryTreeFactory_TestCreateTreePyramidShape()
        {
            string data = "1,2,3,4,,,5";
            BinaryTreeFactory btf = new BinaryTreeFactory();
            IBinaryTree<string> binaryTree = btf.Create(data);
            Assert.NotNull(binaryTree);
            Assert.NotNull(binaryTree.Root);
            Assert.IsTrue(binaryTree.Root.Value == "1");
            //test left side
            Assert.NotNull(binaryTree.Root.Left);
            Assert.IsTrue(binaryTree.Root.Left.Value == "2");
            Assert.IsNotNull(binaryTree.Root.Left.Left);
            Assert.IsTrue(binaryTree.Root.Left.Left.Value == "4");
            Assert.IsNull(binaryTree.Root.Left.Right);
            //test right side
            Assert.IsNotNull(binaryTree.Root.Right);
            Assert.IsTrue(binaryTree.Root.Right.Value == "3");
            Assert.IsNull(binaryTree.Root.Right.Left);
            Assert.IsNotNull(binaryTree.Root.Right.Right);
            Assert.IsTrue(binaryTree.Root.Right.Right.Value == "5");
        }

        /// <summary>
        /// Tree shape
        ///             [1]
        ///           /     \
        ///        [5]      [4]
        ///       /   \     /  \
        ///      []  [3]  [2]   [5]
        ///                     /  \
        ///                    [0] [8]
        /// </summary>
        [Test]
        public void BinaryTreeFactory_TestCreateTreeMainTestTree()
        {
            string data = "1,5,4,,3,2,5,,,,,,,0,8";
            BinaryTreeFactory btf = new BinaryTreeFactory();
            IBinaryTree<string> binaryTree = btf.Create(data);
            Assert.NotNull(binaryTree);
            Assert.NotNull(binaryTree.Root);
            Assert.IsTrue(binaryTree.Root.Value == "1");
            //test left side
            Assert.NotNull(binaryTree.Root.Left);
            Assert.IsTrue(binaryTree.Root.Left.Value == "5");
            Assert.IsNull(binaryTree.Root.Left.Left);
            Assert.IsNotNull(binaryTree.Root.Left.Right);
            Assert.IsTrue(binaryTree.Root.Left.Right.Value == "3");
            
            //test right side
            Assert.IsNotNull(binaryTree.Root.Right);
            Assert.IsTrue(binaryTree.Root.Right.Value == "4");
            Assert.IsNotNull(binaryTree.Root.Right.Left);
            Assert.IsTrue(binaryTree.Root.Right.Left.Value == "2");
            Assert.IsNotNull(binaryTree.Root.Right.Right);
            Assert.IsTrue(binaryTree.Root.Right.Right.Value == "5");
            Assert.IsNotNull(binaryTree.Root.Right.Right.Left);
            Assert.IsTrue(binaryTree.Root.Right.Right.Left.Value == "0");
            Assert.IsNotNull(binaryTree.Root.Right.Right.Right);
            Assert.IsTrue(binaryTree.Root.Right.Right.Right.Value == "8");
        }
    }
}
