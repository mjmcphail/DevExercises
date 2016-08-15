using q6.Interfaces;

namespace q6.Implementations
{
    /// <summary>
    /// Standard Binary Tree node
    /// - it is a generic node for reusability
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTreeNode<T> : IBinaryTreeNode<T>
    {
        public T Value { get; set; }
        public IBinaryTreeNode<T> Left { get; set; }
        public IBinaryTreeNode<T> Right { get; set; }
    }
}
