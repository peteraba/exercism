module PrimeFactors

let rec nextPrime primes candidate =
    if List.exists (fun prime -> candidate % prime = 0L) primes
    then nextPrime primes (candidate + 1L)
    else candidate

let square number =
    number |> float |> (fun n -> n ** 0.5) |> int64

let factors number =
    let mutable primes = []

    let rec subFactors number candidate acc =
        if number = 1L then acc
        elif number < candidate then failwith "Illegal result"
        elif number % candidate = 0L then subFactors (number / candidate) candidate (candidate :: acc)
        elif square number < candidate then number :: acc
        else
            let n = nextPrime primes candidate 

            primes <- n :: primes

            subFactors number n acc

    subFactors number 2L [] |> List.map int |> List.rev