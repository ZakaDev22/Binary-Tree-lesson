using System;
using System.Collections.Generic;

namespace Binary_Tree
{
    public class Program
    {
        public class BinaryTreeNode<T>
        {
            public T value;
            public BinaryTreeNode<T> Left;
            public BinaryTreeNode<T> Right;


            public BinaryTreeNode(T valaue)
            {
                value = valaue;
                Left = null;
                Right = null;
            }
        }

        public class BinaryTree<T>
        {
            public BinaryTreeNode<T> Root;

            public BinaryTree()
            {
                Root = null;
            }

            public void Insert(T value)
            {
                /*
                    We use Level-order insertion strategy,
                    Level-order insertion: in a binary tree is a strategy that fills the tree level by level, 
                    from left to right. This approach ensures that every level of the tree is completely 
                    filled before any nodes are added to a new level, 
                    and each parent node has at most two children before moving on to the next node in the 
                    sequence.
                  
                 */

                BinaryTreeNode<T> InsertedNode = new BinaryTreeNode<T>(value);

                if (Root == null)
                {
                    Root = InsertedNode;
                    return;
                }


                Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
                queue.Enqueue(Root);

                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();

                    if (current.Left == null)
                    {
                        current.Left = InsertedNode;
                        break;
                    }
                    else
                    {
                        queue.Enqueue(current.Left);
                    }

                    if (current.Right == null)
                    {
                        current.Right = InsertedNode;
                        break;
                    }
                    else
                    {
                        queue.Enqueue(current.Right);
                    }
                }
            }

            public void Print()
            {
                PrintTree(Root);
            }

            private void PrintTree(BinaryTreeNode<T> root, int space = 0)
            {
                int COUNT = 10;  // Distance between levels to adjust the visual representation
                if (root == null)
                    return;


                space += COUNT;
                PrintTree(root.Right, space); // Print right subtree first, then root, and left subtree last

                Console.WriteLine();
                for (int i = COUNT; i < space; i++)
                    Console.Write(" ");

                Console.WriteLine(root.value); // Print the current node after space


                PrintTree(root.Left, space); // Recur on the left child
            }

            private void PreOrderTraversal(BinaryTreeNode<T> node)
            {
                /*
                  PreOrder Traversal visits the current node before its child nodes. 
                  The process for PreOrder Traversal is as follows:


                     - Visit the current node.
                     - Recursively perform PreOrder Traversal of the left subtree.
                     - Recursively perform PreOrder Traversal of the right subtree.
                */


                if (node != null)
                {
                    Console.Write(node.value + " ");
                    PreOrderTraversal(node.Left);
                    PreOrderTraversal(node.Right);
                }
            }


            public void PreOrderTraversal()
            {
                PreOrderTraversal(Root);
                Console.WriteLine();
            }

            private void PostOrderTraversal(BinaryTreeNode<T> node)
            {

                /*
                  PostOrder Traversal visits the current node after its child nodes. 
                  The process for PostOrder Traversal is:


                    - Recursively perform PostOrder Traversal of the left subtree.
                    - Recursively perform PostOrder Traversal of the right subtree.
                    - Visit the current node.
               */


                if (node != null)
                {
                    PostOrderTraversal(node.Left);
                    PostOrderTraversal(node.Right);
                    Console.Write(node.value + " ");
                }
            }


            public void PostOrderTraversal()
            {
                PostOrderTraversal(Root);
                Console.WriteLine();
            }

            public void InOrderTraversal()
            {
                InOrderTraversal(Root);
                Console.WriteLine();
            }


            private void InOrderTraversal(BinaryTreeNode<T> node)
            {

                /*
                  Left - Current - Right
                 */
                if (node != null)
                {
                    InOrderTraversal(node.Left);
                    Console.Write(node.value + " ");
                    InOrderTraversal(node.Right);
                }
            }

        }

        static void Main(string[] args)
        {
            BinaryTree<int> Binarytree = new BinaryTree<int>();

            //Binarytree.Insert(1);
            //Binarytree.Insert(2);
            //Binarytree.Insert(3);
            //Binarytree.Insert(4);
            //Binarytree.Insert(5);
            //Binarytree.Insert(6);
            //Binarytree.Insert(7);
            //Binarytree.Insert(8);
            //Binarytree.Insert(9);
            //Binarytree.Insert(10);
            //Binarytree.Insert(11);
            //Binarytree.Insert(12);
            //Binarytree.Insert(13);
            //Binarytree.Insert(14);
            //Binarytree.Insert(15);


            Binarytree.Insert(5);
            Binarytree.Insert(3);
            Binarytree.Insert(8);
            Binarytree.Insert(1);
            Binarytree.Insert(4);
            Binarytree.Insert(6);
            Binarytree.Insert(9);

            Binarytree.Print();

            Console.WriteLine("\nPreOrder Traversal (Current-Left SubTree - Right SubTree):");
            Binarytree.PreOrderTraversal();


            Console.WriteLine("\nPostorder Traversal (Left SubTree - Right SubTree - Current):");
            Binarytree.PostOrderTraversal();

            Console.WriteLine("\nInorder Traversal: Left-Current-Right");
            Binarytree.InOrderTraversal();

            Console.ReadKey();
        }
    }
}
