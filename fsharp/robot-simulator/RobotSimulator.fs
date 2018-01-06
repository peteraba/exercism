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

    createRobot newBearing robot.coordinate

let turnRight robot =
    let newBearing : Bearing =
        match robot.bearing with
            | North -> East
            | East -> South
            | South -> West
            | West -> North

    createRobot newBearing robot.coordinate

let advance robot =
    let (x, y) = robot.coordinate
    let newCoordinate =
        match robot.bearing with
            | North -> (x, y + 1)
            | East -> (x + 1, y)
            | South ->(x, y - 1)
            | West -> (x - 1, y)

    createRobot robot.bearing newCoordinate

let simulate robot instructions =
    let mutable newRobot = robot
    let inst: string = instructions

    for i = 0 to inst.Length - 1 do
        newRobot <-
            match inst.[i..i] with
                | "L" -> turnLeft newRobot
                | "R" -> turnRight newRobot
                | "A" -> advance newRobot
                | _ -> newRobot

    newRobot


