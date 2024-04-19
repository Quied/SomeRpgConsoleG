<?php

// ===========< 1 > =============
$array = [];
for ($i = 0; $i < 10; $i++) {
    $array[] = rand(1, 100); // Генеруємо випадкове число від 1 до 100
}

echo "Початковий масив: " . implode(', ', $array) . "<br>";

// Знаходження максимального та мінімального значень та їх індексів
$max_value = max($array);
$min_value = min($array);
$max_index = array_search($max_value, $array);
$min_index = array_search($min_value, $array);

// Поміняти місцями максимальне і мінімальне значення
$array[$max_index] = $min_value;
$array[$min_index] = $max_value;

echo "Масив після заміни: " . implode(', ', $array);


// ========== < 2 > ====================


function isValid($str) {
    $stack = [];
    $openingBrackets = ['{', '('];
    $closingBrackets = ['}', ')'];

    for ($i = 0; $i < strlen($str); $i++) {
        $char = $str[$i];

        if (in_array($char, $openingBrackets)) {
            // Якщо символ - відкриваюча дужка, додаємо її до стеку
            array_push($stack, $char);
        } elseif (in_array($char, $closingBrackets)) {
            // Якщо символ - закриваюча дужка
            // Перевіряємо, чи є відповідна відкриваюча дужка на вершині стеку
            $top = array_pop($stack);
            if ($top === null || ($char == '}' && $top != '{') || ($char == ')' && $top != '(')) {
                // Якщо стек порожній, або відкриваюча дужка не відповідає закриваючій
                return false;
            }
        }
    }
    return count($stack) === 0;
}

$inputString = "{()}";
if (isValid($inputString)) {
    echo "Рядок є коректним.";
} else {
    echo "Рядок не є коректним.";
}


// ============== < 3 > ====================



?>
