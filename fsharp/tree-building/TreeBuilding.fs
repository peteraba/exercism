module TreeBuilding

type Record = { RecordId: int; ParentId: int }
type Tree = 
    | Branch of int * Tree list
    | Leaf of int

let recordId t = 
    match t with
    | Branch (id, c) -> id
    | Leaf id -> id

let isBranch t = 
    match t with
    | Branch (id, c) -> true
    | Leaf id -> false

let children t = 
    match t with
    | Branch (id, c) -> c
    | Leaf id -> []

let buildTree records = 
    let sortedRecords = List.sortBy (fun x -> x.RecordId) records

    if List.isEmpty records then failwith "Empty input"
    if sortedRecords.[0].ParentId <> 0 then failwith "Invalid root record"
    if [ for r in sortedRecords -> r.RecordId ] <> [ 0 .. sortedRecords.Length - 1 ] then failwith "Invalid records"

    let rec inject (record: Record) tree =
        match tree with
        | Leaf id when id = record.ParentId -> Branch (id, [ Leaf (record.RecordId) ] )
        | Branch (id, c) when id = record.ParentId -> Branch (id, c @ [ Leaf (record.RecordId) ])
        | Branch (id, children) -> Branch (id, [for c in children -> inject record c])
        | _ -> tree

    let recordListToTree (recordList: Record list) =
        let mutable tree = Leaf(0)

        for record in recordList.[1 .. ] do
            tree <- inject record tree

        tree

    let rec countNodes tree =
        match tree with
        | Leaf id -> 1
        | Branch (id, c) ->
            (List.sumBy countNodes c) + 1

    let tree = recordListToTree sortedRecords

    if countNodes tree < records.Length then failwith "Invalid data set: Either cycle found or parent was not found"

    tree

