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

public class IntTreeNode
{
	//The integer that is stored in the node
	private readonly int stored_data;
	//The left child of this node, which should only have children if it is a 
	//member of a tree
	private IntTreeNode left_node;
	//The right child of this node, which should only have children if it is a
	//member of a tree
	private IntTreeNode right_node;

	/**
	 * Constructor that takes an integer value and stores it as its data.
	 * As this node is new, it does not have any children yet.
	 */
	public IntTreeNode(int value)
	{
		stored_data = value;
		left_node = null;
		right_node = null;
	}

	//Returns this node's left child
	public IntTreeNode GetLeft_node()
	{
		try
        {
			return left_node;
        }
		catch (System.NullReferenceException)
        {
			return null;
        }
	}

	//Returns this node's right child
	public IntTreeNode GetRight_node()
	{
		try
		{
			return right_node;
		}
		catch (System.NullReferenceException)
        {
			return null;
        }
	}

	//returns the integer data stored within this tree
	public int GetData() => this.stored_data;

	//Sets this node's left child to the node in question
	public void SetLeft_node(IntTreeNode nextLeft) => left_node = nextLeft;

	/**
	 * Determines whether or not this node has a left child
	 */
	public bool HasLeft_Child()
    {
		bool result;
        try
        {
			//Gets the left child of this node
			IntTreeNode NullPossibility = this.GetLeft_node();
			try
            {
				//If the left child is set to a non-null IntTreeNode, then
				//the result is true
				if (NullPossibility != null)
                {
					result = true;
				}
				//If the left child is set to null, then the result is false
				else
                {
					result = false;
                }
            }
			//If this method is called on a null node, then the result is false
			catch (System.NullReferenceException)
            {
				result = false;
            }
			
        }
		//If the left child is the wrong type, then the result is false
		catch (System.Exception)
        {
			result = false;
        }
		return result;
	}

	/**
	 * Determines whether or not this node has a right child
	 */
	public bool HasRight_Child()
	{
		bool result;
		try
		{
			//Gets the right child of this node
			IntTreeNode NullPossibility = GetRight_node();
			try
			{
				//If the right child is set to a non-null IntTreeNode, then
				//the result is true
				if (NullPossibility != null)
				{
					result = true;
				}
				//If the right child is null, then the result is false
				else
				{
					result = false;
				}
			}
			//If this method is called on a null node, then the result is false
			catch (System.NullReferenceException)
			{
				result = false;
			}
		}
		//If the right child is of the wrong type, then the result is false
		catch (System.Exception)
		{
			result = false;
		}
		return result;
	}

	//Sets this node's right child to the node in question
	public void SetRight_node(IntTreeNode nextRight) => right_node = nextRight;

	/**
	 * Determines whether or not the data within this node is greater than
	 * the data within another node
	 */ 
	public bool CompareNodeGreater(IntTreeNode node2)
	{
		//Create variables to store the data for both nodes
		int node1Value = this.GetData();
		int node2Value = node2.GetData();
		//Returns true if this node's data is greater than the data in the 
		//node in question
		if (node1Value > node2Value)
		{
			return true;
		}
		//Returns false if this node's data is less than or equal to the data
		//in the node in question
		else
		{
			return false;
		}
	}
}
