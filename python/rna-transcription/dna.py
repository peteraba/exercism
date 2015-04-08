def to_rna(dna):
    translate = {
        'C': 'G',
        'G': 'C',
        'T': 'A',
        'A': 'U',
    }

    return strtr(dna, translate)

# Found on stackoverflow, recursively replaces occurances of keys with values in to_translate
def strtr(to_translate, replace):
    if replace and to_translate:
        s, r = replace.popitem()
        return r.join(strtr(subs, dict(replace)) for subs in to_translate.split(s))
    
    return to_translate
