using System;
namespace MyAspNetCoreFirstApp.Models
{
	public class ProductRepository
	{
        private static List<Product> _products = new List<Product>()
{
    new Product { Id = 0, ProductName = "paper", Price = 10, Stock = 3 },
    new Product { Id = 1, ProductName = "keyboard", Price = 60, Stock = 6 },
    new Product { Id = 2, ProductName = "book", Price = 50, Stock = 7 }
};
        public List<Product> GetAll() => _products;

		public void Add(Product newProduct) => _products.Add(newProduct);

		public void Remove(int id)
		{
			var hasProduct = _products.FirstOrDefault(x => x.Id==id);
			if (hasProduct == null)
			{
				throw new Exception($"Bu id({id})'ye ait ürün bulunmamaktadır");
			}

			_products.Remove(hasProduct);

		}

		public void Update(Product updateProduct)
		{
			var hasProduct = _products.FirstOrDefault(x => x.Id == updateProduct.Id);
			if(hasProduct==null)
			{
				throw new Exception($"Bu id({updateProduct.Id})'ye ait ürün bulunmamaktadır");
			}

			hasProduct.ProductName = updateProduct.ProductName;
			hasProduct.Price = updateProduct.Price;
			hasProduct.Stock = updateProduct.Stock;

			var index = _products.FindIndex(x => x.Id == updateProduct.Id);
			_products[index] = hasProduct;
		}

	}
}

