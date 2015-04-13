"""Solution for allergies task"""

class Allergies: 
    """Allergies class implementation"""

    allergies = [
        'eggs',
        'peanuts',
        'shellfish',
        'strawberries',
        'tomatoes',
        'chocolate',
        'pollen',
        'cats',
    ]

    def __init__(self, patient_allergies):
        """Constructor calculates list because otherwise tests failed when accessing/calling list"""
        self.patient_allergies = patient_allergies

        self.list = []
        for idx, allergie in enumerate(Allergies.allergies):
            score = 2 ** idx
            if score & self.patient_allergies:
                self.list.append(allergie)

    def is_allergic_to(self, item):
        """Decide if patient is allergic to an item"""
        idx = Allergies.allergies.index(item)

        score = 2 ** idx

        if score & self.patient_allergies:
            return True

        return False

