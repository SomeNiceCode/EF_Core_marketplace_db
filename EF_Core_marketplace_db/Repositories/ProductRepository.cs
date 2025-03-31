using EF_Core_marketplace_db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_marketplace_db.Repositories
{
    class ProductRepository
    {
        public void AddProduct()
        {
            Console.WriteLine("Введите название продукта:");
            var productName = Console.ReadLine();
            Console.WriteLine("Введите цену продукта:");
            var priceInput = Console.ReadLine();
            Console.WriteLine("Введите описание продукта:");
            var description = Console.ReadLine();
            Console.WriteLine("Введите ID категории:");
            var categoryIdInput = Console.ReadLine();
            Console.WriteLine("Введите ID продавца:");
            var sellerIdInput = Console.ReadLine();

            if (decimal.TryParse(priceInput, out decimal price) && int.TryParse(categoryIdInput, out int categoryId) && int.TryParse(sellerIdInput, out int sellerId))
            {
                using (var context = new ApplicationDbContext())
                {
                    var newProduct = new Product
                    {
                        Name = productName,
                        Price = price,
                        Description = description,
                        CategoryId = categoryId,
                        SellerId = sellerId
                    };

                    context.Products.Add(newProduct);
                    context.SaveChanges();
                    Console.WriteLine($"Продукт \"{newProduct.Name}\" успешно добавлен");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод данных");
            }
        }

        public void GetAllProducts()
        {
            using (var context = new ApplicationDbContext())
            {
                var products = context.Products.ToList();
                Console.WriteLine("Список продуктов:");
                foreach (var product in products)
                {
                    Console.WriteLine($"ID: {product.Id}, Название: {product.Name}, Цена: {product.Price}, Категория ID: {product.CategoryId}, Продавец ID: {product.SellerId}");
                }
            }
        }

        public void GetProductById()
        {
            Console.WriteLine("Введите ID продукта:");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int productId))
            {
                using (var context = new ApplicationDbContext())
                {
                    var product = context.Products.FirstOrDefault(p => p.Id == productId);
                    if (product != null)
                    {
                        Console.WriteLine($"Продукт найден: ID {product.Id}, Название: {product.Name}, Цена: {product.Price}, Описание: {product.Description}, Категория ID: {product.CategoryId}, Продавец ID: {product.SellerId}");
                    }
                    else
                    {
                        Console.WriteLine("Продукт с таким ID не найден");
                    }
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод ID");
            }
        }

        public void UpdateProduct()
        {
            Console.WriteLine("Введите ID продукта для обновления:");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int productId))
            {
                using (var context = new ApplicationDbContext())
                {
                    var product = context.Products.FirstOrDefault(p => p.Id == productId);
                    if (product != null)
                    {
                        Console.WriteLine($"Текущее название: {product.Name}, Текущая цена: {product.Price}, Текущее описание: {product.Description}");
                        Console.WriteLine("Введите новое название:");
                        var newName = Console.ReadLine();
                        Console.WriteLine("Введите новую цену:");
                        var priceInput = Console.ReadLine();
                        Console.WriteLine("Введите новое описание:");
                        var newDescription = Console.ReadLine();

                        if (decimal.TryParse(priceInput, out decimal price))
                        {
                            product.Name = newName;
                            product.Price = price;
                            product.Description = newDescription;
                            context.SaveChanges();
                            Console.WriteLine("Продукт успешно обновлён");
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод цены");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Продукт с таким ID не найден");
                    }
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод ID");
            }
        }
        public void DeleteProduct()
        {
            Console.WriteLine("Введите ID продукта для удаления:");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int productId))
            {
                using (var context = new ApplicationDbContext())
                {
                    var product = context.Products.FirstOrDefault(p => p.Id == productId);
                    if (product != null)
                    {
                        context.Products.Remove(product);
                        context.SaveChanges();
                        Console.WriteLine("Продукт успешно удалён");
                    }
                    else
                    {
                        Console.WriteLine("Продукт с таким ID не найден");
                    }
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод ID");
            }
        }

    }
}
