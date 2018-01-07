module ReverseString

let reverse (input: string): string =
    input.ToCharArray() 
        |> Array.rev
        |> System.String.Concat