module BeerSong

let private bottles (currentBottles: int): string =
    let bottlesCount =
        match currentBottles with
        | x when x > 1 -> string x + " bottles of beer"
        | x when x = 1 -> string x + " bottle of beer"
        | _ -> "no more bottles of beer"

    bottlesCount
    
let private firstLine (currentBottles: int): string =
    let bottlesCount = bottles currentBottles

    let capitalizedBottlesCount = bottlesCount.Substring(0, 1).ToUpper() + bottlesCount.Substring(1)

    capitalizedBottlesCount + " on the wall, " + bottlesCount + "."
    
let private secondLine (currentBottles: int): string =
    let action =
        match currentBottles with
        | x when x > 1 -> "Take one down and pass it around"
        | x when x = 1 -> "Take it down and pass it around"
        | _ -> "Go to the store and buy some more"
    
    let newBottlesCount =
        match currentBottles with
        | x when x = 0 -> bottles 99
        | _ -> bottles (currentBottles - 1)
    
    action + ", " + newBottlesCount + " on the wall."

let recite (startBottles: int) (takeDown: int) =
    let mutable verses = []
    let mutable bottles = startBottles

    for i = 1 to takeDown do
        verses <- verses @ [ firstLine bottles; secondLine bottles; "" ]
        bottles <- if bottles = 0 then 99; else bottles - 1;

    if verses.Length > 2 then verses.[0 .. verses.Length-2]; else []
