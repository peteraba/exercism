module ProteinTranslation

let toProtein = function
    | "AUG"         -> "Methionine"
    | "UUU" | "UUC" -> "Phenylalanine"
    | "UUA" | "UUG" -> "Leucine"
    | "UCU" | "UCC" 
    | "UCA" | "UCG" -> "Serine"
    | "UAU" | "UAC" -> "Tyrosine"
    | "UGU" | "UGC" -> "Cysteine"
    | "UGG"         -> "Tryptophan"
    | "UAA" | "UAG"
    | "UGA"         -> "STOP"
    | _             -> raise <| exn "Unrecognized codon; throwing this way feels broken"

let concatNucleotides = Seq.fold (sprintf "%s%c") "" 

let translate input =
    input
    |> Seq.chunkBySize 3
    |> Seq.map (concatNucleotides >> toProtein)
    |> Seq.takeWhile (fun p -> p <> "STOP")
    |> Seq.toList
