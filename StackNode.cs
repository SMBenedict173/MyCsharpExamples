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

public class StackNode
{
	//The data portion of this node
	private IntTreeNode Reference;
	//Links this node to the next in the stack
	private StackNode Next;

	//Constructs a new StackNode with an IntTreeNode as its data
	public StackNode (IntTreeNode referencedNode)
    {
		Reference = referencedNode;
		Next = null;
    }

	//Returns the node to which this node is linked
	public StackNode GetNext()
    {
		return Next;
    }

	//Links the node to another
	public void SetNext(StackNode nodeBelow)
    {
		Next = nodeBelow;
    }

	//Returns the referenced IntTreeNode if it exists, otherwise returns null.
	public IntTreeNode GetReference()
	{
		try
		{
			return Reference;
		}
		catch (System.NullReferenceException)
		{
			return null;
		}
	}

	//Returns a boolean value on whether or not this node is linked to another
	public bool HasNext() 
	{
        bool result;
        try
        {
			StackNode thingy = GetNext();
			//If the GetNext method does not return null, then this method returns true
			if (thingy != null)
            {
				result = true;
			}
			else
            {
				result = false;
            }
			
        }
		//If the GetNext method returns null, it may trigger a NullReference Exception
		// This will cause this method to return false
		catch (System.NullReferenceException)
        {
			result = false;
        }
		return result;

	}
}
