module Hamming

let distance (strand1: string) (strand2: string): int option =
    match strand1.Length, strand2.Length with
    | x, y when x = y ->
        let seq1, seq2 = (List.ofSeq strand1), (List.ofSeq strand2)
        Some(List.fold2 (fun acc a b -> if a = b then acc; else acc + 1) 0 seq1 seq2)
    | _, _ -> None
