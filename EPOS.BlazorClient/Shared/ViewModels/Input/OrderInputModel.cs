using EPOS.BlazorClient.Shared.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPOS.BlazorClient.Shared.ViewModels.Input
{
    public class OrderInputModel
    {
        public int OrderId { get; set; }
        
        public string? CustomerName { get; set; }
        [Required, StringLength(50)]
        public string Phone { get; set; } = default!;
        [Required, StringLength(30)]
        public string PaymentVia { get; set; } = default!;
        [Required]
        public int CounterId { get; set; }
        public virtual ICollection<OrderItemInputModel> OrderItems { get; set; } = new List<OrderItemInputModel>();
    }
}
