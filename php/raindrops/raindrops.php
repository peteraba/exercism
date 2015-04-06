<?php

function raindrops($drops) {
    if (!is_numeric($drops)) {
        throw new \InvalidArgumentException();
    }

    $text = '';
    if ($drops % 3 == 0) {
        $text .= 'Pling';
    }
    if ($drops % 5 == 0) {
        $text .= 'Plang';
    }
    if ($drops % 7 === 0) {
        $text .= 'Plong';
    }
    if ($text === '') {
        $text = (string)$drops;
    }

    return $text;
}
