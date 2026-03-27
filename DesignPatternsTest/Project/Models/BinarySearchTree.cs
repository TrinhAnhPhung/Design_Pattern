// BinarySearchTree.cs - Prototype Pattern
using System;

namespace NOPKIEMTRA.Project.Models
{
    public class BinarySearchTree
    {
        // Inner class Node với Prototype Pattern
        public class Node : ICloneable
        {
            public int key;
            public Node left, right;

            public Node(int item)
            {
                key = item;
                left = right = null;
            }

            // Prototype Pattern - Clone node
            public object Clone()
            {
                Node newNode = new Node(this.key);
                newNode.left = this.left != null ? (Node)this.left.Clone() : null;
                newNode.right = this.right != null ? (Node)this.right.Clone() : null;
                return newNode;
            }
        }

        private Node root;

        public BinarySearchTree()
        {
            root = null;
        }

        // Insert node vào tree
        public void Insert(int item)
        {
            root = InsertRec(root, item);
        }

        private Node InsertRec(Node node, int key)
        {
            if (node == null)
            {
                return new Node(key);
            }

            if (key < node.key)
            {
                node.left = InsertRec(node.left, key);
            }
            else if (key > node.key)
            {
                node.right = InsertRec(node.right, key);
            }

            return node;
        }

        // Search node
        public bool Search(int key)
        {
            return SearchRec(root, key);
        }

        private bool SearchRec(Node node, int key)
        {
            if (node == null)
            {
                return false;
            }

            if (key == node.key)
            {
                return true;
            }
            else if (key < node.key)
            {
                return SearchRec(node.left, key);
            }
            else
            {
                return SearchRec(node.right, key);
            }
        }

        // Inorder traversal (trái - gốc - phải)
        public void Inorder()
        {
            Console.Write("Inorder: ");
            InorderRec(root);
            Console.WriteLine();
        }

        private void InorderRec(Node node)
        {
            if (node != null)
            {
                InorderRec(node.left);
                Console.Write(node.key + " ");
                InorderRec(node.right);
            }
        }

        // Clone toàn bộ tree
        public BinarySearchTree CloneTree()
        {
            BinarySearchTree newTree = new BinarySearchTree();
            newTree.root = root != null ? (Node)root.Clone() : null;
            return newTree;
        }

        // Display tree structure
        public void Display()
        {
            Console.WriteLine("Tree structure:");
            DisplayRec(root, "", true);
        }

        private void DisplayRec(Node node, string indent, bool last)
        {
            if (node != null)
            {
                Console.Write(indent);
                if (last)
                {
                    Console.Write("└─");
                    indent += "  ";
                }
                else
                {
                    Console.Write("├─");
                    indent += "│ ";
                }
                Console.WriteLine(node.key);

                DisplayRec(node.left, indent, false);
                DisplayRec(node.right, indent, true);
            }
        }
    }
}