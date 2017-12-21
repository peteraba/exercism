package triangle

import "math"

type Kind int

const (
	Equ Kind = iota
	Iso
	Sca
	NaT
)

func KindFromSides(a, b, c float64) Kind {
	// Check Infinite sides
	if math.IsInf(a, 0) || math.IsInf(b, 0) || math.IsInf(c, 0) {
		return NaT
	}

	// Check Not-a-number sides
	if math.IsNaN(a) || math.IsNaN(b) || math.IsNaN(c) {
		return NaT
	}

	// Check negative sides
	if a <= 0.0 || b <= 0.0 || c <= 0.0 {
		return NaT
	}

	// Check invalid triangles
	if a+b <= c || a+c <= b || b+c <= a {
		return NaT
	}

	// Equ: All sides are equal
	if a == b && b == c {
		return Equ
	}

	// Iso: Two sides are equal but not all three
	if a == b || b == c || a == c {
		return Iso
	}

	// Sca: Valid triangles without equal sides
	return Sca
}
