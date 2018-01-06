// This file was auto-generated based on version 1.0.0 of the canonical data.

module OcrNumbersTest

open FsUnit.Xunit
open Xunit

open OcrNumbers

[<Fact>]
let ``Recognizes 0`` () =
    let input = 
        [ " _ ";
          "| |";
          "|_|";
          "   " ]
    convert input |> should equal (Some "0")

[<Fact>]
let ``Recognizes 1`` () =
    let input = 
        [ "   ";
          "  |";
          "  |";
          "   " ]
    convert input |> should equal (Some "1")

[<Fact>]
let ``Unreadable but correctly sized inputs return ?`` () =
    let input = 
        [ "   ";
          "  _";
          "  |";
          "   " ]
    convert input |> should equal (Some "?")

[<Fact>]
let ``Input with a number of lines that is not a multiple of four raises an error`` () =
    let input = 
        [ " _ ";
          "| |";
          "   " ]
    convert input |> should equal None

[<Fact>]
let ``Input with a number of columns that is not a multiple of three raises an error`` () =
    let input = 
        [ "    ";
          "   |";
          "   |";
          "    " ]
    convert input |> should equal None

[<Fact>]
let ``Recognizes 110101100`` () =
    let input = 
        [ "       _     _        _  _ ";
          "  |  || |  || |  |  || || |";
          "  |  ||_|  ||_|  |  ||_||_|";
          "                           " ]
    convert input |> should equal (Some "110101100")

[<Fact>]
let ``Garbled numbers in a string are replaced with ?`` () =
    let input = 
        [ "       _     _           _ ";
          "  |  || |  || |     || || |";
          "  |  | _|  ||_|  |  ||_||_|";
          "                           " ]
    convert input |> should equal (Some "11?10?1?0")

[<Fact>]
let ``Recognizes 2`` () =
    let input = 
        [ " _ ";
          " _|";
          "|_ ";
          "   " ]
    convert input |> should equal (Some "2")

[<Fact>]
let ``Recognizes 3`` () =
    let input = 
        [ " _ ";
          " _|";
          " _|";
          "   " ]
    convert input |> should equal (Some "3")

[<Fact>]
let ``Recognizes 4`` () =
    let input = 
        [ "   ";
          "|_|";
          "  |";
          "   " ]
    convert input |> should equal (Some "4")

[<Fact>]
let ``Recognizes 5`` () =
    let input = 
        [ " _ ";
          "|_ ";
          " _|";
          "   " ]
    convert input |> should equal (Some "5")

[<Fact>]
let ``Recognizes 6`` () =
    let input = 
        [ " _ ";
          "|_ ";
          "|_|";
          "   " ]
    convert input |> should equal (Some "6")

[<Fact>]
let ``Recognizes 7`` () =
    let input = 
        [ " _ ";
          "  |";
          "  |";
          "   " ]
    convert input |> should equal (Some "7")

[<Fact>]
let ``Recognizes 8`` () =
    let input = 
        [ " _ ";
          "|_|";
          "|_|";
          "   " ]
    convert input |> should equal (Some "8")

[<Fact>]
let ``Recognizes 9`` () =
    let input = 
        [ " _ ";
          "|_|";
          " _|";
          "   " ]
    convert input |> should equal (Some "9")

[<Fact>]
let ``Recognizes string of decimal numbers`` () =
    let input = 
        [ "    _  _     _  _  _  _  _  _ ";
          "  | _| _||_||_ |_   ||_||_|| |";
          "  ||_  _|  | _||_|  ||_| _||_|";
          "                              " ]
    convert input |> should equal (Some "1234567890")

[<Fact>]
let ``Numbers separated by empty lines are recognized. Lines are joined by commas.`` () =
    let input = 
        [ "    _  _ ";
          "  | _| _|";
          "  ||_  _|";
          "         ";
          "    _  _ ";
          "|_||_ |_ ";
          "  | _||_|";
          "         ";
          " _  _  _ ";
          "  ||_||_|";
          "  ||_| _|";
          "         " ]
    convert input |> should equal (Some "123,456,789")

