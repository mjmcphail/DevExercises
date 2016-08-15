using q6.Implementations;
using q6.Interfaces;

namespace q6.UnitTests
{
    /// <summary>
    /// This class is a helper class which
    /// contains static methods to build tree structures
    /// These methods are called in different unit tests to 
    /// build up test tree structures for different cases
    /// </summary>
    class UnitTestHelpers
    {
        /// <summary>
        /// Builds a main tree structure with sample data provided
        /// </summary>
        /// <returns></returns>
        public static IBinaryTree<string> BuildMainTree()
        {
            var mainTree = new BinaryTree<string>
            {
                Root = new BinaryTreeNode<string>
                {
                    Value = "1",
                    Left = new BinaryTreeNode<string> { Value = "5" },
                    Right = new BinaryTreeNode<string> { Value = "4" }
                }
            };
            mainTree.Root.Left.Left = null;
            mainTree.Root.Left.Right = new BinaryTreeNode<string> { Value = "3" };
            mainTree.Root.Right.Left = new BinaryTreeNode<string> { Value = "2" };
            mainTree.Root.Right.Right = new BinaryTreeNode<string> { Value = "5" };
            mainTree.Root.Right.Left = new BinaryTreeNode<string> { Value = "0" };
            mainTree.Root.Right.Right = new BinaryTreeNode<string> { Value = "8" };
            return mainTree;
        }

        /// <summary>
        /// Builds up a small tree with a root and 2 child nodes
        /// </summary>
        /// <param name="root">Value for the root</param>
        /// <param name="left">Value for the left node</param>
        /// <param name="right">Value for the right node</param>
        /// <returns></returns>
        public static IBinaryTree<string> BuildSmallSubTree(string root, string left, string right)
        {
            var subTree = new BinaryTree<string>
            {
                Root = new BinaryTreeNode<string>
                {
                    Value = root,
                    Left = new BinaryTreeNode<string> { Value = left },
                    Right = new BinaryTreeNode<string> { Value = right }
                }
            };
            return subTree;
        }

        /// <summary>
        /// Builds a main tree structure with alternative sample data provided
        /// </summary>
        /// <returns></returns>
        public static IBinaryTree<string> BuildOtherMainTree()
        {
            var mainTree = new BinaryTree<string>
            {
                Root = new BinaryTreeNode<string>
                {
                    Value = "1",
                    Left = new BinaryTreeNode<string> { Value = "5" },
                    Right = new BinaryTreeNode<string> { Value = "4" }
                }
            };
            mainTree.Root.Left.Left = null;
            mainTree.Root.Left.Right = new BinaryTreeNode<string> { Value = "3" };
            mainTree.Root.Right.Left = new BinaryTreeNode<string> { Value = "2" };
            mainTree.Root.Right.Right = new BinaryTreeNode<string> { Value = "9" };
            mainTree.Root.Right.Left = new BinaryTreeNode<string> { Value = "0" };
            mainTree.Root.Right.Right = new BinaryTreeNode<string> { Value = "8" };
            return mainTree;
        }
    

    }
}
