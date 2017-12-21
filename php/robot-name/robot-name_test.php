<?php

require_once "robot-name.php";

class RobotTest extends PHPUnit_Framework_TestCase
{
    /** @var Robot $robot */
    protected $robot = null;

    public function setUp()
    {
        $this->robot = new Robot();
    }

    public function testHasName()
    {
        $this->assertRegExp('/\w{2}\d{3}/', $this->robot->getName());
    }

    public function testNameSticks()
    {
        $old = $this->robot->getName();

        $this->assertSame($this->robot->getName(), $old);
    }

    public function testDifferentRobotsHaveDifferentNames()
    {
        $other_bot = new Robot();

        $this->assertNotSame($other_bot->getName(), $this->robot->getName());

        unset($other_bot);
    }

    public function testresetName()
    {
        $name1 = $this->robot->getName();

        $this->robot->reset();

        $name2 = $this->robot->getName();

        $this->assertNotSame($name1, $name2);

        $this->assertRegExp('/\w{2}\d{3}/', $name2);
    }

    public function testUniqueNames()
    {
        $this->markTestSkipped('This test is disabled by default because it takes long to run.');

        $robotNames = [];

        for ($i = 0; $i < 676000; $i++) {
            $name = $this->robot->getName();

            if (array_key_exists($name, $robotNames)) {
                $this->assertTrue(false, 'Robot #' . ($i + 1) . ' - Name already exists: ' . $name);
            }

            $this->robot->reset();

            $robotNames[$name] = true;
        }

        $this->assertTrue(true);
    }
}
