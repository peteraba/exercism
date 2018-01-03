module Bob

open System.Text.RegularExpressions

let response (input: string): string =
    let trimmed = input.Trim()
    let isYelled = trimmed = trimmed.ToUpper() && not (trimmed = trimmed.ToLower())
    let isQuestion = trimmed.Length > 0 && trimmed.[trimmed.Length - 1] = '?'

    if trimmed.Length = 0 then "Fine. Be that way!"
    elif isYelled && isQuestion then "Calm down, I know what I'm doing!"
    elif isYelled then "Whoa, chill out!"
    elif isQuestion then "Sure."
    else "Whatever."