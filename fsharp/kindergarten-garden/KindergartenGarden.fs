module KindergartenGarden

// TODO: define the Plant type
type Plant =
    | Clover
    | Grass
    | Radishes
    | Violets

let private studentMapper (s: string) : int =
    match s with
    | "Alice" -> 0
    | "Bob" -> 1
    | "Charlie" -> 2
    | "David" -> 3
    | "Eve" -> 4
    | "Fred" -> 5
    | "Ginny" -> 6
    | "Harriet" -> 7
    | "Ileana" -> 8
    | "Joseph" -> 9
    | "Kincaid" -> 10
    | "Larry" -> 11
    | _ -> 11

let private plantMapper (c: char) : Plant list =
    match c with
    | 'C' -> [Plant.Clover]
    | 'G' -> [Plant.Grass]
    | 'R' -> [Plant.Radishes]
    | 'V' -> [Plant.Violets]
    | _ -> []


let plants (diagram :string) student =
    let mutable db : Plant list = []
    let rows : string [] = diagram.Split [|'\n'|]
    let s = studentMapper student

    for row in rows do
        for i = s * 2 to s * 2 + 1 do
            db <- db @ (plantMapper row.[i])

    db
