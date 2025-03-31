using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_marketplace_db.Models
{
    // связи: категория-продукт - один ко многим (много продуктов в одной категории, но у одного продукта 1 категория) +++++++ (сделано)
    public class Category
    {
        public int Id { get; set; } // первичный ключ

        [Required(ErrorMessage = "Название категории обязательно.")]
        [MaxLength(50, ErrorMessage = "Название категории не должно превышать 50 символов.")]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
