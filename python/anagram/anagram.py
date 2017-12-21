def detect_anagrams(search, haystack):
    found = []

    search = search.lower()
    normalised_search = sorted(search)

    for word in haystack:
        if word.lower() != search and normalised_search == sorted(word.lower()):
            found.append(word)

    return found

