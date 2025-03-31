using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_marketplace_db.Models
{
    //  cвязи продавца: продавец-продукт - один ко многим (один продавец много продуктов) +++++ (сделано)
    //                  продавец-заказ - многие ко многим (один продавец много заказов, в одном заказе товары разных продавцов) +++++ (сделано)
    //        

    public class Seller
    {
        public int Id { get; set; } // первичный ключ
        public string StoreName { get; set; }
        public string Email { get; set; }
        public ICollection<Product> Products { get; set; } // продавец может иметь много продуктов
        public ICollection<SellerOrder> SellerOrder { get; set; } // связь с заказами через промежуточную таблицу

    }
}
