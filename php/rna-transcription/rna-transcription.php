<?php

function toRna($dna) {
    static $translate = [
        'C' => 'G',
        'G' => 'C',
        'T' => 'A',
        'A' => 'U'
    ];

    if (str_replace($dna, 'CGTA', '') !== '') {
        throw new \InvalidArgumentException('Invalid DNA sequence provided.');
    }

    $splitDna = str_split($dna);

    $rna = '';

    foreach ($splitDna as $dnaSeq) {
        $rna .= $translate[$dnaSeq];
    }

    return $rna;
}
