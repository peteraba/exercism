<?php

function calculate($question) {
    if (!preg_match('/^What is ([\-\d]+)(.+)\?$/', $question, $matches)) {
        throw new InvalidArgumentException('Irrelevant question.');
    }

    $number = $matches[1];

    $wordy = $matches[2];
    while (preg_match('/^ (\D+) ([\-\d]+)/', $wordy, $matches)) {
        switch ($matches[1]) {
            case 'plus':
                $number += $matches[2];
                break;
            case 'minus':
                $number -= $matches[2];
                break;
            case 'multiplied by':
                $number *= $matches[2];
                break;
            case 'divided by':
                $number /= $matches[2];
                break;
            default:
                throw new InvalidArgumentException('Too advanced.');
        }

        $wordy = mb_substr($wordy, mb_strlen($matches[0]));
    }

    if ($wordy !== '') {
        throw new InvalidArgumentException('Too advanced.');
    }

    return $number;
}
