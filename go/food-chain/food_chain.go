package foodchain

import (
	"fmt"
	"strings"
)

const TestVersion = 1

const firstLine = "I know an old lady who swallowed a %s."

const middleLine = "She swallowed the %s to catch the %s%s."

type animal struct {
	name, secondLine, thatPart string
}

var animals = []animal{
	animal{"fly", "I don't know why she swallowed the fly. Perhaps she'll die.", ""},
	animal{"spider", "It wriggled and jiggled and tickled inside her.", ""},
	animal{"bird", "How absurd to swallow a bird!", " that wriggled and jiggled and tickled inside her"},
	animal{"cat", "Imagine that, to swallow a cat!", ""},
	animal{"dog", "What a hog, to swallow a dog!", ""},
	animal{"goat", "Just opened her throat and swallowed a goat!", ""},
	animal{"cow", "I don't know how she swallowed a cow!", ""},
	animal{"horse", "She's dead, of course!", ""},
}

func swallowLines(n int) string {
	if n > 7 {
		return ""
	}

	verse := []string{}

	var current, next animal
	var line string

	for i := n; i > 1; i-- {
		current = animals[i-1]
		next = animals[i-2]
		line = fmt.Sprintf(middleLine, current.name, next.name, current.thatPart)
		verse = append(verse, line)
	}

	if n > 1 {
		verse = append(verse, animals[0].secondLine)
	}

	return strings.Join(verse, "\n")
}

func Verse(n int) string {
	if n < 1 || 8 < n {
		return ""
	}

	var currentAnimal = animals[n-1]

	verse := []string{
		fmt.Sprintf(firstLine, currentAnimal.name),
		currentAnimal.secondLine,
	}

	var extraLines string = swallowLines(n)

	if extraLines != "" {
		verse = append(verse, extraLines)
	}

	return strings.Join(verse, "\n")
}

func Verses(start, end int) string {
	if start <= 0 || 8 < end || end < start {
		return ""
	}

	verses := make([]string, 0, end-start+1)
	for i := start; i <= end; i++ {
		verses = append(verses, Verse(i))
	}

	return strings.Join(verses, "\n\n")
}

func Song() string {
	return Verses(1, 8)
}
