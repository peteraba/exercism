module TwelveDays

let recite (start: int) (stop: int) = 
    let numbers =
        [|
            "first"
            "second"
            "third"
            "fourth"
            "fifth"
            "sixth"
            "seventh"
            "eighth"
            "ninth"
            "tenth"
            "eleventh"
            "twelfth" |]
        
    let presentNames =
        [
            "a Partridge"
            "two Turtle Doves"
            "three French Hens"
            "four Calling Birds"
            "five Gold Rings"
            "six Geese-a-Laying"
            "seven Swans-a-Swimming"
            "eight Maids-a-Milking"
            "nine Ladies Dancing"
            "ten Lords-a-Leaping"
            "eleven Pipers Piping"
            "twelve Drummers Drumming" ]

    let addAnd (wordList: string list): string list =
        match wordList with
        | [elem] -> wordList
        | head :: tail -> ("and " + head) :: tail
        | x -> x

    let printLine line =
        let number = numbers.[line]
        let presents =
            presentNames
            |> List.take(line + 1)
            |> addAnd
            |> List.rev
            |> (fun x -> System.String.Join (", ", x))
    
        sprintf "On the %s day of Christmas my true love gave to me, %s in a Pear Tree." number presents

    [ for i in start .. stop -> printLine (i - 1) ]
