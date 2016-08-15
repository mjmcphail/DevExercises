using System;
using q6.Interfaces;

namespace q6.Implementations
{
    /// <summary>
    /// This class takes an input string in a specific format
    /// comma separated integers and builds a Binary Tree from the data
    /// Since the input data is ints, this factory is not generic and 
    /// builds an integer binary tree.
    /// Ideally this class could be made as a generic
    /// however data typing issues between primitive and reference
    /// types come into play.
    /// </summary>
    public class BinaryTreeFactory : IBinaryTreeFactory
    {
        /// <summary>
        /// Create a new binary tree from the string data provided
        /// </summary>
        /// <param name="treeDataString">String of comma separated integers</param>
        /// <returns>The tree</returns>
        public IBinaryTree<string> Create(string treeDataString)
        {
            var treeData = treeDataString.Split(',');
            return BuildTree(treeData);
        }

        /// <summary>
        /// Builds a tree given an array of strings
        /// </summary>
        /// <param name="treeData">Array of string items each item considered a node</param>
        /// <returns>A new binary tree</returns>
        private static IBinaryTree<string> BuildTree(string[] treeData)
        {
            var tree = new BinaryTree<string>();
            tree.Root = CreateChildNodes(tree.Root, treeData, 0);
            return tree;
        }

        /// <summary>
        /// Create binary tree child nodes
        /// use some math to calculate
        /// what left and right position in the 
        /// array to go to get the next child location
        /// </summary> 
        /// <param name="node">Node to create children for</param>
        /// <param name="data">array of all tree nodes</param>
        /// <param name="position">array position to get node data</param>
        /// <returns></returns>
        private static IBinaryTreeNode<string> CreateChildNodes(IBinaryTreeNode<string> node, string[] data, int position)
        {
            if (position >= data.Length) return null;
            if (string.IsNullOrEmpty(data[position])) return null;
            if (node == null)
                node = new BinaryTreeNode<string> { Value = data[position] };
            var leftPosition = 2 * position + 1;
            var rightPosition = 2 * position + 2;
            node.Left = CreateChildNodes(node.Left, data, leftPosition);
            node.Right = CreateChildNodes(node.Right, data, rightPosition);
            return node;
        }
    }
}
