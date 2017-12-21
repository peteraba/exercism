# Rna Transcription

Write a program that, given a DNA strand, returns its RNA complement (per RNA transcription).

Both DNA and RNA strands are a sequence of nucleotides.

The four nucleotides found in DNA are adenine (**A**), cytosine (**C**),
guanine (**G**) and thymine (**T**).

The four nucleotides found in RNA are adenine (**A**), cytosine (**C**),
guanine (**G**) and uracil (**U**).

Given a DNA strand, its transcribed RNA strand is formed by replacing
each nucleotide with its complement:

* `G` -> `C`
* `C` -> `G`
* `T` -> `A`
* `A` -> `U`

## Making the Test Suite Pass

1. Get [PHPUnit].

        % wget --no-check-certificate https://phar.phpunit.de/phpunit.phar
        % chmod +x phpunit.phar

2. Execute the tests for an assignment.

        % phpunit.phar wordy/wordy_test.php

[PHPUnit]: http://phpunit.de


## Source

Rosalind [view source](http://rosalind.info/problems/rna)
