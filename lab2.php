<?php
function countDigits($n) {
    $count = 0;
    $sum = 0;
    $hasDigit3 = false;

    $digits = str_split((string)$n);

    foreach ($digits as $digit) {
        $count++;

        $sum += $digit;


        if ($digit == 3) {
            $hasDigit3 = true;
        }
    }

    return [$count, $sum, $hasDigit3];
}

$n = 12345;

$result = countDigits($n);

echo "Кількість цифр у числі $n: " . $result[0] . "\n";
echo "Сума цифр числа $n: " . $result[1] . "\n";
echo "Число $n " . ($result[2] ? 'включає' : 'не включає') . " цифру '3'.\n";
?>
