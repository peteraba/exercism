package gigasecond

import (
	"math"
	"time"
)

const TestVersion = 2

var Birthday = time.Date(1981, 8, 17, 8, 0, 0, 0, time.UTC)

func AddGigasecond(t time.Time) time.Time {
	return t.Add(time.Duration(math.Pow10(9)) * time.Second)
}
