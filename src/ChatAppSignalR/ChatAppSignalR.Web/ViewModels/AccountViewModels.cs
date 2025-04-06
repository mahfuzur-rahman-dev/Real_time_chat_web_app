using System.ComponentModel.DataAnnotations;

namespace ChatAppSignalR.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember me?")]
        public bool RememberMe { get; set; }
    }



    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(10,MinimumLength =3)]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(10, MinimumLength = 3)]
        public string LasttName { get; set; }


        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is required.")]
        [StringLength(40,MinimumLength =8,ErrorMessage ="The {0} must be at {2} and at max {1} character long.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage ="Password not matched.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at {2} and at max {1} character long.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        public string ConfirmPassword { get; set; }
    }


    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
    }


    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "New password is required.")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at {2} and at max {1} character long.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmNewPassword", ErrorMessage = "Password not matched.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm new password is required.")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "The {0} must be at {2} and at max {1} character long.")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm new password")]
        public string ConfirmNewPassword { get; set; }
    }
}

