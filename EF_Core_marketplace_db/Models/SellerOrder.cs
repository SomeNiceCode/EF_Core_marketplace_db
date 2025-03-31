using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_marketplace_db.Models
{
    public class SellerOrder                       // через эту таблицу я реализовал связь многие ко многим между продавцами и заказами. 
    {                                       // у одного продавца может быть много заказов и в одном заказе могут участвовать разные продавцы.
        public int SellerId { get; set; }   // внешний ключ к продавцу
        public Seller Seller { get; set; }
        public int OrderId { get; set; }    // внешний ключ к покупателю
        public Order Order { get; set; }

    }
}
