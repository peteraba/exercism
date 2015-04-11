def distance(textOne, textTwo):
    count  = 0
    lenTwo = len(textTwo)

    for i, c in enumerate(textOne):
        if lenTwo <= i or textTwo[i] != c:
            count += 1

    return count + lenTwo - len(textOne)
