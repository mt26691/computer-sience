namespace _02.AVLTree
{
    public class AVLTree
    {
        public Node Root { get; set; }

        public AVLTree()
        {

        }

        /// <summary>
        /// Insert Node into the AVL tree
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Insert(string key, int value)
        {
            if (Root == null)
            {
                Root = new Node { Key = key, Value = value };
                return;
            }
            var node = Root;

            while (node != null)
            {
                if (value < node.Value)
                {
                    var left = node.Left;
                    // add new node into left of the current node
                    if (node.Left == null)
                    {
                        node.Left = new Node { Key = key, Value = value, Parent = node };
                        // InsertBalance(node, 1);
                        return;
                    }
                    else
                    {
                        node = left;
                    }
                }
                // new value is bigger than current value, add to right of the node
                else if (value > node.Value)
                {
                    var right = node.Right;
                    if (node.Right == null)
                    {
                        node.Right = new Node { Key = key, Value = value, Parent = node };
                        // InsertBalance(node, -1);
                        return;
                    }
                    else
                    {
                        node = right;
                    }
                }
                else
                {
                    // duplicate value, do nothing
                    node.Value = value;
                    return;
                }
            }
        }

        private void InsertBalance(Node node, int balance)
        {
            while (node != null)
            {
                balance = node.Balance += balance;

                if (balance == 0)
                {
                    return;
                }
                if (balance == 2)
                {
                    // left left case
                    if (node.Left.Balance == 1)
                    {
                        // rotate right
                    }
                    else
                    {
                        // node balance == -1
                        // rotate left and right
                        //  node = RotateLeftRight(node);
                    }
                }
                else if (balance == -2)
                {
                    // right and right case
                    if (node.Right.Balance == -1)
                    {
                        // rotate left
                        //   RotateLeft(node);
                    }
                    // node.right.Balance == 1
                    else
                    {
                        // rorate right left
                    }
                    return;
                }

                var parent = node.Parent;
                if (parent != null)
                {
                    balance = parent.Left == node ? 1 : -1;
                }
                node = parent;
            }
        }

        private Node RotateLeft(Node node)
        {
            var right = node.Right;
            var rightLeft = right.Left;
            var parent = node.Parent;

            right.Parent = parent;
            right.Left = node;
            node.Right = rightLeft;
            node.Parent = right;

            if (rightLeft != null)
            {
                rightLeft.Parent = node;
            }
            if (node == Root)
            {
                Root = right;
            }
            else if (parent.Right == node)
            {
                parent.Right = right;
            }
            else
            {
                parent.Left = right;
            }
            right.Balance++;
            node.Balance = -right.Balance;

            return right;
        }

        private Node RotateRight(Node node)
        {
            var left = node.Left;
            var leftRight = left.Right;
            var parent = node.Parent;


            left.Parent = parent;
            left.Right = node;
            node.Parent = left;
            node.Left = leftRight;

            if (leftRight != null)
            {
                leftRight.Parent = node;
            }
            if (node == Root)
            {
                //switch root
                Root = left;
            }
            else if(parent.Left == node)
            {
                parent.Left = left;
            }
            else
            {
                parent.Right = left;
            }

            left.Balance--;
            node.Balance = -left.Balance;
            return left;
        }

        private Node RotateLeftRight(Node node)
        {
            var left = node.Left;
            var leftRight = left.Right;
            var parent = node.Parent;
            var leftRightRight = leftRight.Right;
            var leftRightLeft = leftRight.Left;

            leftRight.Parent = parent;
            node.Left = leftRightRight;
            left.Right = leftRightLeft;
            leftRight.Left = left;
            leftRight.Right = node;
            left.Parent = leftRight;
            node.Parent = leftRight;

            if(leftRightRight != null)
            {
                leftRightRight.Parent = node;
            }
            if(leftRightLeft != null)
            {
                leftRightLeft.Parent = left;
            }

            if(node == Root)
            {
                Root = leftRight;
            }
            else if(parent.Left == node)
            {
                parent.Left = leftRight;
            }
            else
            {
                parent.Right = leftRight;
            }
            
            if(leftRight.Balance == -1)
            {
                node.Balance = 1;
                left.Balance = 0;
            }
            else if(leftRight.Balance ==0)
            {
                if (leftRightRight != null)
                {
                    node.Balance = 1;
                }
                else
                {
                    node.Balance = 0;
                }

                if (leftRightLeft != null)
                {
                    left.Balance = -1;
                }
                else
                {
                    left.Balance = 0;
                }
            }
            else
            {
                node.Balance = 0;
                left.Balance = -1;
            }
            leftRight.Balance = 0;
            return leftRight;
        }
    }
}
