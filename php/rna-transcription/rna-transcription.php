<?php

function toRna($dna) {
    static $translate = [
        'C' => 'G',
        'G' => 'C',
        'T' => 'A',
        'A' => 'U'
    ];

    if (str_replace(array_keys($translate), '', $dna) !== '') {
        throw new \InvalidArgumentException('Invalid DNA sequence provided.');
    }

    return strtr($dna, $translate);
}
