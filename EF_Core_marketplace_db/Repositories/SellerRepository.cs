using EF_Core_marketplace_db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_marketplace_db.Repositories
{
    class SellerRepository
    {
        public void AddSeller()
        {
            Console.WriteLine("Введите название магазина продавца:");
            var storeName = Console.ReadLine();
            Console.WriteLine("Введите email продавца:");
            var email = Console.ReadLine();

            using (var context = new ApplicationDbContext())
            {
                var newSeller = new Seller
                {
                    StoreName = storeName,
                    Email = email
                };

                context.Sellers.Add(newSeller);
                context.SaveChanges();
                Console.WriteLine($"Продавец \"{newSeller.StoreName}\" успешно добавлен");
            }
        }

        public void GetAllSellers()
        {
            using (var context = new ApplicationDbContext())
            {
                var sellers = context.Sellers.ToList();
                Console.WriteLine("Список продавцов:");
                foreach (var seller in sellers)
                {
                    Console.WriteLine($"ID: {seller.Id}, Магазин: {seller.StoreName}, Email: {seller.Email}");
                }
            }
        }
        public void GetSellerById()
        {
            Console.WriteLine("Введите ID продавца:");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int sellerId))
            {
                using (var context = new ApplicationDbContext())
                {
                    var seller = context.Sellers.FirstOrDefault(s => s.Id == sellerId);
                    if (seller != null)
                    {
                        Console.WriteLine($"Продавец найден: ID {seller.Id}, Магазин: {seller.StoreName}, Email: {seller.Email}");
                    }
                    else
                    {
                        Console.WriteLine("Продавец с таким ID не найден");
                    }
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод ID");
            }
        }
        public void UpdateSeller()
        {
            Console.WriteLine("Введите ID продавца для обновления:");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int sellerId))
            {
                using (var context = new ApplicationDbContext())
                {
                    var seller = context.Sellers.FirstOrDefault(s => s.Id == sellerId);
                    if (seller != null)
                    {
                        Console.WriteLine($"Текущее название магазина: {seller.StoreName}, Текущий email: {seller.Email}");
                        Console.WriteLine("Введите новое название магазина:");
                        var newStoreName = Console.ReadLine();
                        Console.WriteLine("Введите новый email:");
                        var newEmail = Console.ReadLine();

                        seller.StoreName = newStoreName;
                        seller.Email = newEmail;
                        context.SaveChanges();
                        Console.WriteLine("Продавец успешно обновлён");
                    }
                    else
                    {
                        Console.WriteLine("Продавец с таким ID не найден");
                    }
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод ID");
            }
        }
        public void DeleteSeller()
        {
            Console.WriteLine("Введите ID продавца для удаления:");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int sellerId))
            {
                using (var context = new ApplicationDbContext())
                {
                    var seller = context.Sellers.FirstOrDefault(s => s.Id == sellerId);
                    if (seller != null)
                    {
                        context.Sellers.Remove(seller);
                        context.SaveChanges();
                        Console.WriteLine("Продавец успешно удалён");
                    }
                    else
                    {
                        Console.WriteLine("Продавец с таким ID не найден");
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
