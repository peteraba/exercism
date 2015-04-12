package raindrops

import (
	"bytes"
	"fmt"
)

func Convert(drops int) string {
	var buffer bytes.Buffer

	if drops%3 == 0 {
		buffer.WriteString("Pling")
	}

	if drops%5 == 0 {
		buffer.WriteString("Plang")
	}

	if drops%7 == 0 {
		buffer.WriteString("Plong")
	}

	if buffer.Len() == 0 {
		return fmt.Sprint(drops)
	}

	return buffer.String()
}
