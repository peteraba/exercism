module SpaceAge

let private year = 31557600m
let private workaround = 1000000000m

// TODO: define the Planet type
type Planet =
    | Earth    = 1000000000UL
    | Mercury  = 240846700UL
    | Venus    = 615197260UL
    | Mars     = 1880815800UL
    | Jupiter  = 11862615000UL
    | Saturn   = 29447498000UL
    | Uranus   = 84016846000UL
    | Neptune  = 164791320000UL

let spaceAge (planet: Planet) (seconds: decimal): decimal =
    let p = uint64 planet
    let planet_year_in_seconds = decimal p / workaround * year
    System.Math.Round(seconds / planet_year_in_seconds, 2)