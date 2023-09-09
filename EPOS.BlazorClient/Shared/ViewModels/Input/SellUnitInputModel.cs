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
    public class SellUnitInputModel
    {
        public int SellUnitId { get; set; }
        [Required, StringLength(30)]
        public string SellUnitName { get; set; } = default!;
        [Required, ForeignKey("ProductMeasurement")]
        public int ProductMeasurementId { get; set; }
        public virtual ProductMeasurement? ProductMeasurement { get; set; } = default!;
    }
}
