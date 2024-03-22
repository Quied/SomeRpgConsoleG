<?php
function checkNegativeNumbers($array) {
    $negativeIndices = [];

    foreach ($array as $index => $value) {

        if ($value < 0) {
            $negativeIndices[] = $index;
        }
    }

    return $negativeIndices;
}


$array = [1, -2, 3, -4, 5, -6];

$negativeIndices = checkNegativeNumbers($array);

// Виводимо індекси від'ємних чисел, якщо вони є
if (!empty($negativeIndices)) {
    echo "Від'ємні числа є у наступних індексах: " . implode(', ', $negativeIndices) . "\n";
} else {
    echo "В масиві немає від'ємних чисел.\n";
}
?>
