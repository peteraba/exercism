module PigLatin

let translate (input: string) =
    let translateWord (word: string): string =
        let vowels = "aeiou"
        let vowelDoubles = [ "yt"; "xr" ]
        let consonantDoubles = [ "ch"; "th"; "qu" ]
        let consonantTriples = [ "sch"; "thr" ]

        let short2 = if word.Length >= 2 then word.[0 .. 1]; else "";
        let short3 = if word.Length >= 3 then word.[0 .. 2]; else "";
        let short2b = if word.Length >= 3 then word.[1 .. 2]; else "";

        let handleYAfterConsonant word =
            if word = "rhythm" then "ythmrhay"; else word

        let isVowel ch =
            String.exists (fun c -> c = ch) vowels

        match word, short2, short3, short2b with
            // [consonant]qa*
            | x, _, z, w
                when w = "qu" && not (isVowel x.[0])
                -> word.[3 .. ] + z + "ay"

            // sch*, thr*
            | x, _, z, _
                when None <> (List.tryFind (fun elem -> elem = z) consonantTriples)
                -> word.[3 .. ] + z + "ay"

            // .y
            | _, y, "", _
                when y.[1] = 'y'
                -> "y" + y.[0 .. 0] + "ay"

            // ch*, th*, qu*
            | x, y, _, _
                when None <> (List.tryFind (fun elem -> elem = y) consonantDoubles)
                -> word.[2 .. ] + y + "ay"

            // yt*, xr*
            | x, y, _, _
                when None <> (List.tryFind (fun elem -> elem = y) vowelDoubles)
                -> y + word.[2 .. ] + "ay"

            // *
            | x, _, _, _
                when x <> ""
                ->
                    let consonantAfterY = handleYAfterConsonant x
                    let vowelFirst = isVowel x.[0]

                    match consonantAfterY, vowelFirst with
                    // [consonant]+y*
                    | x2, _ when x <> x2 -> x2
                    // [vowel]*
                    | _, true -> x + "ay"
                    // [consonant]*
                    | _, false -> x.[1 .. ] + x.[0 .. 0] + "ay"

            // -
            | _, _, _, _
                -> failwith "Undefined behaviour"

    List.map translateWord (input.Split [|' '|] |> List.ofArray)
        |> List.fold (fun r s -> r + s + " ") ""
        |> (fun x -> x.Trim() )
