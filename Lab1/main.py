import pandas as pd;

mydataset = {
  'cars': ["BMW", "Volvo", "Ford", "Mustang"],
  'price': [321, 734, 215, 992]
}

myvar = pd.DataFrame(mydataset)
price_list = myvar['price'].tolist();
car_list = myvar['cars'].tolist();

maxPrice = 0;
Itemid = 0;

for index, price in enumerate(price_list):
    if price > maxPrice:
        maxPrice = price
        Itemid = index;

print('Max price is: ', maxPrice);
print('Item : ', car_list[Itemid]);