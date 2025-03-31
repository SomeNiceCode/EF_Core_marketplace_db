using EF_Core_marketplace_db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_marketplace_db.Repositories
{
    class UserRepository
    {
        public void AddUser()
        {
            Console.WriteLine("Введите имя пользователя:");
            var userName = Console.ReadLine();
            Console.WriteLine("Введите номер телефона пользователя:");
            var phoneNumber = Console.ReadLine();
            Console.WriteLine("Введите email пользователя:");
            var email = Console.ReadLine();

            using (var context = new ApplicationDbContext())
            {
                var newUser = new User
                {
                    Name = userName,
                    PhoneNumber = phoneNumber,
                    Email = email
                };

                context.Users.Add(newUser);
                context.SaveChanges();
                Console.WriteLine($"Пользователь \"{newUser.Name}\" успешно добавлен");
            }
        }

        public void GetAllUsers()
        {
            using (var context = new ApplicationDbContext())
            {
                var users = context.Users.ToList();
                Console.WriteLine("Список пользователей:");
                foreach (var user in users)
                {
                    Console.WriteLine($"ID: {user.Id}, Имя: {user.Name}, Телефон: {user.PhoneNumber}, Email: {user.Email}");
                }
            }
        }

        public void GetUserById()
        {
            Console.WriteLine("Введите ID пользователя:");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int userId))
            {
                using (var context = new ApplicationDbContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.Id == userId);
                    if (user != null)
                    {
                        Console.WriteLine($"Пользователь найден: ID {user.Id}, Имя: {user.Name}, Телефон: {user.PhoneNumber}, Email: {user.Email}");
                    }
                    else
                    {
                        Console.WriteLine("Пользователь с таким ID не найден");
                    }
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод ID");
            }
        }
        public void UpdateUser()
        {
            Console.WriteLine("Введите ID пользователя для обновления:");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int userId))
            {
                using (var context = new ApplicationDbContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.Id == userId);
                    if (user != null)
                    {
                        Console.WriteLine($"Текущее имя: {user.Name}, Телефон: {user.PhoneNumber}, Email: {user.Email}");
                        Console.WriteLine("Введите новое имя:");
                        var newName = Console.ReadLine();
                        Console.WriteLine("Введите новый номер телефона:");
                        var newPhoneNumber = Console.ReadLine();
                        Console.WriteLine("Введите новый email:");
                        var newEmail = Console.ReadLine();

                        user.Name = newName;
                        user.PhoneNumber = newPhoneNumber;
                        user.Email = newEmail;
                        context.SaveChanges();
                        Console.WriteLine("Пользователь успешно обновлён");
                    }
                    else
                    {
                        Console.WriteLine("Пользователь с таким ID не найден");
                    }
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод ID");
            }
        }
        public void DeleteUser()
        {
            Console.WriteLine("Введите ID пользователя для удаления:");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int userId))
            {
                using (var context = new ApplicationDbContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.Id == userId);
                    if (user != null)
                    {
                        context.Users.Remove(user);
                        context.SaveChanges();
                        Console.WriteLine("Пользователь успешно удалён");
                    }
                    else
                    {
                        Console.WriteLine("Пользователь с таким ID не найден");
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
