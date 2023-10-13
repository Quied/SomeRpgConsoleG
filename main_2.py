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


import matplotlib.pyplot as plt 
import csv 
  
x = [] 
y = [] 
z = [] 
  
with open('./data/new.csv','r') as csvfile: 
    plots = csv.reader(csvfile, delimiter = ',') 
      
    for row in plots: 
        x.append(row[1]);
        y.append(row[2]);
        z.append(row[3]);
    
plt.plot(x, y, color='y', linestyle= 'dashed', marker='o', label='NYPD');

plt.xlabel('Names') 
plt.ylabel('Ages') 
plt.title('Ages of different persons') 
plt.legend() 
plt.show() 