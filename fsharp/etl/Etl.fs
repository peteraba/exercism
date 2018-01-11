module Etl

let transform (scoresWithLetters: Map<int, char list>): Map<char, int> =
    let elemToNewMap acc (score, charList): Map<char, int> =
        List.fold (fun acc ch -> acc.Add(System.Char.ToLower(ch), score)) acc charList
    
    scoresWithLetters
        |> Map.toSeq
        |> Seq.fold elemToNewMap Map.empty