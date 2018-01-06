module Clock

type Clock = {
    mutable hours: int;
    mutable minutes: int;
}

let create (hours: int) (minutes: int): Clock =
    let mutable m = minutes % 60
    let mutable h = (hours + (minutes / 60)) % 24

    h <- if m < 0 then h - 1; else h;

    while h < 0 do
        h <- h + 24
        
    while m < 0 do
        m <- m + 60
        
    {
        minutes = m
        hours = h
    }

let add (minutes: int) (clock: Clock): Clock =
    create clock.hours (clock.minutes + minutes)

let subtract (minutes: int) (clock: Clock): Clock =
    create clock.hours (clock.minutes - minutes)

let display (clock: Clock): string =
    sprintf "%02i:%02i" clock.hours clock.minutes
