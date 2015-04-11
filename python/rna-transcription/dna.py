from collections import defaultdict

def to_rna(dna):
    translate = defaultdict(None, {
        'C': 'G',
        'G': 'C',
        'T': 'A',
        'A': 'U',
    })

    return "".join(translate[letter] for letter in dna)
