<?php

function translateDigit(&$num, $digit) {
    static $translate = [
        1    => ['', 'I', 'II', 'III', 'IV', 'V', 'VI', 'VII', 'VIII', 'IX', 'X'],
        10   => ['', 'X', 'XX', 'XXX', 'XL', 'L', 'LX', 'LXX', 'LXXX', 'XC', 'C'],
        100  => ['', 'C', 'CC', 'CCC', 'CD', 'D', 'DC', 'DCC', 'DCCC', 'CM', 'M'],
        1000 => ['', 'M', 'MM', 'MMM']
    ];

    $count  = floor($num / $digit);
    $num   -= $count * $digit;
    
    return $translate[$digit][$count];
}

function toRoman($num) {
    if (!is_numeric($num) || $num < 1 || $num > 3000) {
        throw new \InvalidArgumentException('Only numbers between 1 and 3000 can be converted.');
    }

    $num = (int)$num;
    
    $roman  = '';
    $roman .= translateDigit($num, 1000);
    $roman .= translateDigit($num, 100);
    $roman .= translateDigit($num, 10);
    $roman .= translateDigit($num, 1);
    
    return $roman;
}
