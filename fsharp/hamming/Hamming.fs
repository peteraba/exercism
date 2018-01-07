module Hamming

let distance (strand1: string) (strand2: string): int option =
    match strand1.Length, strand2.Length with
    | x, y when x = y ->
        let d = List.fold2 (fun acc a b -> if a=b then acc; else acc + 1) 0 (strand1 |> List.ofSeq) (strand2 |> List.ofSeq) 
        Some(d)
    | _, _ -> None