using EF_Core_marketplace_db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_marketplace_db.Repositories
{
    class OrderRepository
    {
        public void AddOrder()
        {
            Console.WriteLine("Введите сумму заказа:");
            var sumInput = Console.ReadLine();
            Console.WriteLine("Введите адрес доставки:");
            var deliveryAddress = Console.ReadLine();
            Console.WriteLine("Введите ID пользователя, который сделал заказ:");
            var userIdInput = Console.ReadLine();

            if (decimal.TryParse(sumInput, out decimal sum) && int.TryParse(userIdInput, out int userId))
            {
                using (var context = new ApplicationDbContext())
                {
                    var newOrder = new Order
                    {
                        Sum = sum,
                        DeliveryAddress = deliveryAddress,
                        UserId = userId
                    };

                    context.Orders.Add(newOrder);
                    context.SaveChanges();
                    Console.WriteLine($"Заказ успешно добавлен: ID {newOrder.Id}, Сумма: {newOrder.Sum}");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод данных");
            }
        }
        public void GetAllOrders()
        {
            using (var context = new ApplicationDbContext())
            {
                var orders = context.Orders.ToList();
                Console.WriteLine("Список заказов:");
                foreach (var order in orders)
                {
                    Console.WriteLine($"ID: {order.Id}, Сумма: {order.Sum}, Адрес доставки: {order.DeliveryAddress}, Пользователь ID: {order.UserId}");
                }
            }
        }
        public void GetOrderById()
        {
            Console.WriteLine("Введите ID заказа:");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int orderId))
            {
                using (var context = new ApplicationDbContext())
                {
                    var order = context.Orders.FirstOrDefault(o => o.Id == orderId);
                    if (order != null)
                    {
                        Console.WriteLine($"Заказ найден: ID {order.Id}, Сумма: {order.Sum}, Адрес доставки: {order.DeliveryAddress}, Пользователь ID: {order.UserId}");
                    }
                    else
                    {
                        Console.WriteLine("Заказ с таким ID не найден");
                    }
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод ID");
            }
        }

        public void UpdateOrder()
        {
            Console.WriteLine("Введите ID заказа для обновления:");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int orderId))
            {
                using (var context = new ApplicationDbContext())
                {
                    var order = context.Orders.FirstOrDefault(o => o.Id == orderId);
                    if (order != null)
                    {
                        Console.WriteLine($"Текущая сумма заказа: {order.Sum}, текущий адрес доставки: {order.DeliveryAddress}");
                        Console.WriteLine("Введите новую сумму:");
                        var sumInput = Console.ReadLine();
                        Console.WriteLine("Введите новый адрес доставки:");
                        var deliveryAddress = Console.ReadLine();

                        if (decimal.TryParse(sumInput, out decimal sum))
                        {
                            order.Sum = sum;
                            order.DeliveryAddress = deliveryAddress;
                            context.SaveChanges();
                            Console.WriteLine("Заказ успешно обновлён");
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод суммы");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Заказ с таким ID не найден");
                    }
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод ID");
            }
        }

        public void DeleteOrder()
        {
            Console.WriteLine("Введите ID заказа для удаления:");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int orderId))
            {
                using (var context = new ApplicationDbContext())
                {
                    var order = context.Orders.FirstOrDefault(o => o.Id == orderId);
                    if (order != null)
                    {
                        context.Orders.Remove(order);
                        context.SaveChanges();
                        Console.WriteLine("Заказ успешно удалён");
                    }
                    else
                    {
                        Console.WriteLine("Заказ с таким ID не найден");
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
