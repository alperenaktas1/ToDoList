using Entity.Concrete;
using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace UI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = ("Please enter your username"))]
        public string UserName { get; set; }

        [Required(ErrorMessage = ("Please enter your password"))]
        public string Password { get; set; }

        


    }
}
