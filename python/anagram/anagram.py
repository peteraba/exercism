def detect_anagrams(search, haystack):
    found = []
    

    search = search.lower()
    normalised_search = normalise_string(search)

    for word in haystack:
        if word.lower() != search and normalised_search == normalise_string(word.lower()):
            found.append(word)

    return found
    
def normalise_string(orig_string):
    return "".join(sorted(orig_string))

