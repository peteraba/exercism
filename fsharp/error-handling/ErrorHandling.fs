module ErrorHandling

let handleErrorByThrowingException() =
    raise (System.Exception "message")

let handleErrorByReturningOption (input: string) =
    try
        input |> int |> Some
    with
    | _ -> None

let handleErrorByReturningResult (input: string) =
    try
        Ok (input |> int)
    with
    | _ -> Error "Could not convert input to integer"


let bind switchFunction twoTrackInput =
    match twoTrackInput with
    | Error _ -> twoTrackInput
    | Ok x -> switchFunction x


let cleanupDisposablesWhenThrowingException resource =
    use a = resource
    printfn "%A" a
    failwith "Exception"
