module Matrix

type Matrix = {
    data: int[,]
}

let fromString str =
    let parseRow (x: string) =
        x.Split [|' '|] |> Array.map System.Convert.ToInt32
    
    let parseTable (x: string) =
        x.Split [|'\n'|] |> Array.map parseRow |> array2D
    
    { data = parseTable str }


let rows matrix =
    let len = Array2D.length1 matrix.data - 1

    [| for i in 0 .. len -> matrix.data.[i, *] |]

let cols matrix =
    let len = Array2D.length2 matrix.data - 1

    [| for i in 0 .. len -> matrix.data.[*, i] |]
