using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPOS.BlazorClient.Shared.ViewModels
{
    public class ItemViewModel
    {
        public string ProductName { get; set; } = default!;
        public decimal UnitPrice { get; set; } = default!;
    }
}
