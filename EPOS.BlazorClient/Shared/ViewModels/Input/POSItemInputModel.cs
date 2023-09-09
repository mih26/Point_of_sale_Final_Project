using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPOS.BlazorClient.Shared.ViewModels.Input
{
    public class POSItemInputModel
    {
        [Required]
        public string SelfCode { get; set; } = default!;
        [Required]
        public int SelfedProductId { get; set; }
        [Required]

        public int Quantity { get; set; } = 1;
    }
}
