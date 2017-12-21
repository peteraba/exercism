"""Series exercise solution"""

def slices(series, length):
    """Slices implementation"""

    retval = []

    for x in range(0, len(series)-length+1):
        numbers = series[x:x+length]

        digits = [int(s) for s in list(numbers)]

        retval.append(digits)

    return retval


