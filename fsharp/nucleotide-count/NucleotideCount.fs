module NucleotideCount

let nucleotideCounts (strand: string): Map<char, int> option =
    let initial =
        [ ('A', 0);
          ('C', 0);
          ('G', 0);
          ('T', 0) ]
        |> Map.ofList

    let seqToMap (acc: Map<char, int>) (a: char, b: seq<char>): Map<char, int> =
        match acc.TryFind a with
        | Some x -> acc.Add(a, Seq.length b)
        | None -> failwith "Invalid strand"

    try
        strand
            |> List.ofSeq
            |> Seq.groupBy id
            |> Seq.fold seqToMap initial
            |> Some

    with
        | Failure(msg) -> None
