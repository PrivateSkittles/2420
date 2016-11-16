using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    class Node
    {
        public int value;
        public Node left;
        public Node right;

        public Node(int initial)
        {
            value = initial; //the value passed will be the value of the node
            left = null; //nodes to the left and right of the created node start null
            right = null;
        }
    }

    class binarySearchTree
    {
        public Node top;
        string stringTraversal = "";

        public binarySearchTree()
        {
            top = null; //top of the binary tree
        }

        public binarySearchTree(int initial)
        {
            top = new Node(initial); //creates a node for the top of the tree
        }

        public void Add(int value)
        {
            AddRecursive(ref top, value); //starts recursive function at the top of the binary tree
        }

        public void AddRecursive(ref Node currentNode, int value)
        {
            if (currentNode == null) //if there is no node at the current node, creates node with the passesd in value
            {
                Node newNode = new Node(value);
                currentNode = newNode;
                return;
            }
            if (value <= currentNode.value) //if value passed in is less than the value of the current node, goes to the branch left of the current node
            {
                AddRecursive(ref currentNode.left, value);
                return;
            }
            if (value > currentNode.value) //if value passed in is greater than the value of the current node, goes to the branch right of the current node
            {
                AddRecursive(ref currentNode.right, value);
                return;
            }
        }

        public bool Contains(int value)
        {
            return ContainsRecursive(ref top, value);
        }

        public bool ContainsRecursive(ref Node currentNode, int value)
        {
            if (currentNode == null) //prints false if value is not within the tree
            {
                System.Console.WriteLine(false);
                return false;
            }
            else if (value < currentNode.value) //if value passed in is less than the value of the current node, goes to the branch left of the current node
            {
                return ContainsRecursive(ref currentNode.left, value);             
            }
            else if (value > currentNode.value) //if value passed in is greater than the value of the current node, goes to the branch right of the current node
            {
                return ContainsRecursive(ref currentNode.right, value);    
            }
            else //if value passed in is equivalent to the value passed in, prints true
            {
                System.Console.WriteLine(true);
                return true;
            }
        }

        public string traverseInOrder()
        {
            stringTraversal = "";
            inOrderRecursive(top);
            return stringTraversal;
        }

        public void inOrderRecursive(Node currentNode)
        {
            if (currentNode == null) return; //if no values, return null

            inOrderRecursive(currentNode.left); //goes recursively through the tree to print in order
            stringTraversal += currentNode.value.ToString() + " ";
            inOrderRecursive(currentNode.right);

        }

        public string traversePreOrder()
        {
            stringTraversal = "";
            preOrderRecursive(top);
            return stringTraversal;  
        }

        public void preOrderRecursive(Node currentNode)
        {
            if (currentNode == null) return;

            stringTraversal += currentNode.value.ToString() + " ";
            preOrderRecursive(currentNode.left);
            preOrderRecursive(currentNode.right);
        }

        public string traversePostOrder()
        {
            stringTraversal = "";
            postOrderRecursive(top);
            return stringTraversal;
        }

        public void postOrderRecursive(Node currentNode)
        {
            if (currentNode == null) return;

            postOrderRecursive(currentNode.left); //traverses to the very left or right before printing
            postOrderRecursive(currentNode.right);
            stringTraversal += currentNode.value.ToString() + " ";
        }
    }

    class ExpressionParser
    {
        public ExpressionNode BuildTree(string expression)
        {
            string[] splitList = expression.Split();
            Stack<ExpressionNode> operands = new Stack<ExpressionNode>();
            Stack<ExpressionNode> operators = new Stack<ExpressionNode>();
            for (int i = 0; i < splitList.Length; i++)
            {
                operands.Push(new ExpressionNode (splitList[i]));
                i++;
                if (i == splitList.Length)
                    break;
                ExpressionNode operatorTest = new ExpressionNode(splitList[i]);
                if (operators.Count == 0)
                    operators.Push(operatorTest);
                else
                {
                    ExpressionNode operatorPeek = operators.Peek();
                    if (operatorTest.value == "*" || operatorTest.value == "/")
                    {
                        if (operatorPeek.value == "*" || operatorPeek.value == "/")
                        {
                            while (operators.Peek() != null)
                            {
                                ExpressionNode parentNode = operators.Pop();
                                parentNode.right = operands.Pop();
                                parentNode.left = operands.Pop();
                                operands.Push(parentNode);
                            }
                        }
                        else
                            operators.Push(operatorTest);
                    }
                    else
                    {
                        while (operators.Count > 0)
                        {
                            ExpressionNode parentNode = operators.Pop();
                            parentNode.right = operands.Pop();
                            parentNode.left = operands.Pop();
                            operands.Push(parentNode);
                        }
                        operators.Push(operatorTest);
                    }     
                }
            }
            while (operators.Count > 0)
            {
                ExpressionNode parentNode = operators.Pop();
                parentNode.right = operands.Pop();
                parentNode.left = operands.Pop();
                operands.Push(parentNode);
            }
            return operands.Pop();
        }
    }

    class ExpressionNode
    {
        public string value;
        public ExpressionNode left;
        public ExpressionNode right;

        public ExpressionNode(string initial)
        {
            value = initial;
            left = null;
            right = null;
        }
    }

    class ExpressionTree
    {
        public ExpressionTree(ExpressionNode node)
        {
            root = node;
            top = node;
        }
        public ExpressionNode root { get; set; }

        public ExpressionNode top;
        string stringTraversal = "";
 
        public string Calculate(string leftNode, string rightNode, string currentNode)
        {
            int left = Int32.Parse(leftNode);
            int right = Int32.Parse(rightNode);

            if (currentNode == "*")
                return ((left * right).ToString());

            if (currentNode == "/")
                return ((left / right).ToString());

            if (currentNode == "+")
                return ((left + right).ToString());

            if (currentNode == "-")
                return ((left - right).ToString());

            else
                return "Error";
        }

        public int EvaluateRecursive()
        {
            string evaluatedTree = Evaluate(ref top);
            int evaluatedTreeInt = Int32.Parse(evaluatedTree);
            return evaluatedTreeInt;
        }

        public string Evaluate(ref ExpressionNode currentNode)
        {
            if (currentNode != null)
            {
                if (currentNode.value != "+" &&
                    currentNode.value != "-" &&
                    currentNode.value != "*" &&
                    currentNode.value != "/")
                    return currentNode.value;
            }
                    string left = Evaluate(ref currentNode.left);
                    string right = Evaluate(ref currentNode.right);
                    return Calculate(left, right, currentNode.value);
        }

        public string traverseInOrder()
        {
            stringTraversal = "";
            inOrderRecursive(root);
            return stringTraversal;
        }

        public void inOrderRecursive(ExpressionNode currentNode)
        {
            if (currentNode == null) return; //if no values, return null

            inOrderRecursive(currentNode.left); //goes recursively through the tree to print in order
            stringTraversal += currentNode.value.ToString() + " ";
            inOrderRecursive(currentNode.right);

        }

        public string traversePreOrder()
        {
            stringTraversal = "";
            preOrderRecursive(root);
            return stringTraversal;
        }

        public void preOrderRecursive(ExpressionNode currentNode)
        {
            if (currentNode == null) return;

            stringTraversal += currentNode.value.ToString() + " ";
            preOrderRecursive(currentNode.left);
            preOrderRecursive(currentNode.right);
        }

        public string traversePostOrder()
        {
            stringTraversal = "";
            postOrderRecursive(root);
            return stringTraversal;
        }

        public void postOrderRecursive(ExpressionNode currentNode)
        {
            if (currentNode == null) return;

            postOrderRecursive(currentNode.left); //traverses to the very left or right before printing
            postOrderRecursive(currentNode.right);
            stringTraversal += currentNode.value.ToString() + " ";
        }
    }


    static void Main()
    {
        binarySearchTree binaryTree = new binarySearchTree(5);
        binaryTree.Add(4);
        binaryTree.Add(24);
        binaryTree.Add(72);
        binaryTree.Add(12);
        binaryTree.Add(-4);
        binaryTree.Add(8);
        binaryTree.Add(5);
        binaryTree.Add(7);
        binaryTree.Add(10);
        binaryTree.Add(24);

        System.Console.WriteLine("In Order Traversal");
        Console.WriteLine(binaryTree.traverseInOrder());
        Debug.Assert(binaryTree.traverseInOrder() == "-4 4 5 5 7 8 10 12 24 24 72 ");
        System.Console.WriteLine();

        System.Console.WriteLine("Pre Order Traversal");
        Console.WriteLine(binaryTree.traversePreOrder());
        Debug.Assert(binaryTree.traversePreOrder() == "5 4 -4 5 24 12 8 7 10 24 72 ");
        System.Console.WriteLine();

        System.Console.WriteLine("Post Order Traversal");
        Console.WriteLine(binaryTree.traversePostOrder());
        Debug.Assert(binaryTree.traversePostOrder() == "-4 5 4 7 10 8 24 12 72 24 5 ");
        System.Console.WriteLine();

        System.Console.WriteLine("binaryTree contains value 7: ");
        Debug.Assert(binaryTree.Contains(7) == true);
        System.Console.WriteLine();

        System.Console.WriteLine("binaryTree contains value 30: ");
        Debug.Assert(binaryTree.Contains(30) == false);
        System.Console.WriteLine();

        ExpressionParser expressionParser = new ExpressionParser();
        ExpressionTree expressionTree = new ExpressionTree(expressionParser.BuildTree("5 + 2 * 8 - 6 / 4"));

        System.Console.WriteLine("Expression Parser In Order Traversal");
        Console.WriteLine(expressionTree.traverseInOrder());
        Debug.Assert(expressionTree.traverseInOrder() == "5 + 2 * 8 - 6 / 4 ");
        System.Console.WriteLine();

        System.Console.WriteLine("Expression Parser Pre Order Traversal");
        Console.WriteLine(expressionTree.traversePreOrder());
        Debug.Assert(expressionTree.traversePreOrder() == "- + 5 * 2 8 / 6 4 ");
        System.Console.WriteLine();

        System.Console.WriteLine("Expression Parser Post Order Traversal");
        Console.WriteLine(expressionTree.traversePostOrder());
        Debug.Assert(expressionTree.traversePostOrder() == "5 2 8 * + 6 4 / - ");
        System.Console.WriteLine();

        Console.WriteLine("Expression Tree Evaluated");
        Console.WriteLine(expressionTree.EvaluateRecursive());
        Debug.Assert(expressionTree.EvaluateRecursive() == (5 + 2 * 8 - 6 / 4));
        Console.WriteLine();

        ///               binaryTree
        ///                    5
        ///                  /   \
        ///                 /     \
        ///                4      24         
        ///               / \    /  \
        ///             -4   5  12   72
        ///                    /  \
        ///                   8   20
        ///                  / \                 
        ///                 7  10
    }

}

