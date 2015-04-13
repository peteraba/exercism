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

    protected static $robotCount = 0;
    
    /**
     * @return string
     */
    public function generateName()
    {
        $name = $this->getChars() . $this->getNums();

        static::$robotCount++;

        return $name;
    }

    private function getChars()
    {
        $charsCount = strlen(self::CHARS);

        $charsNum = floor(static::$robotCount / 1000);

        $firstCharNum = floor($charsNum / $charsCount) % $charsCount;

        $secondCharNum = $charsNum % $charsCount;

        return substr(self::CHARS, $firstCharNum, 1) . substr(self::CHARS, $secondCharNum, 1);
    }

    private function getNums()
    {
        return sprintf("%03d", static::$robotCount % 1000);
    }
}

