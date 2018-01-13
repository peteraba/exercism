module PhoneNumber

let clean (input: string): string option =
    let twoToNine ch =
        int ch >= int '2' && int ch <= int '9'
    
    let rawNums = input |> String.filter System.Char.IsDigit

    let nums =
        if rawNums.Length = 11 && rawNums.[0] = '1'
        then rawNums.[1 ..]
        else rawNums

    if nums.Length <> 10 then None
    elif not (twoToNine nums.[0]) then None
    elif not (twoToNine nums.[3]) then None
    else Some(nums)