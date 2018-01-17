module BinarySearch

let find (input: int array) value =
    let rec findStep (input: int array) start stop value =
        let mid = (start + stop) / 2

        if start >= input.Length then None
        elif start = stop && value <> input.[mid] then None
        elif value = input.[mid] then Some mid
        else
            let newStart, newStop = if value < input.[mid] then start, mid; else mid+1, stop
            
            findStep input newStart newStop value

    findStep input 0 input.Length value
