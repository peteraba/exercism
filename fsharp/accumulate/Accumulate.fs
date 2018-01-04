module Accumulate

let accumulate<'a, 'b> (func: 'a -> 'b) (input: 'a list): 'b list =
    [ for a in input -> func a ]
