// See https://aka.ms/new-console-template for more information

/*
 * Breadth-first Search
 *
 * You're given a Node class that has a name and an array of optional children nodes. When put
 * together, nodes form an acyclic tree-like structure.
 *
 * Implement the breadthFirstSearch method on the Node class, which takes in an empty array,
 * traverses the tree using the Breadth-first Search approach (specifically navigating the tree from left to
 * right), stores all of the nodes' names in the input array, and returns it.
 *
 * If you're unfamiliar with Breadth-first Search, we recommend watching the Conceptual Overview section
 * of this question's video explanation before starting to code.
 */

Console.WriteLine("Hello, World!");

var graph = new Node("A");
graph.AddChild("B")
    .AddChild("C")
    .AddChild("D");

graph.children[0].AddChild("E")
    .AddChild("F");

graph.children[2].AddChild("G")
    .AddChild("H");

graph.children[0].children[1].AddChild("I")
    .AddChild("J");

graph.children[2].children[0].AddChild("K");

List<string> inputArray = new List<string>();
var result = graph.BreadthFirstSearch(inputArray);

result.ForEach(n => Console.WriteLine(n));

public class Node
{
    public string name;
    public List<Node> children = new List<Node>();

    public Node(string name)
    {
        this.name = name;
    }

    public Node AddChild(string name)
    {
        Node newNode = new Node(name);
        children.Add(newNode);
        
        return this;
    }

    // O(V) + O(E) time | O(V) space
    public List<string> BreadthFirstSearch(List<string> array)
    {
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            array.Add(current.name);
            current.children.ForEach(node => queue.Enqueue(node));
        }

        return array;
    }
}