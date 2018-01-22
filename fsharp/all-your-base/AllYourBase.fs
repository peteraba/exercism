module AllYourBase

open System

let rebase digits inputBase outputBase =
    let toTenBase digits =
        let folder (currentBase, sum) elem =
            currentBase * inputBase, sum + currentBase * elem

        let _, sum = digits |> List.rev |> List.fold folder (1, 0)

        sum

    let fromTenBase number =
        let unfolder remaining=
            let digit = remaining % outputBase
            let newRemaining = remaining / outputBase

            if remaining <= 0 then None
            else Some(digit, newRemaining)

        Seq.unfold unfolder number |> List.ofSeq |> List.rev
    
    if inputBase <= 1 || outputBase <= 1 then None
    elif List.exists (fun x -> x < 0 || x >= inputBase) digits then None
    elif not (List.exists (fun x -> x <> 0) digits) then Some [0]
    else
        digits 
        |> toTenBase
        |> fromTenBase
        |> Some