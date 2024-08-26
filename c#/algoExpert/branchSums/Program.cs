// See https://aka.ms/new-console-template for more information
/*
 * Write a function that takes in a Binary Tree and returns a list of its branch sums ordered from leftmost branch
 * sum to rightmost branch sum.
 *
 * A branch sum is the sum of all values in a Binary Tree branch. A Binary Tree branch is a path of nodes in a tree
 * that starts at the root node and ends at any leaf node.
 *
 * Each BinaryTree node has an integer value, a left child node, and a right child node. Children nodes can either be
 * BinaryTree nodes themselves or None/null.
 * 
 */

Console.WriteLine("Hello, World!");

var root = new BinaryTree(1);
root.left = new BinaryTree(2);
root.left.left = new BinaryTree(4);
root.left.right = new BinaryTree(5);
root.left.left.left = new BinaryTree(8);
root.left.left.right = new BinaryTree(9);

root.left.right.left = new BinaryTree(10);

root.right = new BinaryTree(3);
root.right.left = new BinaryTree(6);
root.right.right = new BinaryTree(7);

var result = BranchSums(root);

foreach (var item in result)
{
    Console.WriteLine(item);    
}


static List<int> BranchSums(BinaryTree root)
{
    List<int> sums = new List<int>();
    CalculateBranchSums(root, 0, sums);
    return sums;
}

static void CalculateBranchSums(BinaryTree node, int runningSum, List<int> sums)
{
    if (node == null) return;
    int newRunningSum = runningSum + node.value;

    if (node.left == null && node.right == null)
    {
        sums.Add(newRunningSum);
        return;
    }
    
    CalculateBranchSums(node.left, newRunningSum, sums);
    CalculateBranchSums(node.right, newRunningSum, sums);
}


public class BinaryTree
{
  public int value;
  public BinaryTree left;
  public BinaryTree right;

  public BinaryTree(int value)
  {
      this.value = value;
      this.left = null;
      this.right = null;
  }
}
