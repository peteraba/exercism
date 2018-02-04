module IsbnVerifier

let isValid (isbn: string) =
    let mapper char =
        match char with
        | 'X' -> 10
        | x when int x >= int '0' && int x <= int '9' -> int x - int '0'
        | _ -> -1

    let x = isbn |> Seq.map mapper |> Seq.filter (fun x -> x >= 0) |> List.ofSeq
    
    if List.length x <> 10 then false
    elif List.exists (fun x -> x = 10) x.[0 .. 8] then false
    else (x.[0] * 10 + x.[1] * 9 + x.[2] * 8 + x.[3] * 7 + x.[4] * 6 + x.[5] * 5 + x.[6] * 4 + x.[7] * 3 + x.[8] * 2 + x.[9]) % 11 = 0