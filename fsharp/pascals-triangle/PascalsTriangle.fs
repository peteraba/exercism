module PascalsTriangle

let rows numberOfRows : int list list option =
    let row (previousRow: int list) : int list =
        [
            for i in 0 .. previousRow.Length ->
                if i = 0 then 1
                elif i = previousRow.Length then 1
                else previousRow.[i - 1] + previousRow.[i]
        ]

    let unfolder (currentRow, previous) =
        if currentRow >= numberOfRows then None 
        else 
            let thisRow = row previous
            Some(thisRow, (currentRow + 1, thisRow))


    if numberOfRows < 0 then None
    else Seq.unfold unfolder (0, []) |> List.ofSeq |> Some