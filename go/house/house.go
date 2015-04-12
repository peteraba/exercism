package house

import "strings"

var realPhrases = []string{
	"the house that Jack built",
	"the malt\nthat lay in",
	"the rat\nthat ate",
	"the cat\nthat killed",
	"the dog\nthat worried",
	"the cow with the crumpled horn\nthat tossed",
	"the maiden all forlorn\nthat milked",
	"the man all tattered and torn\nthat kissed",
	"the priest all shaven and shorn\nthat married",
	"the rooster that crowed in the morn\nthat woke",
	"the farmer sowing his corn\nthat kept",
	"the horse and the hound and the horn\nthat belonged to",
}

func Embed(relPhrase, nounPhrase string) string {
	return relPhrase + " " + nounPhrase
}

func Verse(subject string, relPhrases []string, nounPhrase string) string {
	var phrasesCount = len(relPhrases)

	if phrasesCount > 0 {
		return Verse(subject, relPhrases[:phrasesCount-1], Embed(relPhrases[phrasesCount-1], nounPhrase))
	}

	return subject + " " + nounPhrase
}

func realVerse(num int) string {
	var (
		s = "This is"
		p = "."
		r = []string{}
	)

	for i := num; i >= 0; i-- {
		r = append(r, realPhrases[i])
	}

	return strings.Replace(Verse(s, r, p), " .", ".", -1)
}

func Song() string {
	var verses = []string{}

	for i := 0; i < len(realPhrases); i++ {
		verses = append(verses, realVerse(i))
	}

	return strings.Join(verses, "\n\n")
}
