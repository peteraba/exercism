module Bob exposing (..)

hey : String -> String
hey input =
    let 
        trimmed =
            String.trim input

        isYelled =
            trimmed == String.toUpper trimmed && not (trimmed == String.toLower trimmed)
        
        isQuestion =
            String.endsWith "?" trimmed
        
    in
        if String.length trimmed == 0 then "Fine. Be that way!"
        else if isYelled then "Whoa, chill out!"
        else if isQuestion then "Sure."
        else "Whatever."