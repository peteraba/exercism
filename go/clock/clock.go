package clock

import "fmt"

const TestVersion = 2

const day_in_minutes = 60 * 24

type clock struct {
	minutes int
}

// Adds minutes to clock, chainable
func (c clock) Add(minutes int) clock {
	c.minutes += minutes

	if c.minutes < 0 {
		// c.minutes = -1485 minutes --> 1485 minutes / 1 day = 1 --> add 2 days
		c.minutes += day_in_minutes * ((-1 * c.minutes / day_in_minutes) + 1)
	}

	c.minutes %= day_in_minutes

	return c
}

// Stringer implementation
func (c clock) String() string {
	return fmt.Sprintf("%02d:%02d", c.minutes/60, c.minutes%60)
}

// Returns a new clock, non-pointer makes comparison work
func Time(hours int, minutes int) clock {
	c := clock{0}

	return c.Add(hours*60 + minutes)
}
