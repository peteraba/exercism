<?php

function resultFor($lines)
{
    if (!is_array($lines) || count($lines) === 0) {
        throw new InvalidArgumentException('Board must have at least lines');
    }

    $connect = new Connect();

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
    private $whiteChecked = [];

    /** @var array */
    private $blackChecked = [];

    /**
     * @param array $lines
     *
     * @return null|string
     */
    public function checkGame(array $lines)
    {
        $board = $this->getMatrix($lines);

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
            if ($char === self::WHITE && $this->isWhitePathWinner($board, $pos, 0)) {
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
            if ($line[0] === self::BLACK && $this->isBlackPathWinner($board, 0, $pos)) {
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
    private function isWhitePathWinner(array $board, $x, $y)
    {
        if (!$this->validPosition($board, $x, $y, self::WHITE)) {
            return false;
        }

        if (count($board) <= $y + 1) {
            return true;
        }

        if (in_array("$x,$y", $this->whiteChecked, true)) {
            return false;
        }
        $this->whiteChecked[] = "$x,$y";

        // Checking way forward
        for ($dx = -1; $dx <= 1; $dx++) {
            for ($dy = -1; $dy <= 1; $dy++) {
                if ($dx === 0 && $dy === 0) {
                    continue;
                }

                if ($this->isWhitePathWinner($board, $x + $dx, $y - $dy)) {
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
    private function isBlackPathWinner(array $board, $x, $y)
    {
        if (!$this->validPosition($board, $x, $y, self::BLACK)) {
            return false;
        }

        if (count($board[0]) <= $x + 1) {
            return true;
        }

        // Skip if position is already checked
        if (in_array("$x,$y", $this->blackChecked, true)) {
            return false;
        }
        $this->blackChecked[] = "$x,$y";

        // Checking way forward
        for ($dx = -1; $dx <= 1; $dx++) {
            for ($dy = -1; $dy <= 1; $dy++) {
                if ($dx === 0 && $dy === 0) {
                    continue;
                }

                if ($this->isBlackPathWinner($board, $x + $dx, $y - $dy)) {
                    return true;
                }
            }
        }

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
    private function validPosition(array $board, $x, $y, $color)
    {
        return isset($board[$y][$x]) && $board[$y][$x] === $color;
    }
}
