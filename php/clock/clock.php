<?php

class Clock
{
    const DAY_MINUTES = 1440;

    /** @var int */
    private $minutes;

    /**
     * @param int $hours
     * @param int $minutes
     */
    public function __construct($hours, $minutes = 0)
    {
        $this->minutes = $hours * 60 + $minutes;
    }

    public function add($minutes)
    {
        if (!is_numeric($minutes) || $minutes < 0) {
            throw new \InvalidArgumentException('Clock can only add positive numbers.');
        }

        $this->minutes += $minutes % self::DAY_MINUTES;

        if ($this->minutes > self::DAY_MINUTES) {
            $this->minutes -= self::DAY_MINUTES;
        }

        return $this;
    }

    public function sub($minutes)
    {
        if (!is_numeric($minutes) || $minutes < 0) {
            throw new \InvalidArgumentException('Clock can only subtract positive numbers.');
        }

        $this->minutes -= $minutes % self::DAY_MINUTES;

        if ($this->minutes < 0) {
            $this->minutes += self::DAY_MINUTES;
        }

        return $this;
    }

    /**
     * @return string
     */
    public function __toString()
    {
        $hours = floor($this->minutes / 60);

        $minutes = $this->minutes % 60;

        return sprintf("%02d:%02d", $hours, $minutes);
    }
}
