module QueenAttack

let create (position: int * int) =
    match position with
    | (x, _) when x < 0 || x >= 8 -> false
    | (_, y) when y < 0 || y >= 8 -> false
    | _ -> true

let canAttack (queen1: int * int) (queen2: int * int) =
    let (x2, y2) = queen2

    match queen1 with
    | (x1, y1) when x1 = x2 || y1 = y2 -> true
    | (x1, y1) when System.Math.Abs(x1 - x2) = System.Math.Abs(y1 - y2) -> true
    | _ -> false
