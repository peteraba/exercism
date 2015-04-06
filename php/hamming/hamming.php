<?php

function distance($a, $b)
{
    if (strlen($a) != strlen($b)) {
        throw new \InvalidArgumentException('DNA strands must be of equal length.');
    }

    $aSplit = str_split($a);
    $bSplit = str_split($b);

    $diff = array_diff_assoc($aSplit, $bSplit);

    return count($diff);
}

