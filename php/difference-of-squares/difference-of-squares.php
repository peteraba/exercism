<?php

function squareOfSums($num) {
    $range = range(1, $num);

    $sum = array_sum($range);

    return $sum * $sum;
}

function sumOfSquares($num) {
    $range = range(1, $num);

    $squares = array_map(function($n){ return $n * $n;}, $range);

    return array_sum($squares);
}

function difference($num) {
    return squareOfSums($num) - sumOfSquares($num);
}

