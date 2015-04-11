from collections import defaultdict

def default_factory(): return ""

def to_rna(dna):

    translate = defaultdict(default_factory, {
        'C': 'G',
        'G': 'C',
        'T': 'A',
        'A': 'U',
    })

    return "".join(translate[letter] for letter in dna)
