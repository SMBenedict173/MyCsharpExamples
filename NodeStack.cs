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

public class NodeStack
{
	//Pointer to the top or first node in the stack
	private StackNode FirstNode;

	//Default Constructor
	public NodeStack()
	{
		FirstNode = null;
	}

	//Constructor which specifies a node to be the top of the stack
	public NodeStack(StackNode topNode)
    {
		FirstNode = topNode;
    }

	//Places a new node at the top of the stack
	public void Push(StackNode newNode)
    {
		//If a node is already specified to be the top of the stack
		//then it is pushed down and the new node then links to it
		try
        {
			StackNode temp = FirstNode;
			FirstNode = newNode;
			newNode.SetNext(temp);
        }
		//If there is no top node already, then this new node becomes the top
		catch (System.NullReferenceException)
        {
			FirstNode = newNode;
        }
    }

	//Removes and returns the top node of the stack 
	public StackNode Pop()
    {
		StackNode result = FirstNode;
		
		if (FirstNode.HasNext())
		{
			//The node linked to the top node is now placed at the top of the stack
			StackNode newTop = result.GetNext();
			FirstNode = newTop;
			
		}
		else
        {
			//If there is no node linked to the popped node, then the pointer 
			//to the top is set to null
			FirstNode = null;
        }
		return result;
    }

	//Returns the top node of the stack without removing it
	public StackNode Poll() => FirstNode;

	//Returns a boolean value on whether or not the stack is empty
	public bool IsEmpty()
    {
		bool result;
		try
        {
			//If the poll method does not trigger a Null Reference Exception
			//then that means that the stack may contain at least one element
			StackNode thingy = Poll();
			try
			{
				//However, if the poll method returns something that is not null,
				//then it is not empty
				if (thingy != null)
				{
					result = false;
				}
				//If the poll method returns null, then it is empty
				else
				{
					result = true;
				}
			}
			catch (System.NullReferenceException)
			{
				result = true;
			}
		}
		catch (System.NullReferenceException)
		{
			//If the poll method does trigger a Null Reference Exception
			//then that means the stack is in fact empty
			result = true;
		}
		return result;
    }

}
