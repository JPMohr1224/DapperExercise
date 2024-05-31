using DapperExercise;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var repo = new DapperProductRepo(conn);

Console.WriteLine("What is the name of your new product?");

var productName = Console.ReadLine();

Console.WriteLine("What is the price?");

var productPrice = double.Parse(Console.ReadLine());

Console.WriteLine("What is the category ID?");

var productCat = int.Parse(Console.ReadLine());

repo.CreateProduct(productName, productPrice, productCat);

var productList = repo.GetAllProducts();

foreach (var product in productList)
{
    Console.WriteLine($"{product.ProductID} - {product.Name}");
}

Console.WriteLine("What is the Product ID you want to update?");

var productID = int.Parse(Console.ReadLine());

Console.WriteLine("What is the new Product Name?");

var newName = Console.ReadLine();

repo.UpdateProduct(productID, newName);

Console.WriteLine("What is the product ID you want to delete?");

productID = int.Parse(Console.ReadLine());

repo.DeleteProduct(productID);