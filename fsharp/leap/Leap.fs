module Leap

let leapYear (year: int): bool = 
    match year with
    | x when x % 4 <> 0 -> false
    | x when x % 100 = 0 -> x % 400 = 0
    | _ -> true
