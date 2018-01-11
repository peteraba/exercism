module Isogram

let isIsogram (str: string) =
    let filtered = str.ToLower() |> Seq.filter (fun x -> int x >= 97 && int x <= 122)
    let distinct = Seq.distinct filtered

    Seq.length filtered = Seq.length distinct
 