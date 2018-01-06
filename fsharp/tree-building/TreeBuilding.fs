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
    let records' = List.sortBy (fun x -> x.RecordId) records

    let rec inject tree parentId recordId =
        match tree with
        | Leaf id when id = parentId -> Branch (id, [ Leaf (recordId) ] )
        | Branch (id, c) when id = parentId -> Branch (id, c @ [ Leaf (recordId) ])
        | Branch (id, children) ->
            let newChildren = [for c in children -> inject c parentId recordId]

            Branch (id, newChildren)
        | _ -> tree

    let rec countChildren tree =
        match tree with
        | Leaf id -> 1
        | Branch (id, c) ->
            (List.sumBy countChildren c) + 1

    match records' with
    | [] -> failwith "Empty input"
    | x when [ for r in x -> r.RecordId ] <> [ 0 .. x.Length - 1 ] -> failwith "Invalid records"
    | { RecordId = 0; ParentId = 0 } :: tail ->
        let mutable tree = Leaf(0)

        for record in tail do
            tree <- inject tree record.ParentId record.RecordId

        if countChildren tree = records.Length then tree; else failwith "Cycle found"
    | _ -> failwith "Root node is invalid"

