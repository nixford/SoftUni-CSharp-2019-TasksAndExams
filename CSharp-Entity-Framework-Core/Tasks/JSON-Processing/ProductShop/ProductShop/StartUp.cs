using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext dbContext = new ProductShopContext();
            //ResetDatabase(dbContext);

            //string inputJsonUsers = File.ReadAllText("../../../Datasets/users.json");
            //string inputJsonProduct = File.ReadAllText("../../../Datasets/products.json");
            //string inputJsonCategories = File.ReadAllText("../../../Datasets/categories.json");
            //string inputJsonCategoriesProduct = File.ReadAllText("../../../Datasets/categories-products.json");

            //ImportUsers(dbContext, inputJsonUsers);
            //ImportProducts(dbContext, inputJsonProduct);
            //ImportCategories(dbContext, inputJsonCategories);

            Console.WriteLine(GetUsersWithProducts(dbContext));
        }

        // Problem 01

        public static string ImportUsers(ProductShopContext dbContext, string inputJson)
        {
            User[] users = JsonConvert.DeserializeObject<User[]>(inputJson);

            dbContext.Users.AddRange(users);
            dbContext.SaveChanges();

            return $"Successfully imported {dbContext.Users.Count()}";
        }

        // Problem 02

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            Product[] products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {context.Products.Count()}";
        }

        // Problem 03

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            Category[] categories = JsonConvert
                .DeserializeObject<Category[]>(inputJson)
                .Where(n => n.Name != null)
                .ToArray();            

            context.Categories.AddRange(categories);            
            context.SaveChanges();

            return $"Successfully imported {context.Categories.Count()}";
        }

        // Problem 04

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            CategoryProduct[] categoryProducts = JsonConvert
                .DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {context.CategoryProducts.Count()}";
        }

        // Problem 05

        public static string GetProductsInRange(ProductShopContext context)
        {
            var result = context.Products                
                .Where(p => p.Price >= 500 && p.Price <= 1000)                
                .Select(p => new 
                { 
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + ' ' + p.Seller.LastName,
                })
                .OrderBy(p => p.price);

            string outputText = JsonConvert.SerializeObject(result, Formatting.Indented);

            //File.WriteAllText("../../../Datasets/Result/products-in-range.json", outputText);

            return outputText;
        }


        // Problem 06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName
                        }).ToArray() 
                })
                .ToArray();

            string output = JsonConvert.SerializeObject(users, Formatting.Indented);

            //File.WriteAllText("../../../Datasets/Result/users-sold-products.json", output);

            return output;
        }

        // Problem 07

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new 
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count(),
                    averagePrice = c.CategoryProducts
                                        .Average(cp => cp.Product.Price)
                                        .ToString("f2"),
                    totalRevenue = c.CategoryProducts
                                        .Sum(cp => cp.Product.Price)
                                        .ToString("f2"),
                })
                .OrderByDescending(cp => cp.productsCount)
                .ToArray();

            var result = JsonConvert.SerializeObject(categories, Formatting.Indented);

            //File.WriteAllText("../../../Datasets/Result/categories-by-products.json", result);

            return result;
        }

        // Problem 08

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(p => p.ProductsSold.Count(ps => ps.Buyer != null))
                .Select(u => new
                {
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold
                            .Count(p => p.Buyer != null),
                        Products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new 
                            {
                                name = p.Name,
                                price = p.Price
                            })
                            .ToList()
                    }
                })
                .ToList();

            
            var result = new
            {
                usersCount = users.Count(),
                users = users
            };

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
            };

            var json = JsonConvert.SerializeObject(result, settings);

            File.WriteAllText("../../../Datasets/Result/users-and-products.json", json);

            return json;
        }

        private static void ResetDatabase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was succsessfully deleted!");
            db.Database.EnsureCreated();
            Console.WriteLine("Database was succsessfully created!");
        }        
    }
}