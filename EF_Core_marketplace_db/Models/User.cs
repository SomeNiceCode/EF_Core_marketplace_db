using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_marketplace_db.Models
{
    // cвязи юзера: юзер-отзывы - один ко многим (один юзер много отзывов) ++++++ (сделано)
    //              юзер-заказ - один ко многим (один юзер много заказов)  ++++++ (сделано)
    //        
    public class User
    {
        public int Id { get; set; } // первичный ключ

        [Required(ErrorMessage = "Имя пользователя обязательно.")]
        [MaxLength(50, ErrorMessage = "Имя не должно превышать 50 символов.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Номер телефона обязателен.")]
        [MinLength(10, ErrorMessage = "Номер телефона должен содержать не менее 10 символов.")]
        [MaxLength(15, ErrorMessage = "Номер телефона не должен превышать 15 символов.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email обязателен.")]
        [MaxLength(100, ErrorMessage = "Email не должен превышать 100 символов.")]
        public string Email { get; set; }


        public ICollection<Order> Orders { get; set; } // юзер может иметь много заказов, а заказ одного юзера.  один ко многим
        public ICollection<Reviews> Reviews { get; set; } // так же у юзера может быть много отзывов

    }
}
