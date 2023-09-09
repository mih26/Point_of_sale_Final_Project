using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPOS.BlazorClient.Shared.ViewModels
{
    public class SupplierViewModel
    {
        public int SupplierId { get; set; }
        [Required, StringLength(50)]
        public string CompanyName { get; set; } = default!;
        [Required, StringLength(50)]
        public string ContactName { get; set; } = default!;
        [Required, StringLength(20)]
        public string ContactNo { get; set; } = default!;
    }
}
