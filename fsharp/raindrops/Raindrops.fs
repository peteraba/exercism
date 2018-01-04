module Raindrops

let private drops = [ ( 3, "Pling" ); ( 5, "Plang" ); ( 7, "Plong" ) ]

let convert (number: int): string =
    let mutable say = ""
    for drop in drops do
        let (divider, sound) = drop
        say <- if number % divider = 0 then say + sound; else say;
    
    if say = "" then string number else say
