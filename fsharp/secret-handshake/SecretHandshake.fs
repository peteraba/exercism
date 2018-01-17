module SecretHandshake

type Sign =
    | Wink = 0b1
    | DoubleBlink = 0b10
    | CloseEyes = 0b100
    | Jump = 0b1000
    | Revert = 0b10000

let handshake number =
    let translate list sign =
        match sign with
        | Sign.Wink -> "wink" :: list
        | Sign.DoubleBlink -> "double blink" :: list
        | Sign.CloseEyes -> "close your eyes" :: list
        | Sign.Jump -> "jump" :: list
        | _ -> List.rev list

    let powersOfTwo = [ for i in [0 .. 5] -> 1 <<< i]

    [ for p in powersOfTwo do if p &&& number > 0 then yield enum<Sign> p ]
        |> List.fold translate []
        |> List.rev