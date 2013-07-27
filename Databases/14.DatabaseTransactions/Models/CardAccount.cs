using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class CardAccount
    {
        public CardAccount()
        {
        }

        public int ID { get; set; }
        [StringLength(10), Required]
        public string CardNumber { get; set; }

        [StringLength(4), Required]
        public string CardPin { get; set; }

        
        public decimal CardCash { get; set; }
    }
}
