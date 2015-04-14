"""Sieve exercise"""

def sieve(num):
    """Sieve solution"""

    candidates = range(2, num+1)

    for candidate in candidates:
        multiple = candidate
        while True:
            multiple += candidate

            if multiple > num:
                break

            if multiple in candidates:
                candidates.remove(multiple)

    return candidates

