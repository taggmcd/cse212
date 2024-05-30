using System.Formats.Asn1;

public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        if (value == Data)
            return;
        else if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        // check if the current node's data is the value

        if (Data == value)
            return true;
        else if (Data < value)
        {
            // check if the right node is null
            if (Right is null)
                return false;
            else
                return Right.Contains(value);
        }
        else
        {
            // check if the left node is null
            if (Left is null)
                return false;
            else
                return Left.Contains(value);
        }
        // return false;
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        // return the height of the tree
        if (Left is null && Right is null)
            return 1;
        else if (Left is null)
            return 1 + Right.GetHeight();
        else if (Right is null)
            return 1 + Left.GetHeight();
        else
            return 1 + Math.Max(Left.GetHeight(), Right.GetHeight());
    }
}