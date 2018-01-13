module RnaTranscription

let toRna (dna: string): string option =
    let translateChar ch =
        match ch with
        | 'G' -> 'C'
        | 'C' -> 'G'
        | 'T' -> 'A'
        | 'A' -> 'U'
        | _ -> failwith "Invalid RNA"

    try
        let rna = Seq.map translateChar dna |> System.String.Concat

        Some(rna)
    with
        | Failure(msg) -> None
