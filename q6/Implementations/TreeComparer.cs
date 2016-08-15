using q6.Interfaces;

namespace q6.Implementations
{
    /// <summary>
    /// TreeComparer class 
    /// this class provides one public method
    /// which takes two BinaryTreeNodes and will determine
    /// if the subTree exists within the mainTree
    /// - EXACT subTree structure match is not performed
    /// per the instructions.  The example problem shows a subtree
    /// with no child nodes on the bottom right of the tree, yet
    /// the example claims the smaller tree is a subtree even though
    /// the main tree has the subnodes on the bottom right.
    /// The key to this working is that the subtree dictates the search
    /// and if all subtree nodes have been visited and matched in the 
    /// main tree then a subtree match has occurred
    /// Also note - this search could be done non-recursively with a Queue 
    /// and be much more efficient.
    /// </summary>
    public class TreeComparer : ITreeComparer
    {
        /// <summary>
        /// Main entry for tree comparison
        /// </summary>
        /// <param name="mainTree">Main tree to compare against</param>
        /// <param name="subTree">Subtree to find within the main tree</param>
        /// <returns></returns>
        public bool IsSubtree(IBinaryTreeNode<string> mainTree, IBinaryTreeNode<string> subTree)
        {
            //if subtree is null - match even if mainTree is null
            //because null is subtree of any populated or empty tree
            if (subTree == null)
                return true;

            //if subtree not null but main tree is null return false - no match
            if (mainTree == null)
                return false;

            //if the value of main and subtree nodes match then compare both
            //left and right sides of each
            if (mainTree.Value.Equals(subTree.Value))
            {
                return (CompareTrees(mainTree.Left, subTree.Left) && CompareTrees(mainTree.Right, subTree.Right));
            }

            //if main tree and subtrees do not match then we have to 
            //see if the subtree is a match on the left or right side of the main tree - recurse
            return IsSubtree(mainTree.Left, subTree) || IsSubtree(mainTree.Right, subTree);
        }

        /// <summary>
        /// This function actually compares the 
        /// main tree to the sub tree and recurses 
        /// through the tree structure as needed
        /// </summary>
        /// <param name="mainTree">Main tree structure</param>
        /// <param name="subTree">Subtree to find in the main tree</param>
        /// <returns></returns>
        private bool CompareTrees(IBinaryTreeNode<string> mainTree, IBinaryTreeNode<string> subTree)
        {
            //if subtree is null return true - same condition as above
            if (subTree == null)
                return true;

            //if maintree is null return false - same condition as above
            if (mainTree == null)
                return false;

            //if the tree node values match then 
            //compare to see if the left and right nodes of the subtree are null
            //this is what provides the non-exact tree structure match
            if (mainTree.Value.Equals(subTree.Value))
                if ((subTree.Left == null) && (subTree.Right == null))
                    return true;
                else
                    //values match but subtree has more nodes to check so check left and right sides of the subtree
                    //against the corresponding left and right sides of the main tree
                    return CompareTrees(mainTree.Left, subTree.Left) && CompareTrees(mainTree.Right, subTree.Right);

            //if the values dont match return false
            return false;
        }
    }
}
