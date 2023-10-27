SELECT Products.ProductName as "Продукт",
  Categories.CategoryName as "Категория"
FROM Products
LEFT JOIN ProductCategories
  ON Products.ProductId = ProductCategories.ProductId
LEFT JOIN Categories
  ON Categories.CategoryId = ProductCategories.CategoryId
