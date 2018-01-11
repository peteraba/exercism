module Triangle
open System

type TriangleKind =
    | Equilateral
    | Isosceles
    | Scalene

let kind x y z =
    if x <= 0m || y <= 0m || z <= 0m then raise (InvalidOperationException("Invalid side length"))
    elif x + y < z || x + y < z || y + z < x then  raise (InvalidOperationException("Invalid triangle"))
    elif x = y && x = z then Equilateral
    elif x = y || x = z || y = z then Isosceles
    else Scalene
