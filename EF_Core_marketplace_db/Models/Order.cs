﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_marketplace_db.Models
{
    // связи : заказ-юзер - один ко многим (много заказов у одного юзера) ++++++ (сделано) 
    //         заказ-продукт - многие ко многим (много продуктов в одном заказе, один продукт во многих заказах) +++++ (сделано)
    //         заказ-продавец - многие ко многим (много продавцов участвуют в одном заказе, у одного продавца много заказов) +++++ (сделано)
    public class Order
    {
        public int Id { get; set; } // первичный ключ
        public decimal Sum { get; set; }
        public string DeliveryAddress { get; set; }

        public int UserId { get; set; } // внешний ключ на айдишник юзера, который связан с заказом
        public User User { get; set; }  // получаем экземпляр класса юзера, который сделал этот заказ

        public ICollection<SellerOrder> SellerOrder { get; set; } // связь с продавцами через промежуточную таблицу

        public ICollection<ProductOrder> ProductOrder { get; set; } // связь с продуктами через промеждуточную таблицу
    }
}
