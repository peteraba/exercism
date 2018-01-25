module LargestSeriesProduct

open System

let largestProduct (input: string) seriesLength : int option =
    let charZero = Convert.ToInt32 '0'
    let charNine = Convert.ToInt32 '9'
    
    let product (digits: string): int =
        digits
        |> Seq.map (fun x -> Convert.ToInt32 x - charZero) 
        |> Seq.fold (*) 1

    let filteredInput = Seq.filter (fun x -> int x >= charZero && int x <= charNine) input |> (fun x -> System.String.Join ("", x))

    if input.Length < seriesLength || seriesLength < 0 || input <> filteredInput then None
    else 
        [ for i in 0 .. input.Length - seriesLength -> product input.[i .. i + seriesLength - 1] ]
        |> List.max
        |> Some
