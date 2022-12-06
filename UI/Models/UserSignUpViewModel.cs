using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace UI.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Name Surname")]
        [Required(ErrorMessage ="Please enter Name Surname")]
        public string NameSurname { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }


        [Display(Name = "Again Password")]
        [Required(ErrorMessage = "Not same password!")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "Mail Address")]
        [Required(ErrorMessage = "Please enter your mail")]
        public string Mail { get; set; }


        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter username")]
        public string UserName { get; set; }
    }
}
