module LinkedList


type Node = {
    mutable Previous: Option<Node>;
    mutable Next: Option<Node>;
    mutable Value: int;
};

type Root = {
    mutable First: Option<Node>;
    mutable Last: Option<Node>;
}

let mkLinkedList input = {First = None; Last = None;}

let push value (linkedList: Root) = 
    let node = { Previous = linkedList.Last; Next = None; Value = value}
    match linkedList.Last with
    | None -> 
        linkedList.First <- Some(node)
        linkedList.Last <- Some(node)
    | Some(x) ->
        linkedList.Last.Value.Next <- Some(node)
        node.Previous <- linkedList.Last
        linkedList.Last <- Some(node)
    

let pop linkedList =
    match linkedList.Last with
    | None -> failwith "The List is empty"
    | Some(node) -> 
        linkedList.Last <- node.Previous        
        node.Previous <- None
        node.Value

let shift linkedList =
    match linkedList.First with
    | None -> failwith "The List is empty"
    | Some(node) -> 
        linkedList.First <- node.Next
        node.Next <- None
        node.Value

let unshift value linkedList =
    let node = {Value = value; Next = linkedList.First; Previous = None}
    match linkedList.First with 
    | None -> 
        linkedList.First <- Some(node)
        linkedList.Last <- Some(node)
    | Some(n) ->
        linkedList.First.Value.Previous <- Some(node)
        linkedList.First <- Some(node)