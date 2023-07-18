public class Node 
{
    public KeyValuePair<int, string> Value {get; set;}
    public Node? Left {get; set;}
    public Node? Right {get; set;}
    public Node(KeyValuePair<int, string> value){
        Value = value;
    }
}

public class SortedKVPairsStorage
{
    private Node? _tree;

    public IEnumerable<KeyValuePair<int, string>> AsEnumerable()
    {
        if (_tree == null)
        {
            yield break;
        }

        var stack = new Stack<Node>();
        stack.Push(_tree);
        var current = _tree.Left;

        while (true)
        {
            if (current == null)
            {
                if (stack.Count == 0)
                {
                    yield break;
                }

                current = stack.Pop();
                yield return current.Value;

                current = current.Right;
            }
            else
            {
                stack.Push(current);
                current = current.Left;
            }
        }
    }

    public void Insert(KeyValuePair<int, string> value)
    {
        if (_tree == null)
        {
            _tree = new Node(value);
            return;
        }

        var current = _tree;
        while (true)
        {
            if (value.Key >= current.Value.Key)
            {
                if (current.Right == null)
                {
                    current.Right = new Node(value);
                    return;
                }

                current = current.Right;
            }
            else
            {
                if (current.Left == null)
                {
                    current.Left = new Node(value);
                    return;
                }

                current = current.Left;
            }
        }
    }
}