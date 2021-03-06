using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FiorelloHomeWork.ViewModels
{
    public class RegisterViewModel
    {
        [Required,StringLength(maximumLength:100)]
        public string Fullname { get; set; }
        [Required, StringLength(maximumLength: 100)]
        public string Username { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password),Compare(nameof(Password),ErrorMessage ="Parolun iksinide eyni yaz")]
        public string ConfirmPassword { get; set; }
    }
}
