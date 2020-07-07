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

public class InorderIterator
{
	//The stack being used to aid in performing the traversal
	private NodeStack TheStack;
	//The node being called into question 
	private IntTreeNode CurrentNode;
	//The IntTree for which this iterator is being used
	private IntTree Iterated;
	
	//Default Constructor
	public InorderIterator()
	{
		TheStack = new NodeStack();
		CurrentNode = null;
		Iterated = null;
	}

	//Constructor that handles when an IntTree is specified
	public InorderIterator(IntTree toBeIterated)
    {
		Iterated = toBeIterated;
		//Based on the specified IntTree the current node is automatically
		//determined
		IntTreeNode root = Iterated.GetFirstNode();
		CurrentNode = root;
		//The stack is instantiated
		TheStack = new NodeStack();
		

		
    }

	
	//Returns the next IntTreeNode following an algorithm that
	//traverses the IntTree in question in a postorder fashion
	public IntTreeNode Next()
	{
		
		IntTreeNode result;
		try
		{
			StackNode nextNode;
			//Adds nodes to the stack as long as they are not null
			while (CurrentNode != null)
			{
				//Links the current node to a stacknode object
				StackNode StackCurrentNode = new StackNode(CurrentNode);
				//Pushes the stacknode object onto the stack
				TheStack.Push(StackCurrentNode);
				//Sets the current node to be its left child
				//This could be null, but this possibility is handled by the 
				//IsEmpty() method of the NodeStack class
				CurrentNode = CurrentNode.GetLeft_node();
			}
			//When there are no more children to the left of the node, the last node 
			//added is popped from the stack and is returned, but only after the right 
			//child of its parent, if it exists, is set to the current node
			if (HasNext())
			{
				nextNode = TheStack.Pop();
				if (nextNode.GetReference().HasRight_Child())
				{
					CurrentNode = nextNode.GetReference().GetRight_node();
				}
				result = nextNode.GetReference();
			}
			else
				result = null;
			
		}
		catch (System.NullReferenceException)
        {
			//if the current node has no children then it is returned
			result = CurrentNode;
		}
		return result;
    }

	//Returns a boolean value on whether or not the stack is empty
	public bool HasNext()
	{
		try
		{
			return !TheStack.IsEmpty();
		}
		catch (System.NullReferenceException)
		{
			return false;
		}
	}
}
