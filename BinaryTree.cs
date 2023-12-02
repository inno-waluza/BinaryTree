using System;

class BinaryTree<T> where T : IComparable<T>
{
    private Node<T> root;

    public void Insert(T data)
    {
        root = InsertRecursive(root, data);
    }

    private Node<T> InsertRecursive(Node<T> current, T data)
    {
        if (current == null)
        {
            return new Node<T>(data);
        }

        if (data.CompareTo(current.Data) < 0)
        {
            current.Left = InsertRecursive(current.Left, data);
        }
        else if (data.CompareTo(current.Data) > 0)
        {
            current.Right = InsertRecursive(current.Right, data);
        }

        return current;
    }

    public bool SearchWithDetails(T data)
    {
        return SearchRecursive(root, data, null);
    }

    private bool SearchRecursive(Node<T> current, T data, Node<T> parent)
    {
        if (current == null)
        {
            return false;
        }

        if (data.CompareTo(current.Data) == 0)
        {
            if (parent != null)
            {
                Console.WriteLine($"Immediate parent of {data}: {parent.Data}");
            }
            else
            {
                Console.WriteLine($"{data} is the root node.");
            }

            if (current.Left != null)
            {
                Console.WriteLine($"Immediate left child of {data}: {current.Left.Data}");
            }
            if (current.Right != null)
            {
                Console.WriteLine($"Immediate right child of {data}: {current.Right.Data}");
            }

            return true;
        }

        return data.CompareTo(current.Data) < 0
            ? SearchRecursive(current.Left, data, current)
            : SearchRecursive(current.Right, data, current);
    }

    public void RemoveWithDetails(T data)
    {
        root = RemoveRecursive(root, data);
    }

    private Node<T> RemoveRecursive(Node<T> current, T data)
    {
        if (current == null)
        {
            return current;
        }

        if (data.CompareTo(current.Data) < 0)
        {
            current.Left = RemoveRecursive(current.Left, data);
        }
        else if (data.CompareTo(current.Data) > 0)
        {
            current.Right = RemoveRecursive(current.Right, data);
        }
        else
        {
            if (current.Left == null)
            {
                return current.Right;
            }
            else if (current.Right == null)
            {
                return current.Left;
            }

            Console.WriteLine($"Immediate left child of {data} before removal: {current.Left.Data}");
            Console.WriteLine($"Immediate right child of {data} before removal: {current.Right.Data}");

            current.Data = MinValue(current.Right);
            current.Right = RemoveRecursive(current.Right, current.Data);
        }

        return current;
    }

    private T MinValue(Node<T> node)
    {
        T minValue = node.Data;
        while (node.Left != null)
        {
            minValue = node.Left.Data;
            node = node.Left;
        }
        return minValue;
    }

    public void InOrderTraversal()
    {
        InOrderTraversalRecursive(root);
        Console.WriteLine();
    }

    private void InOrderTraversalRecursive(Node<T> current)
    {
        if (current != null)
        {
            InOrderTraversalRecursive(current.Left);
            Console.Write($"{current.Data} ");
            InOrderTraversalRecursive(current.Right);
        }
    }

    public void PostOrderTraversal()
    {
        PostOrderTraversalRecursive(root);
        Console.WriteLine();
    }

    private void PostOrderTraversalRecursive(Node<T> current)
    {
        if (current != null)
        {
            PostOrderTraversalRecursive(current.Left);
            PostOrderTraversalRecursive(current.Right);
            Console.Write($"{current.Data} ");
        }
    }
}