using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.ViewModels
{
    public class ChangePiePriceViewModel
    {
        [Range(0,999)]
        public decimal Price { get; set; }
        public int PieId { get; set; }
    }
}
