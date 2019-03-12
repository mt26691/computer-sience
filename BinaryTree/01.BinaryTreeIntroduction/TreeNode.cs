namespace _01.BinaryTreeIntroduction
{
    /// <summary>
    /// A node contains a value and pointer to left node and right node
    /// </summary>
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode LeftNode;
        public TreeNode RightNode;

        public TreeNode(int value, TreeNode leftNode = null, TreeNode rightNode = null)
        {
            // information that being stored in the tree
            // in this example, we assume that binary tree store the int value
            Value = value;
            LeftNode = leftNode; // left child (subtree)
            RightNode = rightNode; // right child (subtree)
        }
        
    }
}
