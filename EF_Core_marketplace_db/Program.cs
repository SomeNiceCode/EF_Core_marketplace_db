using EF_Core_marketplace_db.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace EF_Core_marketplace_db
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Database.EnsureDeleted();
                Console.WriteLine("Старая версия базы удалена");
                context.Database.EnsureCreated();
                Console.WriteLine("Новая версия базы создана");

                var category1 = new Category { Name = "Овощи" };               // первыми создаём категории, они родительские для продукта
                var category2 = new Category { Name = "Специи" };
                var category3 = new Category { Name = "Предметы гигиены" };
                context.Categories.AddRange(category1, category2, category3);
                context.SaveChanges();
                Console.WriteLine("Категории добавлены и сохранены");

                var seller1 = new Seller { StoreName = "Всё для вас", Email = "Vsedliavas@gmail.com" };  // потом продавцы, продукты ссылаются на них через внешний ключ
                var seller2 = new Seller { StoreName = "Vinahidnik", Email = "Vinahidnik@gmail.com" };
                context.Sellers.AddRange(seller1, seller2);
                context.SaveChanges();
                Console.WriteLine("Продавцы добавлены и сохранены");


                var user1 = new User { Name = "Petro", PhoneNumber = "1234567890", Email = "Petro@gmail.com" };     //  потом юзеры, так как заказы и отзывы ссылаются на них
                var user2 = new User { Name = "Mikola", PhoneNumber = "0987654321", Email = "Mikola@gmail.com" };
                context.Users.Add(user1);
                Console.WriteLine("Юзер Петро добавлен");
                context.Users.Add(user2);
                Console.WriteLine("Юзер Мыкола добавлен");
                context.SaveChanges();
                Console.WriteLine("Юзеры добавлены и сохранены");

                var product1 = new Product { Name = "Морковка", Price = 35.5m, Description = "В основном используют как овощ", CategoryId = category1.Id, SellerId = seller1.Id };
                var product2 = new Product { Name = "Тыква", Price = 15.8m, Description = "Самая полезная тыква", CategoryId = category1.Id, SellerId = seller1.Id };
                var product3 = new Product { Name = "Баклажан", Price = 140m, Description = "Привезён из Египта", CategoryId = category1.Id, SellerId = seller2.Id };
                var product4 = new Product { Name = "Острый перец", Price = 350m, Description = "Для остроты ощущений", CategoryId = category1.Id, SellerId = seller2.Id };
                var product5 = new Product { Name = "Туалетная бумага", Price = 35.5m, Description = "Полезно после острого перца", CategoryId = category2.Id, SellerId = seller2.Id };



                context.Products.AddRange(product1, product2, product3, product4, product5); // добавляем в таблицу
                context.SaveChanges();
                Console.WriteLine("Продукты добавлены и сохранены");

                var order1 = new Order { Sum = 1250m, DeliveryAddress = "Город-герой Одесса", UserId = user1.Id };
                var order2 = new Order { Sum = 145m, DeliveryAddress = "Город-герой Одесса", UserId = user2.Id };
                context.Orders.AddRange(order1, order2);
                context.SaveChanges();
                Console.WriteLine("Заказы добавлены и сохранены");

                context.ProductOrders.AddRange(
                        new ProductOrder { ProductId = product1.Id, OrderId = order1.Id },
                        new ProductOrder { ProductId = product2.Id, OrderId = order2.Id }
                );
                context.SaveChanges();
                Console.WriteLine("Заказы и продукты добавлены в промежуточную таблицу и сохранены");

                context.SellerOrders.AddRange(
                        new SellerOrder { SellerId = seller1.Id, OrderId = order1.Id },
                        new SellerOrder { SellerId = seller2.Id, OrderId = order2.Id }
                );
                context.SaveChanges();
                Console.WriteLine("Заказы и продавцы добавлены в промежуточную таблицу и сохранены");

                var review1 = new Reviews { Text = "Хороший продукт", UserId = user1.Id, ProductId = product1.Id };
                var review2 = new Reviews { Text = "Отличная тыква", UserId = user2.Id, ProductId = product2.Id };
                context.Reviews.AddRange(review1, review2);
                context.SaveChanges();
                Console.WriteLine("Отзывы добавлены и сохранены");



            }
        }
    }
}
