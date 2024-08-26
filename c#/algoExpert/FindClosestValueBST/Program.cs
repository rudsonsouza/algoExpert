// See https://aka.ms/new-console-template for more information

/* Find Closest Value in BST
 * 
 * Write a function that takes in a Binary Search Tree (BST) and a target integer value and returns the closest value
 * to that target value contained in the BST.
 *
 * You can assume that there will only be one closest value.
 *
 * Each BST node has an integer value, a left child node, and a right child node. A node is said to be a valid BST
 * node if and only if it satisfies the BST property: its value is strictly greater than the values of every node
 * to its left; its value is less than or equal to the values of every node to its right; and its children nodes are
 * either valid BST nodes themselves or None/null
 *
 * tree = 10
 *       5     15
 *     2  5  13  22
 *   1        14
 *
 * target = 12
 */

static int FindClosestValueInBst(BST tree, int target)
{
    return findClosestValueBstHelper(tree, target, tree.value);
}

static int findClosestValueBstHelper(BST tree, int target, int closest)
{
    BST currentNode = tree;

    while (currentNode != null)
    {
        if (Math.Abs(target - closest) > Math.Abs(target - currentNode.value))
            closest = currentNode.value;

        if (target < currentNode.value)
            currentNode = currentNode.left;
        else if (target > currentNode.value)
            currentNode = currentNode.right;
        else break;
    }

    return closest;
}

var root = new BST(10);
root.left = new BST(5);
root.left.left = new BST(2);
root.left.left.left = new BST(1);
root.left.right = new BST(5);

root.right = new BST(15);
root.right.left = new BST(13);
root.right.left.right = new BST(14);
root.right.right = new BST(22);

var output = FindClosestValueInBst(root, 12);

public class BST
{
    public int value;
    public BST left;
    public BST right;

    public BST(int value)
    {
        this.value = value;
    }
}