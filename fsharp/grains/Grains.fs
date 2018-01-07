module Grains

type Result<'a, 'b> =
    | Ok of 'a
    | Error of 'b

let square (n: int): Result<uint64,string> =
    match n with
    | x when x < 1 || x > 64 -> Error("Invalid input")
    | x -> Ok(1UL <<< (x - 1))

let total: Result<uint64,string> =
    // Hardcoded would be hard to outperform: Ok(18446744073709551615UL)

    let resultSum x =
        match x with
        | Ok(n) -> n
        | Error(e) -> 0UL

    [ for i in 1 .. 64 -> square i ] |> List.sumBy resultSum |> Ok

