//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace A9_Production
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Register
    {
        public Register()
        {
            this.Users = new HashSet<User>();
        }
    
        public int Id { get; set; }
        [Required(ErrorMessage="Please Enter your FirstName",AllowEmptyStrings=false)]
        public string FirstName { get; set; }
        [Required(ErrorMessage="Please Enter your LastName",AllowEmptyStrings=false)]
        public string LastName { get; set; }
        [Required(ErrorMessage="Please Choose your Username",AllowEmptyStrings=false)]
        public string Username { get; set; }
        [Required(ErrorMessage="Please Choose your password",AllowEmptyStrings=false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(50,MinimumLength=8,ErrorMessage="Please choose a password of minimum 8 Characters")]
        public string Password { get; set; }
        [Required(ErrorMessage="Please Confirm your password",AllowEmptyStrings=false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [Compare("Password",ErrorMessage="Password does not match")]
        public string ConfirmPassword { get; set; }
        public Nullable<System.DateTime> DateOFBirth { get; set; }
        public string Gender { get; set; }
        public string MOBILE { get; set; }
        public bool ISACTIVE { get; set; }
        [Required(ErrorMessage="Please Enter your Email",AllowEmptyStrings=false)]
        public string Email { get; set; }
        public Nullable<int> Role_Id { get; set; }
        public Nullable<bool> CanLogin { get; set; }
        public Nullable<bool> IsAdmin { get; set; }
    
        public virtual ICollection<User> Users { get; set; }
    }
}
