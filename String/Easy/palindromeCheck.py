from turtle import left


class Solution:
    def isPalindrome01(string):
        reversedString = []

        for i in reversed(range(len(string))):
            reversedString.append(string[i])
        return string == "".join(reversedString)

    def isPalindrome02(string):
        leftIdx = 0
        rightIdx = len(string) - 1

        while leftIdx < rightIdx:
            if string[leftIdx] != string[rightIdx]:
                return False
            leftIdx += 1
            rightIdx -= 1
        return True

print(Solution.isPalindrome02("abcdcba"))