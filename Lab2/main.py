# 1. Завантажте набір даних.
# 2. Виведіть заголовок таблиці (перші 5 записів).
# 3. Скільки рядків і стовпців в таблиці?
# 4. Які назви стовпців?
# 5. Які типи даних у різних стовпців?
# 6. Скільки в кожному з них унікальних значень?
# 7. Скільки пропущених значень?

import pandas as pd;
import numpy as np;
import matplotlib.pyplot as plt

# 1
myCsv = pd.read_csv('data.csv'); 
#2
print(myCsv.head());
#3
num_rows, num_columns = myCsv.shape;
print("Rows : {}", num_rows);
print("Columns: {}", num_columns);
#4
col_titles = myCsv.columns;
for title in col_titles:
    print("{}", title);
#5
row_type = myCsv.dtypes;
print("{}", row_type);

#7
missing_val = myCsv.isnull().sum();
print(missing_val, " about is missing");

# Набір даних: злочинність в Лос-Анджелесі (la-crime.csv).
# Аналіз даних:
# 1. Визначте 10 найпоширеніших злочинів в LA. Побудуйте графік.
# 2. Від яких злочинів частіше потерпають жінки, а від яких чоловіки?
# 3. Люди якого походження найчастіше піддаються злочинам?
# 4. Відсортуйте райони по кількості злочинів. Побудуйте графік, що
# показує найбезпечніші і небезпечні райони.
# 70
# 5. Люди якого походження найчастіше страждають від злочинів в
# кожному з районів?


# xp = np.array([])
x = myCsv['CMPLNT_NUM'];
y = myCsv['KY_CD'];
plt.scatter(x,y);

# Add labels and a title
plt.xlabel('X values')
plt.ylabel('Y values')
plt.title('Scatter Plot of X and Y')

plt.plot(x,y);
plt.grid(True);
plt.show();