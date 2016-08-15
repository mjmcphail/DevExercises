namespace q6.Interfaces
{
    public interface ITreeComparer
    {
        bool IsSubtree(IBinaryTreeNode<string> mainTree, IBinaryTreeNode<string> subTree);
    }
}
