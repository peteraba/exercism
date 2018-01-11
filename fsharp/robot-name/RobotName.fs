module RobotName

type Robot = {
    name: string;
}

let private rnd = System.Random()

let private randomName() =
    let chars = System.String [|for _ in 1..2 -> rnd.Next(26) + 65 |> char|]
    let nums = System.String [|for _ in 1..3 -> rnd.Next(10) + 48 |> char|]

    chars + nums

let mkRobot() =
    { name = randomName () }

let name robot =
    robot.name

let reset robot =
    { robot with name = randomName () }