using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GiveAid.Models
{
    public class Login
    {
        [Required, MaxLength(50, ErrorMessage = "Please enter a valid email")/*, RegularExpression("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter a valid email")*/]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

    }
}