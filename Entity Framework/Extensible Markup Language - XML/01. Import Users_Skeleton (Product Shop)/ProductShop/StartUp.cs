using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            string inputUsersXml = File.ReadAllText("../../../Datasets/users.xml");
            //Console.WriteLine(ImportUsers(context,inputUsersXml));

            string inputProductsXml = File.ReadAllText("../../../Datasets/products.xml");
            //Console.WriteLine(ImportProducts(context, inputProductsXml));

            string inputCategoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            //Console.WriteLine(ImportCategories(context,inputCategoriesXml));

            string inputCategoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            //Console.WriteLine(ImportCategoryProducts(context,inputCategoriesProductsXml));

            Console.WriteLine(GetUsersWithProducts(context));
        }
        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<ProductShopProfile>());
            return new Mapper(cfg);
        }
        private static string SerializeToXml<T>(T dto, string xmlRootAttribute)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));

            StringBuilder sb = new StringBuilder();

            using (StringWriter sw = new StringWriter(sb, CultureInfo.InvariantCulture))
            {
                XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
                xsn.Add(string.Empty, string.Empty);

                try
                {
                    xmlSerializer.Serialize(sw, dto, xsn);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUsersDTO[]), new XmlRootAttribute("Users"));

            using var reader = new StringReader(inputXml);
            ImportUsersDTO[] importUsersDTOs = (ImportUsersDTO[])xmlSerializer.Deserialize(reader);

            var mapper = GetMapper();
            User[] users = mapper.Map<User[]>(importUsersDTOs);

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductsDTO[]), new XmlRootAttribute("Products"));

            using var reader = new StringReader(inputXml);
            ImportProductsDTO[] importUsersDTOs = (ImportProductsDTO[])xmlSerializer.Deserialize(reader);



            var mapper = GetMapper();
            Product[] products = mapper.Map<Product[]>(importUsersDTOs);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoriesDTO[]), new XmlRootAttribute("Categories"));

            using var reader = new StringReader(inputXml);
            ImportCategoriesDTO[] importCategoriesDTOs = (ImportCategoriesDTO[])xmlSerializer.Deserialize(reader);

            var mapper = GetMapper();

            Category[] categories = mapper.Map<Category[]>(importCategoriesDTOs.Where(c => c.Name != null).ToArray());

            context.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductsDTO[]), new XmlRootAttribute("CategoryProducts"));

            using var reader = new StringReader(inputXml);
            ImportCategoryProductsDTO[] importCategoryProductsDTOs = (ImportCategoryProductsDTO[])xmlSerializer.Deserialize(reader);

            var mapper = GetMapper();

            var categoryIds = context.Categories.Select(c => c.Id).ToArray();

            var productIds = context.Products.Select(p => p.Id).ToArray();

            CategoryProduct[] categoryProducts = mapper.Map<CategoryProduct[]>(importCategoryProductsDTOs
                .Where(cp => categoryIds.Contains(cp.CategoryId) && productIds.Contains(cp.ProductId)));

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }
       

        public static string GetProductsInRange(ProductShopContext context)
        {
            var mapper = GetMapper();

            var productsInRange = context.Products
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .Select(p => new ExportProductsInRangeDTO
            {
                Name = p.Name,
                Price = p.Price,
                BuyerName = p.Buyer != null ? $"{p.Buyer.FirstName} {p.Buyer.LastName}" : null
            })
            .Take(10)
            .ToArray();

            return SerializeToXml<ExportProductsInRangeDTO[]>(productsInRange, "Products");
        }
        public static string GetSoldProducts(ProductShopContext context)
        {
            var mapper = GetMapper();

            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                .Select(u => new ExportSoldProductsDTO
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(ps => new SoldProductsDTO
                    {
                        Name = ps.Name,
                        Price = ps.Price
                    })
                    .ToArray()
                })
                .Take(5)
                .ToArray();

            return SerializeToXml(users, "Users");
        }
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var mapper = GetMapper();

            var categoriesReport = context.Categories
           .Select(c => new ExportCategoriesByProductsCountDTO
           {
               Name = c.Name,
               Count = c.CategoryProducts.Count,
               AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
               TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
           })
           .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
           .ToArray();

            return SerializeToXml(categoriesReport, "Categories");
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {


            //var users = context.Users
            //        .Where(u => u.ProductsSold.Any()) // Select users who have sold products
            //        .OrderByDescending(u => u.ProductsSold.Count()) // Order by the number of sold products
            //        .Take(10) // Take the top 10 users
            //        .Select(u => new ExportUsersDTO
            //        {
            //            Count = context.Users.Count(u => u.ProductsSold.Any()), // Total count of users (assuming this is what Count represents)
            //            Users = context.Users
            //                .Where(usr => usr.ProductsSold.Any())
            //                .OrderByDescending(usr => usr.ProductsSold.Count())
            //                .Take(10)
            //                .Select(usr => new UserDataDTO
            //                {
            //                    FirstName = usr.FirstName,
            //                    LastName = usr.LastName,
            //                    Age = usr.Age,
            //                    SoldProducts = new SoldProductContainer
            //                    {
            //                        Count = usr.ProductsSold.Count(),
            //                        Products = usr.ProductsSold
            //                            .OrderByDescending(ps => ps.Price)
            //                            .Select(ps => new SoldProductOutputModel
            //                            {
            //                                Name = ps.Name,
            //                                Price = ps.Price
            //                            })
            //                            .ToArray()
            //                    }
            //                })
            //                .ToArray()
            //        })
            //        .ToArray();

            var usersReport = new ExportUsersDTO
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()), // Total count of users who have sold products

                Users = context.Users
                     .Where(u => u.ProductsSold.Any()) // Filter users who have sold products
                     .OrderByDescending(u => u.ProductsSold.Count()) // Order by the number of sold products (descending)
                     .Take(10) // Take the top 10 users
                     .Select(u => new UserDataDTO
                     {
                         FirstName = u.FirstName,
                         LastName = u.LastName,
                         Age = u.Age,
                         SoldProducts = new SoldProductContainer
                         {
                             Count = u.ProductsSold.Count(), // Count of sold products for this user
                             Products = u.ProductsSold
                                 .OrderByDescending(ps => ps.Price) // Order sold products by price (descending)
                                 .Select(ps => new SoldProductOutputModel
                                 {
                                     Name = ps.Name,
                                     Price = ps.Price
                                 })
                                 .ToArray()
                         }
                     })
                     .ToArray()

            };

            return SerializeToXml(usersReport, "Users");
        
        }
    }
}