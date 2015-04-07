<?php

function toDecimal($trinary) {
    // Valid trinary contains only 0, 1, 2 characters and does not start with 0
    if (!preg_match('/^[1-2][0-2]*$/', (string)$trinary)) {
        return 0;
    }

    return base_convert($trinary, 3, 10);
}
