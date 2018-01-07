module Hamming

let distance (strand1: string) (strand2: string): int option =
    match strand1.Length, strand2.Length with
    | x, y when x = y ->
        let folder acc a b =
            if a = b then acc; else acc + 1

        let d = List.fold2 folder 0 (List.ofSeq strand1) (List.ofSeq strand2)
        
        Some(d)
    | _, _ -> None