using System;

/**
 * June 30, 2020
 * @author Stephen Benedict
 */

/** Visual studio suggested to me that the common practice
 * in C# is to capitalize the first letter in a method name,
 * which seems to be the opposite of what I have been told is
 * the case with Java.  This seems strange to me, but I have 
 * played along for now.
 */

namespace IntBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate three IntTreeNode objects with data
            var five = new IntTreeNode(5);
            var seven = new IntTreeNode(7);
            var three = new IntTreeNode(3);

            //Instantiate an IntTree Object with the first
            //IntTreeNode as the root
            var tree = new IntTree(five);
            
            //Add the three IntTreeNode to the tree
            tree.AddNode(three);
            
            //Add the seven IntTreeNode to the tree
            tree.AddNode(seven);

            //Instanstiate another IntTreeNode object and
            // add it to the tree
            var six = new IntTreeNode(6);
            tree.AddNode(six);

            //Instanstiate another IntTreeNode object and
            // add it to the tree
            var negative_five = new IntTreeNode(-5);
            tree.AddNode(negative_five);

            //Instanstiate another IntTreeNode object and
            // add it to the tree
            var twenty_six = new IntTreeNode(26);
            tree.AddNode(twenty_six);
            //Print the tree to check that it indeed has added the nodes
            //The tree should print each node in an inorder traversal
            //order
            tree.PrintTree();

            // All of these next lines should return and print true
            Console.WriteLine(tree.Contains(5));
            Console.WriteLine(tree.Contains(3));
            Console.WriteLine(tree.Contains(7));
            Console.WriteLine(tree.Contains(6));
            Console.WriteLine(tree.Contains(-5));
            Console.WriteLine(tree.Contains(26));
            
            //This line should return and print false, as a node
            //containing 4 has not yet been added
            Console.WriteLine(tree.Contains(4));

            //Instanstiate another IntTreeNode object and
            // add it to the tree
            var four = new IntTreeNode(4);
            tree.AddNode(four);

            //Now that a node containing 4 as its data has been added
            //this line should return and print true
            Console.WriteLine(tree.Contains(4));
        }
    }
}
