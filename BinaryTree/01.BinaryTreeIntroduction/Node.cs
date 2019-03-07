namespace _01.BinaryTreeIntroduction
{
    /// <summary>
    /// A node contains a value and pointer to left node and right node
    /// </summary>
    public class Node
    {
        private int value;
        private Node leftNode;
        private Node rightNode;

        public Node(int value, Node leftNode, Node rightNode)
        {
            // information that being stored in the tree
            // in this example, we assume that binary tree store the int value
            this.value = value;
            this.leftNode = leftNode; // left child (subtree)
            this.rightNode = rightNode; // right child (subtree)
        }

        public int GetVaue()
        {
            return value;
        }
    }
}
