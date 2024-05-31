using System;
namespace DapperExercise
{
	public interface IProductRepo
	{
        public IEnumerable<Product> GetAllProducts();

        public void CreateProduct(string name, double price, int categoryID);

        public void UpdateProduct(int productID, string UpdatedName);

        public void DeleteProduct(int ProductID);
    }

    
}

