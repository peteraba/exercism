module PerfectNumbers

type Classification = Perfect | Abundant | Deficient 

let classify n : Classification option =
    let chooseClassification sum =
        if sum = n then Some(Perfect)
        elif sum > n then Some(Abundant)
        else Some(Deficient)

    if n < 1 then None
    else
        [ 1 .. n / 2 ] 
        |> List.filter (fun x -> n % x = 0)
        |> List.sum
        |> chooseClassification