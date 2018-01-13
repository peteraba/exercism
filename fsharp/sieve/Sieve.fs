module Sieve

let primesUpTo limit =
    let sq = (limit |> float |> (fun n -> n ** 0.5) |> int )
    
    let filterMultiples possiblePrimes prime =
        if prime > sq then possiblePrimes
        else possiblePrimes |> List.filter (fun x -> x <= prime || x % prime <> 0)

    let possiblePrimes = [ 2 .. limit ]

    List.fold filterMultiples possiblePrimes possiblePrimes
