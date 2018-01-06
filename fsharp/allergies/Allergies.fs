module Allergies

open System

// TODO: define the Allergen type
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
    int allergen &&& codedAllergies = int allergen

let list codedAllergies =
    let mutable res = []
    let allergens = Enum.GetValues(typeof<Allergen>) |> Seq.cast<Allergen>

    for allergen in allergens do
        res <-
            match (allergicTo codedAllergies allergen) with
            | true -> res @ [ allergen ]
            | false -> res

    res

