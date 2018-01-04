module TwoFer

let name (input: string option): string =
    match input with
    | None -> "One for you, one for me."
    | Some(x) -> "One for" + x + ", one for me."