module ListOps
open System.Globalization

let rec foldl folder state list =
    match list with
    | [] -> state
    | head :: tail -> foldl folder (folder state head) tail

let reverse (list: 'a list) =
    seq { for n in 1 .. list.Length do yield list.[list.Length - n] } |> List.ofSeq

let rec foldr folder state list =
    match reverse list with
    | [] -> state
    | head :: tail -> foldr folder (folder head state) tail

let length list =
    let rec recLength acc list =
        match list with
        | [] -> acc
        | _ :: tail -> recLength (acc + 1) tail 
    
    recLength 0 list

let map f (list: 'a list) =
    seq { for n in 0 .. list.Length - 1 do yield f list.[n] } |> List.ofSeq

let filter f (list: 'a list) =
    seq { for n in 0 .. list.Length - 1 do if f list.[n] then yield list.[n] } |> List.ofSeq

let append xs ys =
    xs @ ys

let rec concat (xs: 'a list list): ('a list) =
    if xs.Length < 1 then []
    elif xs.Length = 1 then xs.[0]
    else append xs.[0] (concat xs.[1 .. xs.Length - 1])