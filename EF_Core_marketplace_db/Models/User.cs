using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public string PhoneNumber { get; set; } // string потому что содержит +
        public string Email { get; set; }

        public ICollection<Order> Orders { get; set; } // юзер может иметь много заказов, а заказ одного юзера.  один ко многим
        public ICollection<Reviews> Reviews { get; set; } // так же у юзера может быть много отзывов

    }
}
