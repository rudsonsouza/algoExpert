// See https://aka.ms/new-console-template for more information

/* Depth-first Search
 *
 * You're given a Node class that has a name and an array of optional children nodes. When put
 * together, nodes form an acyclic tree-like structure.
 *
 * Implement the depthFirstSearch method on the Node class, which takes in an empty array,
 * traverses the tree using the Depth-first Search approach (specifically navigating the treee from left to
 * right), stores all the nodes' names in the input array, and returns it.
 *
 * 
 */
Console.WriteLine("Hello, World!");

Node graph = new Node("A");
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
graph.DepthFirstSearch(inputArray);

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
        Node child = new Node(name);
        children.Add(child);
        return this;
    }

    // Time O(v + e) | Space (v)
    public List<string> DepthFirstSearch(List<string> array)
    {
        array.Add(this.name);
        for (int i = 0; i < children.Count; i++)
        {
            children[i].DepthFirstSearch(array);
        }

        return array;
    }
}