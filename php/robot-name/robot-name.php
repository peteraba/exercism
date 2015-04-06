<?php

class Robot
{
    private $name;

    /** @var  null|\NameGenerator */
    private $nameGenerator;

    /**
     * @param null|\NameGenerator $nameGenerator
     */
    public function __construct(\NameGenerator $nameGenerator = null)
    {
        if (null === $nameGenerator) {
            $nameGenerator = new \RobotNameGenerator;
        }

        $this->nameGenerator = $nameGenerator;
    }

    /**
     * @return string
     */
    public function getName()
    {
        if (null === $this->name) {
            $this->name = $this->nameGenerator->generateName();
        }

        return $this->name;
    }

    public function reset()
    {
        $this->name = null;
    }
}

interface NameGenerator
{
    public function generateName();
}

class RobotNameGenerator implements NameGenerator
{
    const CHARS = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';

    /**
     * @return string
     */
    public function generateName()
    {
        $robotName  = $this->getRandomChar() . $this->getRandomChar();
        $robotName .= $this->getRandomDigit() . $this->getRandomDigit() . $this->getRandomDigit();

        return $robotName;
    }

    private function getRandomChar()
    {
        return substr(static::CHARS, mt_rand(0, 25), 1);

    }

    private function getRandomDigit()
    {
        return mt_rand(0, 9);
    }
}

