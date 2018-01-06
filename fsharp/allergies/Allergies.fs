module Allergies

type Allergen =
    | Eggs = 1
    | Peanuts = 2
    | Shellfish = 4
    | Strawberries = 8
    | Tomatoes = 16
    | Chocolate = 32
    | Pollen = 64
    | Cats = 128

let allergicTo codedAllergies (allergen: Allergen) =
        codedAllergies &&& int allergen > 0

let list codedAllergies =
    let powersOfTwo = [ for i in [0 .. 7] -> 1 <<< i]
    [ for p in powersOfTwo do if p &&& codedAllergies > 0 then yield enum<Allergen> p ]
