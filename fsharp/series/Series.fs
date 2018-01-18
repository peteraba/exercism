module Series
open System

let slices (str: string) length =
    if length > str.Length then raise (ArgumentException("Invalid length"))
    else
        let sliceLength = str.Length - length
        let numToDigitList (num: string) =
            num |> Seq.map (string >> System.Int32.Parse) |> List.ofSeq

        [ for i in 0 .. sliceLength -> str.[i .. i + length - 1] |> numToDigitList ]