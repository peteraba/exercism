package hamming

import "errors"

const testVersion = 6

func Distance(a, b string) (int, error) {
	if len(a) != len(b) {
		return -1, errors.New("Lengths of the provided strings are not equal.")
	}

	aBytes := []byte(a)
	bBytes := []byte(b)

	dist := 0
	for i, ch := range aBytes {
		ch2 := bBytes[i]
		if ch != ch2 {
			dist += 1
		}
	}

	return dist, nil
}
