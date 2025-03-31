using EF_Core_marketplace_db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_marketplace_db.Repositories
{
    class ReviewsRepository
    {
        public void AddReview()
        {
            Console.WriteLine("Введите текст отзыва:");
            var reviewText = Console.ReadLine();
            Console.WriteLine("Введите ID пользователя, который оставляет отзыв:");
            var userIdInput = Console.ReadLine();
            Console.WriteLine("Введите ID продукта, на который оставлен отзыв (или нажмите Enter, если отзыв без продукта):");
            var productIdInput = Console.ReadLine();

            if (int.TryParse(userIdInput, out int userId))
            {
                using (var context = new ApplicationDbContext())
                {
                    var newReview = new Reviews
                    {
                        Text = reviewText,
                        UserId = userId,
                        ProductId = string.IsNullOrEmpty(productIdInput) ? (int?)null : int.Parse(productIdInput)
                    };

                    context.Reviews.Add(newReview);
                    context.SaveChanges();
                    Console.WriteLine("Отзыв успешно добавлен");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод ID пользователя");
            }
        }

        public void GetAllReviews()
        {
            using (var context = new ApplicationDbContext())
            {
                var reviews = context.Reviews.ToList();
                Console.WriteLine("Список отзывов:");
                foreach (var review in reviews)
                {
                    Console.WriteLine($"ID: {review.Id}, Текст: {review.Text}, Пользователь ID: {review.UserId}, Продукт ID: {review.ProductId}");
                }
            }
        }

        public void GetReviewById()
        {
            Console.WriteLine("Введите ID отзыва:");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int reviewId))
            {
                using (var context = new ApplicationDbContext())
                {
                    var review = context.Reviews.FirstOrDefault(r => r.Id == reviewId);
                    if (review != null)
                    {
                        Console.WriteLine($"Отзыв найден: ID {review.Id}, Текст: {review.Text}, Пользователь ID: {review.UserId}, Продукт ID: {review.ProductId}");
                    }
                    else
                    {
                        Console.WriteLine("Отзыв с таким ID не найден");
                    }
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод ID");
            }
        }

        public void UpdateReview()
        {
            Console.WriteLine("Введите ID отзыва для обновления:");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int reviewId))
            {
                using (var context = new ApplicationDbContext())
                {
                    var review = context.Reviews.FirstOrDefault(r => r.Id == reviewId);
                    if (review != null)
                    {
                        Console.WriteLine($"Текущий текст отзыва: {review.Text}");
                        Console.WriteLine("Введите новый текст отзыва:");
                        var newText = Console.ReadLine();

                        review.Text = newText;
                        context.SaveChanges();
                        Console.WriteLine("Отзыв успешно обновлён");
                    }
                    else
                    {
                        Console.WriteLine("Отзыв с таким ID не найден");
                    }
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод ID");
            }
        }

        public void DeleteReview()
        {
            Console.WriteLine("Введите ID отзыва для удаления:");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int reviewId))
            {
                using (var context = new ApplicationDbContext())
                {
                    var review = context.Reviews.FirstOrDefault(r => r.Id == reviewId);
                    if (review != null)
                    {
                        context.Reviews.Remove(review);
                        context.SaveChanges();
                        Console.WriteLine("Отзыв успешно удалён");
                    }
                    else
                    {
                        Console.WriteLine("Отзыв с таким ID не найден");
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
