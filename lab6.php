<?php
function printWordsDifferentFromHello($sentence) {
    $words = explode(' ', $sentence);

    foreach ($words as $word) {
        $word = trim($word, " .,!?");

        if (strcasecmp($word, "hello") !== 0) {
            echo $word . "\n";
        }
    }
}

$sentence = "hello world! Hi, hello dear friend. Hello";

printWordsDifferentFromHello($sentence);
?>
