class Program
{
    static void Main(string[] args)
    {
        BinaryTree<int> tree = new BinaryTree<int>();

        while (true)
        {
            Console.WriteLine("Select an operation:");
            Console.WriteLine("1. Enter elements for the binary tree");
            Console.WriteLine("2. Exit");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        // Prompting the user to input elements for the binary tree separated by spaces
                        Console.WriteLine("Enter the elements for the binary tree separated by spaces:");
                        string[] elements = Console.ReadLine().Split(' ');

                        // Inserting elements into the binary tree
                        foreach (var element in elements)
                        {
                            if (int.TryParse(element, out int value))
                            {
                                tree.Insert(value);
                            }
                            else
                            {
                                // Notifying the user about invalid input
                                Console.WriteLine($"Invalid input: '{element}'. Skipping...");
                            }
                        }

                        // After inserting elements, display the main menu for operations
                        while (true)
                        {
                            Console.WriteLine("Select an operation:");
                            Console.WriteLine("1. Inorder traversal");
                            Console.WriteLine("2. Postorder traversal");
                            Console.WriteLine("3. Search in the tree");
                            Console.WriteLine("4. Remove from the tree");
                            Console.WriteLine("5. Exit");

                            if (int.TryParse(Console.ReadLine(), out int choice2))
                            {
                                switch (choice2)
                                {
                                    case 1:
                                        // Displaying the tree in inorder traversal
                                        Console.WriteLine("Inorder traversal:");
                                        tree.InOrderTraversal();
                                        break;
                                    case 2:
                                        // Displaying the tree in postorder traversal
                                        Console.WriteLine("Postorder traversal:");
                                        tree.PostOrderTraversal();
                                        break;
                                    case 3:
                                        // Searching for a value in the tree
                                        Console.WriteLine("Enter a value to search in the tree:");
                                        if (int.TryParse(Console.ReadLine(), out int searchValue))
                                        {
                                            bool isFound = tree.SearchWithDetails(searchValue);
                                            if (!isFound)
                                            {
                                                Console.WriteLine($"Value {searchValue} not found in the tree.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input for search value.");
                                        }
                                        break;
                                    case 4:
                                        // Removing a value from the tree
                                        Console.WriteLine("Enter a value to remove from the tree:");
                                        if (int.TryParse(Console.ReadLine(), out int removeValue))
                                        {
                                            tree.RemoveWithDetails(removeValue);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid input for removal.");
                                        }
                                        break;
                                    case 5:
                                        // Exiting the program
                                        Console.WriteLine("Exiting the program...");
                                        return;
                                    default:
                                        Console.WriteLine("Invalid choice. Please select again.");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a number for choice.");
                            }
                            Console.WriteLine();
                        }
                    case 2:
                        // Exiting the program
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number for choice.");
            }
            Console.WriteLine();
        }
    }
}