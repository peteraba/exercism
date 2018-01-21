module Acronym

open System.Text.RegularExpressions

let abbreviate phrase =
    Regex.Matches(phrase, @"\w+('\w+)*")
    |> Seq.cast<Match>
    |> Seq.map (fun x -> x.Value.[0 .. 0])
    |> System.String.Concat
    |> (fun x -> x.ToUpper())
