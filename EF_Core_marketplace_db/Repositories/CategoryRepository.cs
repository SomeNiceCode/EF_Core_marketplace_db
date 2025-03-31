using EF_Core_marketplace_db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_marketplace_db.Repositories
{
    class CategoryRepository
    {
        public void AddCategory()
        {
            Console.WriteLine("Введите название новой категории:");
            var categoryName = Console.ReadLine();

            using (var context = new ApplicationDbContext())
            {
                var newCategory = new Category { Name = categoryName };
                context.Categories.Add(newCategory);
                context.SaveChanges();
                Console.WriteLine($"Категория \"{newCategory.Name}\" успешно добавлена");
            }
        }

        public void GetAllCategories()
        {
            using (var context = new ApplicationDbContext())
            {
                var categories = context.Categories.ToList();
                Console.WriteLine("Список категорий:");
                foreach (var category in categories)
                {
                    Console.WriteLine($"ID: {category.Id}, Название: {category.Name}");
                }
            }
        }

        public void GetCategoryById()
        {
            Console.WriteLine("Введите ID категории:");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int categoryId))
            {
                using (var context = new ApplicationDbContext())
                {
                    var category = context.Categories.FirstOrDefault(c => c.Id == categoryId);
                    if (category != null)
                    {
                        Console.WriteLine($"Категория найдена: ID {category.Id}, Название: {category.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Категория с таким ID не найдена");
                    }
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод ID");
            }
        }

        public void UpdateCategory()
        {
            Console.WriteLine("Введите ID категории для обновления:");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int categoryId))
            {
                using (var context = new ApplicationDbContext())
                {
                    var category = context.Categories.FirstOrDefault(c => c.Id == categoryId);
                    if (category != null)
                    {
                        Console.WriteLine($"Текущее название категории: {category.Name}");
                        Console.WriteLine("Введите новое название:");
                        var newName = Console.ReadLine();

                        category.Name = newName;
                        context.SaveChanges();
                        Console.WriteLine("Категория успешно обновлена");
                    }
                    else
                    {
                        Console.WriteLine("Категория с таким ID не найдена");
                    }
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод ID");
            }
        }

        public void DeleteCategory()
        {
            Console.WriteLine("Введите ID категории для удаления:");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int categoryId))
            {
                using (var context = new ApplicationDbContext())
                {
                    var category = context.Categories.FirstOrDefault(c => c.Id == categoryId);
                    if (category != null)
                    {
                        context.Categories.Remove(category);
                        context.SaveChanges();
                        Console.WriteLine("Категория успешно удалена");
                    }
                    else
                    {
                        Console.WriteLine("Категория с таким ID не найдена");
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
