module Anagram

open System

let anagrams sources (target: string) =
    let lowerTarget = target.ToLower()
    let sortedTarget = lowerTarget |> Seq.sort |> String.Concat
    
    let isSame (source: string): bool =
        let lowerSource = source.ToLower()

        if lowerSource = lowerTarget then false
        else sortedTarget = (lowerSource |> Seq.sort |> String.Concat)

    sources |> List.filter isSame