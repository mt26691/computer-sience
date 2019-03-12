using System;
using System.Collections.Generic;
using System.Text;

namespace _01.BinaryTreeIntroduction
{
    public class BinaryTree
    {
        private TreeNode root;     // Points to the root of the tree
        private int count;

        /// <summary>
        /// Constructor for creating Binary tree
        /// </summary>
        public BinaryTree()
        {
            root = null;
            count = 0;
        }

        /// <summary>
        /// Total number of nodes in the tree
        /// </summary>
        /// <returns>Total number of nodes</returns>
        public int Count()
        {
            return count;
        }

        public TreeNode Insert(int value)
        {
            var node = new TreeNode(value);
            if(root == null)
            {
                root = node;
            }
            else
            {
                Add(node, ref root);
            }
            count++;
            return node;
        }

        private void Add(TreeNode newNode, ref TreeNode tree)
        {
            if(tree == null)
            {
                tree = newNode;
                return;
            }
            if(newNode.Value< tree.Value)
            {
                Add(newNode, ref tree.LeftNode);
            }
            else
            {
                Add(newNode, ref tree.RightNode);
            }
        }

        public string DrawTree()
        {
            return DrawNode(root);
        }

        public string DrawNode(TreeNode node)
        {
            if(node == null)
            {
                return "Empty";
            }
            if(node.LeftNode == null && node.RightNode == null)
            {
                return node.Value.ToString();
            }
            if(node.LeftNode != null && node.RightNode == null)
            {
                return node.Value.ToString() + "(" + DrawNode(node.LeftNode) + ", _)";
            }
            if (node.LeftNode == null && node.RightNode != null)
            {
                return node.Value.ToString() + "(" + DrawNode(node.RightNode) + ", _)";
            }

            return node.Value.ToString() + "(" + DrawNode(node.LeftNode) + ", " + DrawNode(node.RightNode) + ")";
        }
    }
}
