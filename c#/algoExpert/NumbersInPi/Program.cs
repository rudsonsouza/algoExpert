/*
 * Numbers In Pi
 *
 * Given a string representation of the first n digits of Pi and a list of positive
 * integers (all in string format), write a function that returns the smallest number
 * of spaces that can be added to the n digits of Pi such that all resulting numbers
 * are found in the list of integers.
 *
 * Note that a single number can appear multiple times in the resulting numbers.
 * For example, if Pi is "3141" and the numbers are ["1", "3", "4"], the
 * number "1" is allowed to appear twice in the list of resulting numbers after
 * three spaces are added: "3 | 1 | 4 | 1".
 *
 * If no number of spaces to be added exists such that all resulting numbers are
 * found in the list of integers, the function should return -1.
*/

var pi = "3141592653589793238462643383279";
var numbers = new string[] 
    {
        "314159265358979323846",
        "26433",
        "8",
        "3279",
        "314159265",
        "35897932384626433832",
        "79"
    };

var result = NumbersInPi(pi, numbers);

static int NumbersInPi(string pi, string[] numbers)
{
    HashSet<string> numbersTable = new HashSet<string>();
    foreach(string number in numbers)
    {
        numbersTable.Add(number);
    }

    Dictionary<int, int> cache = new Dictionary<int, int>();
    int minSpaces = getMinSpaces(pi, numbersTable, cache, 0);

    return minSpaces == Int32.MaxValue ? -1 : minSpaces;
}

static int getMinSpaces(string pi, HashSet<string> numbersTable, Dictionary<int, int> cache, int idx)
{
    if (idx == pi.Length) return -1;

    if (cache.ContainsKey(idx)) return cache[idx];
    int minSpaces = Int32.MaxValue;
    for (int i = idx; i < pi.Length; i++)
    {
        string prefix = pi.Substring(idx, i + 1 - idx);
        if (numbersTable.Contains(prefix))
        {
            int minSpacesInSuffix = getMinSpaces(pi, numbersTable, cache, i + 1);

            if (minSpacesInSuffix == Int32.MaxValue)
            {
                minSpaces = Math.Min(minSpaces, minSpacesInSuffix);
            }
            else
            {
                minSpaces = Math.Min(minSpaces, minSpacesInSuffix + 1);
            }
        }
    }

    cache[idx] = minSpaces;
    return cache[idx];
}