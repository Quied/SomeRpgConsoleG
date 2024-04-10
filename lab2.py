import pandas as pd
import numpy as np  
from scipy import stats
import matplotlib.pyplot as plt  


data = pd.read_csv("./data.csv")

# Calculating 
sample_mean = data["best_price"].mean()
sample_std = data["best_price"].std()

# 99% confidence interval
z_value = stats.norm.ppf(q=0.99)

confidence_interval = stats.norm.interval(0.99, loc=sample_mean, scale=sample_std/np.sqrt(len(data)))

# Selecting Nokia 
sample_a = data[data["brand_name"] == "Nokia"]["best_price"]

# Selecting Honor 
sample_b = data[data["brand_name"] == "Honor"]["best_price"]

# T-statistic and p-value for t-test
t_statistic, p_value = stats.ttest_ind(sample_a, sample_b)

# Visualizing 
plt.hist(data["best_price"], bins=30)
plt.xlabel("Best Price")
plt.ylabel("Number of Smartphones")
plt.show()



print("Confidence Interval for Best Prices:", confidence_interval)
if p_value < 0.05:
    print("Null hypothesis rejected. The average best prices of brands A and B smartphones differ.")
else:
    print("There is not enough evidence to reject the null hypothesis. The average best prices of brands A and B smartphones may be the same.")

