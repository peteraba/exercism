module BinarySearchTree

type Tree = {
    Value: int option;
    Left: Tree option;
    Right: Tree option;
}

let left node  =
    node.Left

let right node =
    node.Right

let value node =
    node.Value

let singleton value =
    { Value = Some(value); Left = None; Right = None }

let rec insert newValue tree =
    match tree.Value with
    | None -> { tree with Value = Some(newValue) }
    | Some(x) when x >= newValue ->
        match tree.Left with
        | None -> { tree with Left = Some(singleton newValue) }
        | Some(y) -> { tree with Left = Some(insert newValue y) }
    | Some(x) ->
        match tree.Right with
        | None -> { tree with Right = Some(singleton newValue) }
        | Some(y) -> { tree with Right = Some(insert newValue y) }

let toList tree =
    let rec accToList trees ints =
        match trees with 
        | [] -> ints
        | { Value = None; Left = _; Right = _ } :: tail -> failwith "Invalid node found"
        | { Value = Some(v); Left = l; Right = r } :: tail ->
            let newTrees =
                match l, r with
                | None, None -> tail
                | Some(x), None -> x :: tail
                | None, Some(y) -> y :: tail
                | Some(x), Some(y) -> x :: y :: tail

            accToList newTrees (v :: ints)

    List.sort (accToList [tree] [])

let fromList xs =
    let e = { Value = None; Left = None; Right = None }
    List.fold (fun acc elem -> insert elem acc) e xs
