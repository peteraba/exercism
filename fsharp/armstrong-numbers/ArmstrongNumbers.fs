module ArmstrongNumbers

let private pow (number: int) (power: int): int =
    let mutable s = number

    for i = 1 to power - 1 do
        s <- s * number

    s
    
let isArmstrongNumber (number: int): bool =
    let str = string number
    let len = str.Length
    let mutable powered = 0

    for i = 0 to len-1 do
        let value = str.[i..i] |> int
        let p = pow value len
        powered <- powered + p

    number = powered

