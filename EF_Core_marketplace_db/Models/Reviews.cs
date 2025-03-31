using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_marketplace_db.Models
{
    // cвязи: отзыв-юзер - один ко многим (один юзер много отзывов)              ++++++ (сделано)
    //        отзыв-продукт - один ко многим (один продукт имеет много отзывов)  ++++++ (сделано)

    //       

    public class Reviews
    {
        public int Id { get; set; } // первичный ключ

        [Required(ErrorMessage = "Текст отзыва обязателен.")]
        [MaxLength(1000, ErrorMessage = "Текст отзыва не должен превышать 1000 символов.")]
        public string Text { get; set; }

        public int UserId { get; set; } // внешний ключ на айдишник юзера, который связан с отзывом
        public User User { get; set; }  // получаем экземпляр класса юзера, который оставил этот отзыв, у отзыва может быть один юзер.

        public int? ProductId { get; set; } // внешний ключ на продукт, на который оставлен отзыв 
        public Product Product { get; set; }
    }
}
