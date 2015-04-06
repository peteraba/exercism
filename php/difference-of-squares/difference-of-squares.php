<?php

function squareOfSums($num) {
    $range = range(1, $num);

    $sum = array_sum($range);

    return $sum * $sum;
}

function sumOfSquares($num) {
    $squares = [];

    for ($i = 1; $i <= $num; $i++) {
        $squares[] = $i * $i;
    }

    return array_sum($squares);
}

function difference($num) {
    return squareOfSums($num) - sumOfSquares($num);
}

