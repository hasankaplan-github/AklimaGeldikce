using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AklimaGeldikce.Web.Models
{
    public class ForgotPasswordViewModel
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
    }
}
