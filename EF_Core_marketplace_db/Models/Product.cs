using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_marketplace_db.Models
{
    // связи: продукт-категория - один ко многим (у категории может быть много продуктов, но к продукта 1 категория) ++++ (сделано)
    //        продукт-заказ - многие ко многим (у одного заказа много продуктов) +++++ (сделано) 
    //        продукт-отзыв - один ко многим (у одного продукты много отзывов)   +++++ (сделано)
    //        продукт-продавец - один ко многим ( у одного продавца много продуктов, но у конкретного продукта свой продавец) ++++++ (сделано)
    public class Product
    {
        public int Id { get; set; } // первичный ключ

        [Required(ErrorMessage = "Название продукта обязательно.")]
        [MaxLength(100, ErrorMessage = "Название продукта не должно превышать 100 символов.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Цена продукта обязательна.")]
        [Range(0.01, 100000.00, ErrorMessage = "Цена продукта должна быть в диапазоне от 0.01 до 100000.")]
        public decimal Price { get; set; }

        [MaxLength(500, ErrorMessage = "Описание продукта не должно превышать 500 символов.")]
        public string Description { get; set; }


        public ICollection<Reviews> Reviews { get; set; } // продукт может иметь много отзывов
        public int CategoryId { get; set; }               // Внешний ключ на категорию
        public Category Category { get; set; }
        public int SellerId { get; set; }   // внешний ключ на продавца
        public Seller Seller { get; set; }   // экземпляр продавца у которого продукт


        public ICollection<ProductOrder> ProductOrder { get; set; } // связь с заказами через промежуточную таблицу
    }
}
