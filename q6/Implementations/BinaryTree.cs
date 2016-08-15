using q6.Interfaces;

namespace q6.Implementations
{
    /// <summary>
    /// Standard binary tree
    /// - this class might be redundant but 
    /// for future modifications wrapping the node
    /// is not necessarily a bad idea
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T> : IBinaryTree<T>
    {
        public IBinaryTreeNode<T> Root { get; set; }

        public BinaryTree()
        {
            Root = null;
        }
    }
}
