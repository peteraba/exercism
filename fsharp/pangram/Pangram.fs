module Pangram

let isPangram (input : string) = set ['a' .. 'z'] - set (input.ToLower()) |> Set.isEmpty

