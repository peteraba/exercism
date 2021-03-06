// This file was auto-generated based on version 1.2.0 of the canonical data.

module PhoneNumberTest

open FsUnit.Xunit
open Xunit

open PhoneNumber

[<Fact>]
let ``Cleans the number`` () =
    clean "(223) 456-7890" |> should equal (Some "2234567890")

[<Fact>]
let ``Cleans numbers with dots`` () =
    clean "223.456.7890" |> should equal (Some "2234567890")

[<Fact>]
let ``Cleans numbers with multiple spaces`` () =
    clean "223 456   7890   " |> should equal (Some "2234567890")

[<Fact>]
let ``Invalid when 9 digits`` () =
    clean "123456789" |> should equal None

[<Fact>]
let ``Invalid when 11 digits does not start with a 1`` () =
    clean "22234567890" |> should equal None

[<Fact>]
let ``Valid when 11 digits and starting with 1`` () =
    clean "12234567890" |> should equal (Some "2234567890")

[<Fact>]
let ``Valid when 11 digits and starting with 1 even with punctuation`` () =
    clean "+1 (223) 456-7890" |> should equal (Some "2234567890")

[<Fact>]
let ``Invalid when more than 11 digits`` () =
    clean "321234567890" |> should equal None

[<Fact>]
let ``Invalid with letters`` () =
    clean "123-abc-7890" |> should equal None

[<Fact>]
let ``Invalid with punctuations`` () =
    clean "123-@:!-7890" |> should equal None

[<Fact>]
let ``Invalid if area code does not start with 2-9`` () =
    clean "(123) 456-7890" |> should equal None

[<Fact>]
let ``Invalid if exchange code does not start with 2-9`` () =
    clean "(223) 056-7890" |> should equal None

