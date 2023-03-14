select product.name as [Продукт], category.name as [Категория]
from Products product
	left join ProductsCategory prodcat on product.id = prodcat.product_id
	join Category category on category.id = prodcat.category_id
