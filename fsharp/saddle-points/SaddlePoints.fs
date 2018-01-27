module SaddlePoints

let saddlePoints (matrix: int list list): (int * int) list =
    let rowMax = [ for i in 0 .. matrix.Length - 1 -> matrix.[i] |> List.max ]
    let columnMin = [ 
        for i in 0 .. matrix.[0].Length - 1 -> 
            [ for j in 0 .. matrix.Length - 1 -> matrix.[j].[i] ] |> List.min ]

    let checkElem row column elem =
        if rowMax.[row] > elem then None
        elif columnMin.[column] < elem then None
        else Some(row, column)
        
    let checkRow row xs =
        List.mapi (fun column elem -> checkElem row column elem) xs

    matrix
    |> List.mapi checkRow
    |> List.concat
    |> List.filter (fun x -> x.IsSome)
    |> List.map (fun x -> x.Value)