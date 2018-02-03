module HelloWorld exposing (..)

helloWorld : Maybe String -> String
helloWorld name =
    case name of
        Just x -> "Hello, " ++ x ++ "!"
        Nothing -> "Hello, World!"



{-
   When you have a working solution, REMOVE ALL THE STOCK COMMENTS.
   They're here to help you get started but they only clutter a finished solution.
   If you leave them in, nitpickers will protest!
-}
