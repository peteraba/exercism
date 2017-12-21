package diffsquares

func SquareOfSums(num int) int {
	// https://www.google.de/search?q=sum+of+sequence
	sqsum := num * (1 + num) / 2

	return sqsum * sqsum
}

func SumOfSquares(num int) int {
	// http://www.trans4mind.com/personal_development/mathematics/series/sumNaturalSquares.htm
	return num * (num + 1) * (2*num + 1) / 6
}

func Difference(num int) int {
	return SquareOfSums(num) - SumOfSquares(num)
}
