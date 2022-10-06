class Solution:
    def runLengthEncoding(string):
        chars = []
        length = 1

        for i in range(1, len(string)):
            
            if string[i] != string[i - 1] or length == 9:
                chars.append(str(length))
                chars.append(string[i - 1])
                length = 0

            length += 1

        chars.append(str(length))
        chars.append(string[len(string) - 1])

        return "".join(chars)

print(Solution.runLengthEncoding("AAAAAAAAAAAAABBCCCCDD"))