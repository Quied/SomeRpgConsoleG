<?php
$a = -9.86;
$x = 0.56;

$numerator = pow($x, 3) - $x * cos($x);
$denominator = pow($a + $x, 2);

$result = $numerator / $denominator;

echo "Result: " . $result;
?>
