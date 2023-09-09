using EPOS.BlazorClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPOS.BlazorClient.Shared.ViewModels.Input
{
    public class OrderItemInputModel
    {
        public int OrderItemId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [Required]
        public string SelfCode { get; set; } = default!;

        public int Quantity { get; set; }

        public virtual Order? Order { get; set; } = default!;
        public virtual Product? Product { get; set; } = default!;
    }
}
