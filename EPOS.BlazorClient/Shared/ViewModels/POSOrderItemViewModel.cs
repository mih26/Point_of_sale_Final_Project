using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPOS.BlazorClient.Shared.ViewModels
{
    public class POSOrderItemViewModel
    {
        [Required]
        public string SelfCode { get; set; } = default!;
        [Required]
        public int SelfedProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public decimal SelfPrice { get; set; }
        [Required]

        public int Quantity { get; set; } = 1;
    }
}
