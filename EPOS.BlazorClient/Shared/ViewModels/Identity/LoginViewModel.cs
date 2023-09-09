using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPOS.BlazorClient.Shared.ViewModels.Identity
{
    public class LoginViewModel
    {
        [Required, StringLength(50, MinimumLength =6)]
        public string Username { get; set; } = default!;
        [Required, StringLength(20, MinimumLength = 6), DataType(DataType.Password)]
        public string Password { get; set; } = default!;
        [Required] 
        public int CounterId { get; set; }

    }
}
