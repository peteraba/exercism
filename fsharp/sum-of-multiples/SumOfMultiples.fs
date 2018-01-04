module SumOfMultiples

let rec private isMultiple (numbers: int list) (number: int): bool =
    match numbers with
    | [] -> false
    | head :: tail when number % head = 0 -> true
    | head :: tail -> isMultiple tail number;
            
let sumOfMultiples (numbers: int list) (upperBound: int): int =
    match upperBound with
    | x when x < 1 -> 0
    | _ -> 
        let range = [ 1 .. upperBound - 1 ]
        let multiples = List.filter (isMultiple numbers) range

        List.sum multiples
