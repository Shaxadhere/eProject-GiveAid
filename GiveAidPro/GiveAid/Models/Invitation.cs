using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GiveAid.Models
{
    public class Invitation
    {
        [Required, DataType(DataType.EmailAddress), Display(Name = "To")]
        public string ToEmail { get; set; }
        
        
        [DataType(DataType.MultilineText), Display(Name = "Body")]
        public string EmailBody { get; set; }


        [Display(Name = "Subject")]
        public string EmailSubject { get; set; }
    }
}