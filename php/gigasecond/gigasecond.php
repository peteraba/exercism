<?php

function from(DateTime $startingDate) {
    return $startingDate->modify('+1000000000 secs');
}
