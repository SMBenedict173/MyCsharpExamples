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

public class IntTree
{
    //The first node, or root, of the tree
	private readonly IntTreeNode firstNode;

	//Constructor which sets the root to the supplied node
    public IntTree(IntTreeNode treeTop)
	{
        firstNode = treeTop;
		
	}

	//Returns the first node, or root
	public IntTreeNode GetFirstNode()
	{
		return firstNode;
	}

	/**Adds a node to the tree
	*The placement is determined by comparing the value of the data contained 
	*within the node with those already in the tree
	*If the node is less than or equal to a node that is already a part of the
	*tree, then it is placed as the left child of the node which is already
	*member unless that node already has a left child, in which case the
	*process is repeated with that left child.
	*If the node is greater than a node that is already a member, then it is 
	*placed as the right child of the member unless that member already has 
	*a right child, in which case the process is repeated with that right child.
	*/
	public void AddNode(IntTreeNode newNode)
    {
		//Instantiates an InorderIterator object for this tree
		InorderIterator theIterator = new InorderIterator(this);
		//Sets the node to be compared with the node being added
		//At this point in the process, this should be the leftmost
		//child in the tree
		IntTreeNode comparedNode = theIterator.Next();
		//If the node to be added is less than or equal to the leftmost
		//node, than it is set as its child and becomes the leftmost node
		if (comparedNode.CompareNodeGreater(newNode))
        {
			comparedNode.SetLeft_node(newNode);
        }
		else
		//If the node to be added is greater, than this loop is started
        {
			//This loop continues comparing the new node to the next node,
			//which is the next node following an inorder tree traversal,
			//until it reaches a node that the new node is less than or equal
			//to or reaches the rightmost child of the tree
			while (!comparedNode.CompareNodeGreater(newNode))
            {
				IntTreeNode nullPossibility = theIterator.Next();
				if (nullPossibility == null)
                {
					break;
                }
                else
                {
					comparedNode = nullPossibility;
                }
            }
			//If the new node is less than the node found in the loop, then
			//it is set as its left child
			if (comparedNode.CompareNodeGreater(newNode))
            {
				comparedNode.SetLeft_node(newNode);
            }
			//If the new node is greater than the node found in the loop,
			// then it is set as its right child
			else
            {
				comparedNode.SetRight_node(newNode);
            }

        }

	}
	//Prints out each node data in an inorder traversal
	public void PrintTree() 
	{
		InorderIterator theIterator = new InorderIterator(this);
		IntTreeNode printedNode;
		printedNode = theIterator.Next();
		Console.WriteLine(printedNode.GetData());
		while (theIterator.HasNext() || printedNode.HasRight_Child())
		{
			try
            {
				printedNode = theIterator.Next();
				Console.WriteLine(printedNode.GetData());
			}
			catch (NullReferenceException)
            {
				break;
            }
			
        }

	}

	/** Searches through the tree for the specified integer in
	 * log base 2 n time
	 * This is accomplished by comparing the integer to the data within
	 * the nodes to determine which node should be the next to be compared.
	 * If the integer is less the member, then its left child is compared.
	 * If the integer is greater than the member, then its right child is
	 * compared.  This cuts the number of comparisons in half each time as 
	 * only one child is considered for the next comparison.
	 * This continues until a node containing that integer is 
	 * found or the bottom of the tree is reached.
	 */
	public bool Contains(int number)
    {
		//The first comparison is the root of the tree
		IntTreeNode comparedNode = GetFirstNode();
		//The integer is placed within an IntTreeNode object
		IntTreeNode numberNode = new IntTreeNode(number);
		bool result = false;
		//This loop continues until the node containing an equivalent
		//integer is found or the bottom is reached
		while (comparedNode != null)
        {
			//If the equivalent node is found, the result is set to true
			//and the loop breaks
			if (comparedNode.GetData() == numberNode.GetData())
            {
				result = true;
				break;
            }
			//If the integer was less than the node's data, then the left
			//child is set to be compared next
			else if (comparedNode.CompareNodeGreater(numberNode))
            {
				comparedNode = comparedNode.GetLeft_node();
            }
			//If the integer was greater than the node's data, then the
			//right child is set to be compared next
            else
            {
				comparedNode = comparedNode.GetRight_node();
            }
        }
		//By this point the loop either was broken and the result set to true
		//or the loop completed and the result remained set to false
		return result;
	}
		
	
}

