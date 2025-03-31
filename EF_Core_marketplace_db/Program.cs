using EF_Core_marketplace_db.Models;
using EF_Core_marketplace_db.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace EF_Core_marketplace_db
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var categoryManager = new CategoryRepository();
            var orderManager = new OrderRepository();
            var productManager = new ProductRepository();
            var reviewManager = new ReviewsRepository();
            var sellerManager = new SellerRepository();
            var userManager = new UserRepository();

            //using (var context = new ApplicationDbContext())
            //{
            //    context.Database.EnsureDeleted();
            //    Console.WriteLine("Старая версия базы удалена");
            //    context.Database.EnsureCreated();
            //    Console.WriteLine("Новая версия базы создана");
            //}

            Console.WriteLine("Добавляем категории");

            categoryManager.AddCategory();    // добаили категории первые
            categoryManager.AddCategory();
            categoryManager.AddCategory();   // несколько раз вызываем для добавления новых категорий
            categoryManager.GetAllCategories(); // смотрим шо добавили

            Console.WriteLine("Добавляем продавцов");
            sellerManager.AddSeller();
            sellerManager.AddSeller();        // потом продавцов
            sellerManager.AddSeller();
            sellerManager.GetAllSellers();

            Console.WriteLine("Добавляем пользователей");
            userManager.AddUser();           // юзеров
            userManager.AddUser();
            userManager.AddUser();
            userManager.GetAllUsers();

            Console.WriteLine("Добавляем продукты");
            productManager.AddProduct();     // теперь продукты
            productManager.AddProduct();
            productManager.AddProduct();
            productManager.AddProduct();
            productManager.GetAllProducts();

            Console.WriteLine("Добавляем заказы");
            orderManager.AddOrder();
            orderManager.AddOrder();
            orderManager.AddOrder();
            orderManager.AddOrder();

            Console.WriteLine("Добавляем отзывы");
            reviewManager.AddReview();
            reviewManager.AddReview();
            reviewManager.AddReview();
            reviewManager.GetAllReviews();


        }
    }
}
