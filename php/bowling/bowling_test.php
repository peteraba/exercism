<?php

require "bowling.php";

/**
 * Translated from original source:
 * http://butunclebob.com/ArticleS.UncleBob.TheBowlingGameKata
 */
class GameTest extends \PHPUnit_Framework_TestCase
{
    /** @var Game */
    private $game;

    public function setUp()
    {
        $this->game = new Game();
    }

    public function testGutterGame()
    {
        $this->rollMany(20, 0);

        $this->assertEquals(0, $this->game->score());
    }

    public function testAllOnes()
    {
        $this->rollMany(20, 1);

        $this->assertEquals(20, $this->game->score());
    }

    public function testOneSpare()
    {
        $this->rollSpare();
        $this->game->roll(3);
        $this->rollMany(17, 0);

        $this->assertEquals(16, $this->game->score());
    }

    public function testOneStrike()
    {
        $this->rollStrike();
        $this->game->roll(3);
        $this->game->roll(4);
        $this->rollMany(16, 0);

        $this->assertEquals(24, $this->game->score());
    }

    public function testPerfectGame()
    {
        $this->rollMany(12, 10);

        $this->assertEquals(300, $this->game->score());
    }

    public function testAlmostPerfectGame()
    {
        $this->rollMany(11, 10);
        $this->game->roll(9);

        $this->assertEquals(299, $this->game->score());
    }

    public function testRatherGoodEnding()
    {
        $this->rollMany(18, 0);

        $this->rollMany(3, 10);

        $this->assertEquals(30, $this->game->score());
    }

    public function testGoodEnding()
    {
        $this->rollMany(19, 0);

        $this->rollMany(2, 10);

        $this->assertEquals(20, $this->game->score());
    }

    public function testLucky()
    {
        $this->rollMany(6, 0);

        $this->rollMany(2, 10);

        $this->rollMany(10, 0);

        $this->assertEquals(30, $this->game->score());
    }

    private function rollStrike()
    {
        $this->game->roll(10);
    }

    private function rollSpare()
    {
        $this->rollMany(2, 5);
    }

    private function rollMany($n, $pins)
    {
        for ($i = 0; $i < $n; $i++) {
            $this->game->roll($pins);
        }
    }
}
