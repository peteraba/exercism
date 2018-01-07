module PigLatin


let translate (input:string) =
    let realVowels = ["a"; "e"; "i"; "o"; "u" ]
    let vowels = ["yt"; "xr"] @ realVowels
    let extraConsonants = ["sch"; "thr"; "th"; "qu"; "ch"]

    let toString (list:char list) =
        new System.String(list |> List.toArray)

    let join (list:string seq) =
        System.String.Join(" ", list)

    let startsWithAny (haystack: string) (needles: string list): bool =
        needles |> List.exists (fun s -> haystack.StartsWith(s))

    let startsWith (haystack: string) (needles: string list): string option =
        needles |> List.tryFind (fun s -> haystack.StartsWith(s))

    let rec consonantsBeforeY (haystack: string) (acc: int): int =
        match haystack.[0 .. 0] with
        | "y" -> acc
        | x
            when not (List.exists (fun s -> s = x) realVowels)
            -> consonantsBeforeY haystack.[1 ..] (acc + 1)
        | _ -> 0

    let translateWord (word:string) =
        match startsWithAny word vowels with
        | true -> word + "ay"
        | false ->
            match startsWith word extraConsonants with
            | Some x -> word.Substring(x.Length) + x + "ay"
            | None ->
                let charList = word.ToCharArray() |> Array.toList

                match charList with
                | x :: 'q' :: 'u' :: rest ->
                    (rest @ [x; 'q'; 'u'] |> toString) + "ay"
                | x :: xs ->
                    match consonantsBeforeY word 0 with
                    | len when len > 0 -> word.[len .. ] + word.[0 .. len - 1] + "ay"
                    | _ -> (xs @ [x] |> toString) + "ay"
                | [] ->
                    failwith "Undefined behavior"

    input.Split([|' '|])
        |> Array.map translateWord
        |> join

