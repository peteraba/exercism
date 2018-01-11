module ScrabbleScore

let scoreList = [
    1, [ 'A'; 'E'; 'I'; 'O'; 'U'; 'L'; 'N'; 'R'; 'S'; 'T'; ];
    2, [ 'D'; 'G'; ];
    3, [ 'B'; 'C'; 'M'; 'P'; ];
    4, [ 'F'; 'H'; 'V'; 'W'; 'Y'; ];
    5, [ 'K'; ];
    8, [ 'J'; 'X'; ];
    10, [ 'Q'; 'Z'; ];
]

let transform (scoresWithLetters: Map<int, char list>): Map<char, int> =
    let elemToNewMap acc (score, charList): Map<char, int> =
        List.fold (fun acc ch -> acc.Add(ch, score)) acc charList
    
    scoresWithLetters
        |> Map.toSeq
        |> Seq.fold elemToNewMap Map.empty

let scoreMap = transform ( scoreList |> Map.ofList )

let score (word: string) =
    word.ToUpper() |> Seq.sumBy (fun a -> Map.find a scoreMap)