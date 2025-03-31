using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Название магазина обязательно.")]
        [MaxLength(50, ErrorMessage = "Название магазина не должно превышать 50 символов.")]
        public string StoreName { get; set; }

        [Required(ErrorMessage = "Email продавца обязателен.")]
        [EmailAddress(ErrorMessage = "Некорректный формат email.")]
        [MaxLength(100, ErrorMessage = "Email не должен превышать 100 символов.")]
        public string Email { get; set; }
        public ICollection<Product> Products { get; set; } // продавец может иметь много продуктов
        public ICollection<SellerOrder> SellerOrder { get; set; } // связь с заказами через промежуточную таблицу

    }
}
