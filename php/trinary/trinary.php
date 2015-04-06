<?php

function toDecimal($trinary) {
    // Valid trinary contains only 0, 1, 2 characters and does not start with 0
    if (!preg_match('/^[1-2][0-2]*$/', (string)$trinary)) {
        return 0;
    }

    $trinaryDigits = array_reverse(str_split((string)$trinary));

    $decimal = 0;
    foreach ($trinaryDigits as $digit => $value) {
        $decimal += pow(3, $digit) * $value;
    }

    return $decimal;
}
