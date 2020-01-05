using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
    public class UserDto
    {
        [Required]
        [Display(Name="User Name")]
        public string UserName { set; get; }
        [Required]
        [EmailAddress]
        public string Email { set; get; }
        [Required]
        [Display(Name="Phone Number")]
        public string PhoneNumber { set; get; }
        [Display(Name="VIP")]
        public bool IsVip { set; get; }
        [Display(Name="VIP Expriry Date")]
        [DataType(DataType.Date)]
        public DateTime? VipExpDate { set; get; }
        public bool Enable { set; get; }
    }
    public class RegisterDto
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { set; get; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { set; get; }
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { set; get; }
        [Required]
        [EmailAddress]
        public string Email { set; get; }
        [Required]
        public string PhoneNumber { set; get; }
    }
    public class ChangePassDto
    {
        public string CurrentPassword { set; get; }
        public string Password { set; get; }
        public string ConfirmPassword { set; get; }
    }
    public class ResetPassword
    {
        public string UserName { set; get; }
        public string Email { set; get; }
    }
}
