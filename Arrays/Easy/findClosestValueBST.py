# Average: time O(log(n)) | space O(log(n))
class Solution(object):
    def findClosestValueInBst(tree, target):
        #return findClosestValueInBstHelper(tree, target, float("inf"))
        return findClosestValueInBstIterativeHelper(tree, target, float("inf"))

def findClosestValueInBstHelper(tree, target, closest):
    if tree is None:
        return closest
    
    if abs(target - closest) > abs(target - tree.value):
        closest = tree.value
    
    if target < tree.value:
        return findClosestValueInBstHelper(tree.left, target, closest)
    elif target > tree.value:
        return findClosestValueInBstHelper(tree.right, target, closest)
    else:
        return closest

def findClosestValueInBstIterativeHelper(tree, target, closest):
    currentNode = tree

    while currentNode is not None:
        if abs(target - closest) > abs(target - currentNode.value):
            closest = currentNode.value
    
        if target < currentNode.value:
            currentNode = currentNode.left
        elif target > currentNode.value:
            currentNode = currentNode.right
        else:
            break

    return closest

class BST:
    def __init__(self, value):
        self.value = value
        self.left = None
        self.right = None

root = BST(10)
root.left = BST(5)
root.left.left = BST(2)
root.left.left.left = BST(1)
root.left.right = BST(5)
root.right = BST(15)
root.right.left = BST(13)
root.right.left.right = BST(14)
root.right.right = BST(22)

print(Solution.findClosestValueInBst(root, 12))