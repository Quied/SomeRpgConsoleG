<?php
$Q = [
    [1, 5],
    [3, 7],
    [8, 2],
    [6, 9],
    [4, 10],
    [2, 6],
    [5, 3],
    [7, 1],
    [9, 4],
    [10, 8]
];

$maxElement = $Q[0][0];
$maxRowIndex = 0;
$maxColumnIndex = 0;

foreach ($Q as $i => $row) {
    foreach ($row as $j => $element) {
        if ($element > $maxElement) {
            $maxElement = $element;
            $maxRowIndex = $i;
            $maxColumnIndex = $j;
        }
    }
}

$Q[$maxRowIndex][$maxColumnIndex] = 10;

echo "Масив Q з максимальним елементом $maxElement, заміненим на 10:\n";
foreach ($Q as $row) {
    echo implode(', ', $row) . "\n";
}
?>
