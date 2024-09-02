// See https://aka.ms/new-console-template for more information

/*
 * Write a function that takes in two strings and returns the minimum number of edit operations that need to be
 * performed on the first string to obtain the second string.
 *
 * There are three edit operations: insertion of a character, deletion of a character, and substitution of
 * character for another.
 *
 * Sample
 *
 * str1 = abc
 * str2 = yabd
 *
 * 2 - insert y; substitute c for d 
 */

Console.WriteLine("Hello, World!");
string str1 = "abc";
string str2 = "yabd";

var result = LevenshteinDistanceMethod2(str1, str2);

Console.WriteLine(result);

// Time O(nm) | Space O(nm)
static int LevenshteinDistanceMethod(string str1, string str2)
{
    int[,] edits = new int[str2.Length + 1, str1.Length + 1];
    for (int i = 0; i < str2.Length + 1; i++)
    {
        for (int j = 0; j < str1.Length + 1; j++)
        {
            edits[i, j] = j;
        }
        
        edits[i, 0] = i;
    }
    
    for (int i = 1; i < str2.Length + 1; i++)
    {
        for (int j = 1; j < str1.Length + 1; j++)
        {
            if (str2[i - 1] == str1[j - 1])
            {
                edits[i, j] = edits[i - 1, j - 1];
            }
            else
            {
                edits[i, j] = 1 + Math.Min(edits[i - 1, j - 1], Math.Min(edits[i - 1, j], edits[i, j - 1]));
            }
        }
    }

    return edits[str2.Length, str1.Length];
}

// Time O(nm) | Space O(min(n, m))
static int LevenshteinDistanceMethod2(string str1, string str2)
{
    string small = str1.Length < str2.Length ? str1 : str2;
    string big = str1.Length >= str2.Length ? str1 : str2;
    int[] evenEdits = new int[small.Length + 1];
    int[] oddEdits = new int[small.Length + 1];

    for (int i = 0; i < small.Length; i++)
    {
        evenEdits[i] = i;
    }
    
    int[] currentEdits;
    int[] previousEdits;

    for (int i = 1; i < big.Length + 1; i++)
    {
        if (i % 2 == 1)
        {
            currentEdits = oddEdits;
            previousEdits = evenEdits;
        }
        else
        {
            currentEdits = evenEdits;
            previousEdits = oddEdits;
        }

        currentEdits[0] = i;

        for (int j = 1; j < small.Length + 1; j++)
        {
            if (big[i - 1] == small[j - 1])
            {
                currentEdits[j] = previousEdits[j - 1];
            }
            else
            {
                currentEdits[j] = 1 + Math.Min(currentEdits[j - 1], Math.Min(previousEdits[j - 1], Math.Min(previousEdits[j], currentEdits[j - 1])));
            }
        }
    }

    return big.Length % 2 == 0 ? evenEdits[small.Length] : oddEdits[small.Length];
}