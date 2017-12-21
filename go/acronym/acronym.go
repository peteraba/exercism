package acronym

import (
	"bytes"
	"strings"
)

const testVersion = 2

func Abbreviate(str string) string {
	var b bytes.Buffer

	for _, word := range strings.Split(str, " ") {
		b.Write([]byte(word[:1]))
	}

	return strings.ToUpper(b.String())
}
