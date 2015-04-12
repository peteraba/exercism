package diffsquares

func SquareOfSums(a int) int {
	sum := 0

	for i := 1; i <= a; i++ {
		sum += i
	}

	return sum * sum
}

func SumOfSquares(a int) int {
	sum := 0

	for i := 1; i <= a; i++ {
		sum += i * i
	}

	return sum
}

func Difference(a int) int {
	return SquareOfSums(a) - SumOfSquares(a)
}
