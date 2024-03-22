<?php
$A = [3, 7, 12, 5, 8, 9, 6, 10, 15];
$G = [6, 8, 11, 4, 9, 13, 7, 11, 16];

$maxA = max($A);

$maxG = max($G);

$difference = $maxA - $maxG;

echo "Різниця між максимальними елементами масивів A та G: " . $difference . "\n";
?>
