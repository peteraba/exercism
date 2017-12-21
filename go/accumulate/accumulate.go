package accumulate

const testVersion = 1

func Accumulate(given []string, converter func(string) string) []string {
	result := []string{}

	for _, str := range given {
		result = append(result, converter(str))
	}

	return result
}
