module Meetup

open System

type Week = First | Second | Third | Fourth | Last | Teenth

let meetup year month week (dayOfWeek: DayOfWeek): DateTime =
    let firstDayOfMonth = DateTime(year, month, 1)

    let dayToDayPlus = ((Convert.ToInt32 dayOfWeek) - (Convert.ToInt32 firstDayOfMonth.DayOfWeek) + 7) % 7
    
    let keepInMonth dayOfMonth =
        let monthLength = DateTime.DaysInMonth(year, month)

        if monthLength >= dayOfMonth then dayOfMonth
        elif monthLength >= dayOfMonth - 7 then dayOfMonth - 7
        else dayOfMonth - 14

    match week with
    | First -> DateTime(year, month, 1 + dayToDayPlus)
    | Second -> DateTime(year, month, 8 + dayToDayPlus)
    | Third -> DateTime(year, month, 15 + dayToDayPlus)
    | Fourth -> DateTime(year, month, keepInMonth (22 + dayToDayPlus))
    | Last -> DateTime(year, month, keepInMonth (29 + dayToDayPlus))
    | Teenth when 8 + dayToDayPlus > 12 -> DateTime(year, month, keepInMonth (8 + dayToDayPlus))
    | Teenth -> DateTime(year, month, keepInMonth (15 + dayToDayPlus))