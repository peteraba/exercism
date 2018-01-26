module PythagoreanTriplet

type Triplet = {
    x: int
    y: int
    z: int
}

let triplet x y z =
    let list = [ x; y; z ] |> List.sort

    { x = list.[0]; y = list.[1]; z = list.[2] }

let isPythagorean triplet =
    triplet.x * triplet.x + triplet.y * triplet.y = triplet.z * triplet.z

let pythagoreanTriplets min max =
    let filter (i: int, j: int, k: int): bool =
        if i + j <= k then false
        else triplet i j k |> isPythagorean

    let tripletize (i: int, j: int, k: int): Triplet =
        triplet i j k
    
    [ for i in min .. max do for j in i .. max do for k in j .. max do yield (i, j, k) ]
        |> List.filter filter
        |> List.map tripletize
