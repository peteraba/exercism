from collections import defaultdict

def to_rna(dna):

    translate = defaultdict(lambda: "", {
        'C': 'G',
        'G': 'C',
        'T': 'A',
        'A': 'U',
    })

    return "".join(translate[letter] for letter in dna)
