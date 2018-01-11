module ProteinTranslationTest

open Xunit
open FsUnit.Xunit
open System

open ProteinTranslation

[<Theory>]
[<InlineData("AUG")>]
let ``Identifies Methionine codons`` (codon) =
    translate codon |> should equal ["Methionine"]
    
[<Theory>]
[<InlineData("UUU")>]
[<InlineData("UUC")>]
let ``Identifies Phenylalanine codons`` (codon) =
    translate codon |> should equal ["Phenylalanine"]
 
[<Theory>]   
[<InlineData("UUA")>]
[<InlineData("UUG")>]
let ``Identifies Leucine codons`` (codon) =
    translate codon |> should equal ["Leucine"]
    
[<Theory>]
[<InlineData("UCU")>]
[<InlineData("UCC")>]
[<InlineData("UCA")>]
[<InlineData("UCG")>]
let ``Identifies Serine codons`` (codon) =
    translate codon |> should equal ["Serine"]
    
[<Theory>]
[<InlineData("UAU")>]
[<InlineData("UAC")>]
let ``Identifies Tyrosine codons`` (codon) =
    translate codon |> should equal ["Tyrosine"]
    
[<Theory>]
[<InlineData("UGU")>]
[<InlineData("UGC")>]
let ``Identifies Cysteine codons`` (codon) =
    translate codon |> should equal ["Cysteine"]
    
[<Theory>]
[<InlineData("UGG")>] 
let ``Identifies Tryptophan codons`` (codon) =
    translate codon |> should equal ["Tryptophan"]

[<Fact>]
let ``Translates rna strand into correct protein`` () =
    translate "AUGUUUUGG" |> should equal ["Methionine"; "Phenylalanine"; "Tryptophan"]

[<Fact>]
let ``Stops translation if stop codon present`` () =
    translate "AUGUUUUAA" |> should equal ["Methionine"; "Phenylalanine"]

[<Fact>]
let ``Stops translation of longer strand`` () =
    translate "UGGUGUUAUUAAUGGUUU'" |> should equal ["Tryptophan"; "Cysteine"; "Tyrosine"]

[<Fact>]
let ``Throws for invalid codons`` () =
    (fun () -> translate "CARROT'" |> ignore) |> should throw typeof<Exception>