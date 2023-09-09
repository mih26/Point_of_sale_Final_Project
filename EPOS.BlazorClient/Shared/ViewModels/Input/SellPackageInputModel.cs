using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPOS.BlazorClient.Shared.ViewModels.Input
{
    public class SellPackageInputModel
    {
        public int SellPackageId { get; set; }
        [Required, StringLength(30)]
        public string SellPackageName { get; set; } = default!;
    }
}
