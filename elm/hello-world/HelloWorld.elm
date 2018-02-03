module HelloWorld exposing (..)

helloWorld : Maybe String -> String
helloWorld name =
    case name of
        Just x -> "Hello, " ++ x ++ "!"
        Nothing -> "Hello, World!"