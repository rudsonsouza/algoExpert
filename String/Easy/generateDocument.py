class Solution:
    # time O(m * (m + n)) | space O(1)
    def generateDocument01(characters, document):
        for character in document:
            documentFrequency = countCharacterFrequency(character, document)
            charactersFrequency = countCharacterFrequency(character, characters)
            if documentFrequency > charactersFrequency:
                return False
            
        return True

    # time O(c * (n + m)) | space O(c)
    def generateDocument02(characters, document):
        alreadyCounted = set()

        for character in document:
            if character in alreadyCounted:
                continue

            documentFrequency = countCharacterFrequency(character, document)
            charactersFrequency = countCharacterFrequency(character, characters)
            if documentFrequency > charactersFrequency:
                return False
            
            alreadyCounted.add(charactersFrequency)
        
        return True
    # time O(n + m) | space O(c)
    def generateDocument03(characters, document):
        characterCounts = {}

        for character in characters:
            if character not in characterCounts:
                characterCounts[character] = 0
            
            characterCounts[character] += 1
        
        for character in document:
            if character not in characterCounts or characterCounts[character] == 0:
                return False
            
            characterCounts[character] -= 1
        return True


def countCharacterFrequency(character, target):
    frequency = 0
    for char in target:
        if char == character:
            frequency += 1
    return frequency

print(Solution.generateDocument01("Bste!hetsi ogEAxpelrt x ", "AlgoExpert is the Best!"))