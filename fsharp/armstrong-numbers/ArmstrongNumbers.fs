module ArmstrongNumbers
    
let isArmstrongNumber (number: int): bool =
    let str = string number
    let len = str.Length
    let mutable powered = 0

    for i = 0 to len-1 do
        let value = str.[i..i] |> int
        let p = value ** len
        powered <- powered + p

    number = powered

