import calendar

class MeetupDayException(Exception):
    pass

def meetup_day(year, month, weekday, selector):

    cal = calendar.Calendar()

    for date in cal.itermonthdates(year, month):

        if date.strftime("%A") != weekday:
            continue

        if 13 <= date.day <= 19 and selector == 'teenth':
            return date

        if date.day < 8 and selector == '1st':
            return date

        if 8 <= date.day < 15 and selector == '2nd':
            return date

        if 15 <= date.day < 22 and selector == '3rd':
            return date

        if 22 <= date.day < 29 and selector == '4th':
            return date

        if 29 <= date.day and selector == '5th':
            return date

        if selector == 'last' and date.day > calendar.monthrange(year, month)[1] - 7:
            return date

    raise MeetupDayException
