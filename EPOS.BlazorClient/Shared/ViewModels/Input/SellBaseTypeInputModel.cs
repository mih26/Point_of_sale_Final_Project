using EPOS.BlazorClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPOS.BlazorClient.Shared.ViewModels.Input
{
    public class ProductMeasurementInputModel
    {
        public int ProductMeasurementId { get; set; }
        [Required, StringLength(30)]
        public string BaseTypeName { get; set; } = default!;
        public ICollection<SellUnit>? SellUnits { get; set; } = new List<SellUnit>();
    }
}
