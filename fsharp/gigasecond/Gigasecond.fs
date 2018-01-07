module Gigasecond

open System

let add (beginDate: DateTime): DateTime =
    beginDate.AddSeconds(1000000000.0)
