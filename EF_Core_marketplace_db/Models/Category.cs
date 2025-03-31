using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_marketplace_db.Models
{
    // связи: категория-продукт - один ко многим (много продуктов в одной категории, но у одного продукта 1 категория) +++++++ (сделано)
    public class Category
    {
        public int Id { get; set; } // первичный ключ
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
