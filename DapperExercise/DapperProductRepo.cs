using System;
using System.Data;
using Dapper;

namespace DapperExercise
{
    public class DapperProductRepo : IProductRepo
	{
        private readonly IDbConnection _conn;

        public DapperProductRepo(IDbConnection conn)
		{
            _conn = conn;
		}

        public void CreateProduct(string name, double price, int categoryID)
        {
            _conn.Execute("INSERT INTO products(Name, Price, CategoryID) " +
                "VALUES (@Name, @Price, @CategoryID);",
                new {name = name, price = price, categoryID = categoryID});
        }

        public void DeleteProduct(int productID)
        {
           _conn.Execute("DELETE FROM products WHERE ProductID = @productID;",
               new { productID = productID });
            _conn.Execute("DELETE FROM sales WHERE ProductID = @productID;",
               new { productID = productID });
            _conn.Execute("DELETE FROM reviews WHERE ProductID = @productID;",
               new { productID = productID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
           return _conn.Query<Product>("SELECT * FROM products;");
        }

        public void UpdateProduct(int productID, string updatedName)
        {
            _conn.Execute("UPDATE products SET name = @updatedName WHERE productID = @productID;",
                new {productID = productID, updatedName = updatedName});
        }

        
    }
}

