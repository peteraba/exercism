<?php

class Game
{
    const NOTHING = 0;
    const SPARE   = 1;
    const STRIKE  = 2;

    /** @var int  */
    protected $previous = self::NOTHING;

    /** @var int */
    protected $prevPrevious = self::NOTHING;

    /** @var int */
    protected $score = 0;

    /** @var int */
    protected $frameCount = 1;

    /** @var array */
    protected $currentFrame = [];

    /**
     * @param int $pins
     */
    public function roll($pins)
    {
        if ($this->frameCount > 10) {
            throw new InvalidArgumentException('Game is already closed.');
        }
        if ($pins < 0 || $pins > 10) {
            throw new InvalidArgumentException('Are you playing Ten-pin bowling?');
        }

        $pins = (int)$pins;

        $this->updateScoreSum($pins);
        $this->updateCurrentFrame($pins);
        $this->updatePreviousStates();
        $this->checkCurrentFrame();
    }

    /**
     * @param int $pins
     */
    private function updateScoreSum($pins)
    {
        if ($this->previous !== self::NOTHING) {
            $this->score += $pins;
        }

        if ($this->prevPrevious !== self::NOTHING) {
            $this->score += $pins;
        }
    }

    /**
     * @param int $pins
     */
    private function updateCurrentFrame($pins)
    {
        $this->currentFrame[] = $pins;
    }

    private function updatePreviousStates()
    {
        $this->prevPrevious = $this->previous === self::STRIKE ? self::STRIKE : self::NOTHING;
        $this->previous     = self::NOTHING;

        // Strikes or spares in the last frame don't collect further points but allow a 3rd shot
        if ($this->getSum() === 10 && !$this->isLastFrame()) {
            $this->previous = $this->getSize() === 1 ? self::STRIKE : self::SPARE;
        }
    }

    /**
     * @return bool
     */
    private function checkCurrentFrame()
    {
        if ($this->frameCount < 10 && ($this->getSum() === 10 || $this->getSize() === 2)) {
            return $this->closeCurrentFrame();
        }

        // In the last frame there are special cases
        if ($this->isLastFrame()) {
            // Frame can be closed normally if no strike or spare was scored
            if ($this->getSize() === 2 &&
                $this->currentFrame[0] !== 10 &&
                $this->getSum() !== 10) {
                return $this->closeCurrentFrame();
            }

            // Or after 3 shots
            if ($this->getSize() === 3) {
                return $this->closeCurrentFrame();
            }
        }

        return false;
    }

    /**
     * @return int
     */
    private function getSize()
    {
        return count($this->currentFrame);
    }

    /**
     * @return int
     */
    private function getSum()
    {
        return array_sum($this->currentFrame);
    }

    /**
     * @return bool
     */
    private function isLastFrame()
    {
        return $this->frameCount === 10;
    }

    /**
     * @return bool
     */
    private function closeCurrentFrame()
    {
        $this->score        += $this->getSum();
        $this->currentFrame  = [];

        $this->frameCount++;

        return true;
    }

    /**
     * @return int
     */
    public function score()
    {
        return $this->score + $this->getSum();
    }
}
