module DotDsl

let attr key value =
    sprintf "<attr %s=\"%s\"/>" key value

let attributes pairs =
    List.map (fun (key, value) -> sprintf "%s=\"%s\" " key value) pairs |> System.String.Concat

let node key attrs =
    sprintf "<node title=\"%s\" %s/>" key (attributes attrs)

let edge left right attrs =
    sprintf "<edge left=%s right=%s %s/>" left right (attributes attrs)

let graph children =
    children

let attrs graph =
    graph |> List.filter (fun (x: string) -> x.[0..4] = "<attr") |> List.sort

let nodes graph =
    graph |> List.filter (fun (x: string) -> x.[0..4] = "<node") |> List.sort

let edges graph =
    graph |> List.filter (fun (x: string) -> x.[0..4] = "<edge") |> List.sort
