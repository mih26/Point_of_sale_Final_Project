using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPOS.BlazorClient.Shared.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        [Required, Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }
        [StringLength(50)]
        public string? CustomerName { get; set; }
        [Required, StringLength(50)]
        public string Phone { get; set; } = default!;
        [Required, StringLength(30)]
        public string PaymentVia { get; set; } = default!;
        [Column(TypeName = "money")]
        public decimal OrderAmount { get; set; }
        [Required]
        public int CounterId { get; set; }
        public int ItemCount { get; set; }
    }
}
