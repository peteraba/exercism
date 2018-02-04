module RomanNumerals

let roman arabicNumeral =
    let singles arabicNumeral =
        match (arabicNumeral % 10) with
        | 1 -> "I"
        | 2 -> "II"
        | 3 -> "III"
        | 4 -> "IV"
        | 5 -> "V"
        | 6 -> "VI"
        | 7 -> "VII"
        | 8 -> "VIII"
        | 9 -> "IX"
        | _ -> ""

    let tens arabicNumeral =
        match (arabicNumeral % 100) / 10 with
        | 1 -> "X"
        | 2 -> "XX"
        | 3 -> "XXX"
        | 4 -> "XL"
        | 5 -> "L"
        | 6 -> "LX"
        | 7 -> "LXX"
        | 8 -> "LXXX"
        | 9 -> "XC"
        | _ -> ""

    let hundreds arabicNumeral =
        match (arabicNumeral % 1000) / 100 with
        | 1 -> "C"
        | 2 -> "CC"
        | 3 -> "CCC"
        | 4 -> "CD"
        | 5 -> "D"
        | 6 -> "CD"
        | 7 -> "CDD"
        | 8 -> "CDDD"
        | 9 -> "CM"
        | _ -> ""

    let thousands arabicNumeral =
        match arabicNumeral / 1000 with
        | 1 -> "M"
        | 2 -> "MM"
        | 3 -> "MMM"
        | _ -> ""

    System.String.Concat [thousands arabicNumeral; hundreds arabicNumeral; tens arabicNumeral; singles arabicNumeral]