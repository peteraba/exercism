<?php

function squareOfSums($num) {
    // https://www.google.de/search?q=sum+of+sequence
    $sum = $num * (1 + $num) / 2;

    return $sum * $sum;
}

function sumOfSquares($num) {
    // http://www.trans4mind.com/personal_development/mathematics/series/sumNaturalSquares.htm
    return $num * ($num + 1) * (2 * $num + 1) / 6;
}

function difference($num) {
    return squareOfSums($num) - sumOfSquares($num);
}

