"""Python distance exercise solution"""

def distance(text_one, text_two):
    """Calculate distance between two strings"""
    count = 0

    for (char1, char2) in zip(text_one, text_two):
        if char1 != char2:
            count += 1

    return count
