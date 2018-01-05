module CollatzConjecture

let rec private substeps (number: int) (count: int): int =
    match number with
    | x when x % 2 = 0 -> substeps (number / 2) (count + 1)
    | x when x > 1 -> substeps (number * 3 + 1) (count + 1)
    | _ -> count

let steps (number: int): int option =
    let mutable count = 0
    let mutable y = number

    match number with
    | x when x <= 0 -> None
    | _ ->
        while y > 1 do
            y <- if y % 2 = 0 then y / 2; else 3 * y + 1;
            count <- count + 1

        Some(count)