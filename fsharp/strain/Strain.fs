module Seq

let keep pred xs =
    xs |> Seq.filter (pred)

let discard pred xs =
    xs |> Seq.filter (pred >> not)
