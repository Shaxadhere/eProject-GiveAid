using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GiveAid.Models
{
    public class Contact
    {
        [DataType(DataType.EmailAddress), Display(Name = "To"), EmailAddress]
        public string ToEmail { get; set; }

        [Required, DataType(DataType.EmailAddress), Display(Name = "To"), EmailAddress]
        public string UserEmail { get; set; }

        [Required, Display(Name = "Message"), MaxLength(300, ErrorMessage ="Message is too long it must not exceed from 300 charecters"), DataType(DataType.MultilineText)]
        public string EMailBody { get; set; }

        [Display(Name = "Subject"), MaxLength(100, ErrorMessage = "Subject is too long it must not exceed from 100 charecters")]
        public string EmailSubject { get; set; }
    }
}