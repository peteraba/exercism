module BeerSong

let recite (startBottles: int) (takeDown: int) = 

    let printVerse = 
        function
        | x when x > 2 ->
            [ 
                sprintf "%d bottles of beer on the wall, %d bottles of beer." x x;
                sprintf "Take one down and pass it around, %d bottles of beer on the wall." (x - 1);
                "" 
            ]
        | x when x = 2 ->
            [
                "2 bottles of beer on the wall, 2 bottles of beer.";
                "Take one down and pass it around, 1 bottle of beer on the wall.";
                ""
            ]
        | x when x = 1 ->
            [
                "1 bottle of beer on the wall, 1 bottle of beer.";
                "Take it down and pass it around, no more bottles of beer on the wall.";
                ""
            ]
        | _ ->
            [
                "No more bottles of beer on the wall, no more bottles of beer.";
                "Go to the store and buy some more, 99 bottles of beer on the wall."
            ]

    let generate = 
        function
        | x when x >= 0 -> Some (printVerse x, x - 1)
        | _             -> None
        
    List.unfold generate startBottles
    |> List.concat
    |> List.take (takeDown * 3 - 1)
