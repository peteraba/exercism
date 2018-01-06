module OcrNumbers

let nums = Array.create 10 []

Array.set nums 0 [ " _ ";
                   "| |";
                   "|_|";
                   "   " ]

Array.set nums 1 [ "   ";
                   "  |";
                   "  |";
                   "   " ]

Array.set nums 2 [ " _ ";
                   " _|";
                   "|_ ";
                   "   " ]

Array.set nums 3 [ " _ ";
                   " _|";
                   " _|";
                   "   " ]

Array.set nums 4 [ "   ";
                   "|_|";
                   "  |";
                   "   " ]

Array.set nums 5 [ " _ ";
                   "|_ ";
                   " _|";
                   "   " ]

Array.set nums 6 [ " _ ";
                   "|_ ";
                   "|_|";
                   "   " ]

Array.set nums 7 [ " _ ";
                   "  |";
                   "  |";
                   "   " ]

Array.set nums 8 [ " _ ";
                   "|_|";
                   "|_|";
                   "   " ]

Array.set nums 9 [ " _ ";
                   "|_|";
                   " _|";
                   "   " ]

// input length should be dividable by 4
// every row should be dividable by 3
// every row should have the same length
let private convertCheck (input: string list): bool =
    match input with
    | [] -> true
    | _ when input.Length % 4 <> 0 -> false
    | head :: _ when head.Length % 3 <> 0 -> false
    | head :: _ ->
        let filtered = List.filter (fun (x: string) -> x.Length = head.Length) input

        filtered.Length = input.Length

let convert (input: string list): string option =
    match convertCheck input with
    | false -> None
    | true ->
        let mutable res = ""

        for i = 0 to input.Length / 4 - 1 do
            for j = 0 to input.[i*4].Length / 3 - 1 do
                let char = [ input.[i*4+0].[j*3 .. j*3+2];
                             input.[i*4+1].[j*3 .. j*3+2];
                             input.[i*4+2].[j*3 .. j*3+2];
                             input.[i*4+3].[j*3 .. j*3+2] ]

                let num = Array.tryFindIndex (fun elem -> elem = char) nums

                let nextChar =
                    match num with
                        | None -> "?"
                        | Some(x) -> string x

                res <- res + nextChar

            res <- res + ","

        res <- if res.Length <= 1 then res; else res.[0 .. res.Length-2];

        Some(res)
