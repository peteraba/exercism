package secret

const (
	wink = 1 << iota
	doubleBlink
	closeEyes
	jump
	reverse
)

func Handshake(code int) []string {
	commands := []string{}

	if code < 0 || code >= reverse*2 {
		return commands
	}

	if code&wink != 0 {
		commands = append(commands, "wink")
	}

	if code&doubleBlink != 0 {
		commands = append(commands, "double blink")
	}

	if code&closeEyes != 0 {
		commands = append(commands, "close your eyes")
	}

	if code&jump != 0 {
		commands = append(commands, "jump")
	}

	if code&reverse != 0 {
		for i, j := 0, len(commands)-1; i < j; i, j = i+1, j-1 {
			commands[i], commands[j] = commands[j], commands[i]
		}
	}

	return commands
}
