// See https://aka.ms/new-console-template for more information
/* Find Loop
 *
 * Write a function that takes in the head of a Singly Linked List that contains a loop (in other words, the
 * list's tail node points to some node in the list instead of None/null). The function should return
 * the node (the actual node--not just its value) from which the loop originates in constant space.
 *
 * Each LinkedList node has an integer value as well as a next node pointing to the next node
 * in the list.
 *
 * Sample Input
 * head = 0 -> 1 -> 2 -> 3 -> 4 -> 5 -> 6
 *                                      v
 *                            9 <- 8 <- 7
 */

Console.WriteLine("Hello, World!");

static LinkedList FindLoop(LinkedList head)
{
    LinkedList first = head.next;
    LinkedList second = head.next.next;

    while (first != second)
    {
        first = first.next;
        second = second.next.next;
    }

    first = head;
    while (first != second)
    {
        first = first.next;
        second = second.next;
    }

    return first;
}

public class LinkedList
{
    public int value;
    public LinkedList next = null;

    public LinkedList(int value)
    {
        this.value = value;
    }
}