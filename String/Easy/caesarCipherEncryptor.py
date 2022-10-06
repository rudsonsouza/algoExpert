class Solution:
    # time O(n) | space O(n)
    def caesarCipherEncryptor(string, key):
        newLetters = []
        newKey = key % 26
        alphabet = list("abcdefghijklmnopqrstuvwxyz")
        for letter in string:
            newLetters.append(getNewLetter(letter, newKey, alphabet))
        return "".join(newLetters)
    
def getNewLetter(letter, key, alphabet):
    newLetterCode = alphabet.index(letter) + key
    return alphabet[newLetterCode % 26]

print(Solution.caesarCipherEncryptor("xyz", 2))

