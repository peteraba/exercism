<?php

$connect = new Connect();

function resultFor($lines)
{
    global $connect;

    if (!is_array($lines) || count($lines) === 0) {
        throw new InvalidArgumentException('Board must have at least lines');
    }

    switch ($connect->checkGame($lines)) {
        case Connect::WHITE:
            return 'white';
        case Connect::BLACK:
            return 'black';
    }

    return null;
}

class Connect
{
    const WHITE = 'O';
    const BLACK = 'X';

    /** @var array  */
    private $checked = [
        self::WHITE => [],
        self::BLACK => []
    ];

    /**
     * @param array $lines
     *
     * @return null|string
     */
    public function checkGame(array $lines)
    {
        $board = $this->getMatrix($lines);

        $this->checked = [
            self::WHITE => [],
            self::BLACK => []
        ];

        if ($this->hasWhiteWon($board)) {
            return self::WHITE;
        }

        if ($this->hasBlackWon($board)) {
            return self::BLACK;
        }

        return null;
    }

    /**
     * @param array $lines
     *
     * @return array
     */
    private function getMatrix(array $lines)
    {
        return array_map(function ($line) {
            return str_split($line);
        }, $lines);
    }

    /**
     * @param array $board
     *
     * @return bool
     */
    private function hasWhiteWon(array $board)
    {
        foreach ($board[0] as $pos => $char) {
            if ($char === self::WHITE && $this->isPathWinner($board, $pos, 0, self::WHITE)) {
                return true;
            }
        }

        return false;
    }

    /**
     * @param array $board
     *
     * @return bool
     */
    private function hasBlackWon(array $board)
    {
        foreach ($board as $pos => $line) {
            if ($line[0] === self::BLACK && $this->isPathWinner($board, 0, $pos, self::BLACK)) {
                return true;
            }
        }

        return false;
    }

    /**
     * @param array $board
     * @param int   $x
     * @param int   $y
     *
     * @return bool
     */
    private function isPathWinner(array $board, $x, $y, $color)
    {
        if (!$this->isValidPosition($board, $x, $y, $color) || $this->isCheckedPosition($x, $y, $color)) {
            return false;
        }

        if ($this->isWinnerPosition($board, $x, $y, $color)) {
            return true;
        }

        // Checking way forward
        for ($dx = 1; $dx >= -1; $dx--) {
            for ($dy = 1; $dy >= -1; $dy--) {
                if ($dx === 0 && $dy === 0) {
                    continue;
                }

                if ($this->isPathWinner($board, $x + $dx, $y - $dy, $color)) {
                    return true;
                }
            }
        }

        return false;
    }

    /**
     * @param array $board
     * @param int   $x
     * @param int   $y
     *
     * @return bool
     */
    private function isWinnerPosition(array $board, $x, $y, $color)
    {
        if ($color === self::WHITE && count($board) <= $y + 1) {
            return true;
        }

        if ($color === self::BLACK && count($board[0]) <= $x + 1) {
            return true;
        }

        return false;
    }

    /**
     * @param int    $x
     * @param int    $y
     * @param string $color
     *
     * @return bool
     */
    private function isCheckedPosition($x, $y, $color)
    {
        if (in_array("$x,$y", $this->checked[$color], true)) {
            return true;
        }

        $this->checked[$color][] = "$x,$y";

        return false;
    }

    /**
     * @param array  $board
     * @param int    $x
     * @param int    $y
     * @param string $color
     *
     * @return bool
     */
    private function isValidPosition(array $board, $x, $y, $color)
    {
        return isset($board[$y][$x]) && $board[$y][$x] === $color;
    }
}
