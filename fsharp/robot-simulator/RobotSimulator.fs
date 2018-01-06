module RobotSimulator

type Bearing = North | East | South | West
type Coordinate = int * int

type Robot = { bearing: Bearing; coordinate: Coordinate }

let createRobot bearing coordinate =
    { bearing = bearing; coordinate = coordinate }

let turnLeft robot =
    let newBearing : Bearing =
        match robot.bearing with
            | North -> West
            | East -> North
            | South -> East
            | West -> South

    { robot with bearing = newBearing }

let turnRight robot =
    let newBearing : Bearing =
        match robot.bearing with
            | North -> East
            | East -> South
            | South -> West
            | West -> North

    { robot with bearing = newBearing }

let advance robot =
    let x, y = robot.coordinate
    let newCoordinate =
        match robot.bearing with
            | North -> x, y + 1
            | East -> x + 1, y
            | South ->x, y - 1
            | West -> x - 1, y

    { robot with coordinate = newCoordinate }

let private move robot instruction =
    match instruction with
    | 'L' -> turnLeft robot
    | 'R' -> turnRight robot
    | 'A' -> advance robot
    | _ -> robot

let simulate robot instructions = instructions |> Seq.fold move robot


