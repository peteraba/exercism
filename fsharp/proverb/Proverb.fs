module Proverb

let recite (input: string list): string list =
    let line i =
        if i >= input.Length - 1 then sprintf "And all for the want of a %s." input.[0]
        else sprintf "For want of a %s the %s was lost." input.[i] input.[i+1]
    
    if input.Length > 0 then [ for i in 0 .. input.Length - 1 -> line i ]
    else []
