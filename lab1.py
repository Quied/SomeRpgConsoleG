import math

def calculate_expression(x):
    numerator = (math.sin(x)**2 - math.cos(x - 1)**4)**2
    denominator = math.atan(x + 2.6)
    sqrt_ln_x = math.sqrt(math.log(x))
    result = (numerator / denominator) + sqrt_ln_x
    return result

# Test the function with a sample value of x
x_value = 3.0  # You can change this value to test with different x
result = calculate_expression(x_value)
print("Result for x =", x_value, ":", result)

