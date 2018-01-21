module SimpleLinkedList
open System

//TODO: define LinkedList type
type List = {
    Next: List option
    Value: int option
}

let nil = {
    Next = None
    Value = None
}

let create x n =
    {
        Next = Some(n);
        Value = Some(x);
    }

let isNil x =
    x = nil

let next x =
    match x.Next with
    | None -> nil
    | Some(v) -> v

let datum x =
    match x.Value with
    | None -> 0
    | Some(y) -> y

let rec toList x =
    match x with
    | { Next = _; Value = None } -> []
    | { Next = None; Value = Some(v) } -> [v]
    | { Next = Some(n); Value = Some(v)} -> v :: (toList n)

let fromList xs =
    xs |> List.rev |> List.fold (fun acc elem -> create elem acc) nil

let reverse x =
    x |> toList |> List.rev |> fromList
    