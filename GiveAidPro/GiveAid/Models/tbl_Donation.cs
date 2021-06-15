//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GiveAid.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_Donation
    {
        public int PK_ID { get; set; }
        public Nullable<int> FK_User { get; set; }

        [Required]
        public Nullable<int> FK_NGO { get; set; }

        [Required]
        public Nullable<int> FK_DonationCause { get; set; }

        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> DateTime { get; set; }

        [Required, Display(Name = "Amout")]
        public Nullable<decimal> Amount { get; set; }

        [Required, DataType(DataType.CreditCard), CreditCard]
        public string CreditCard { get; set; }

        [Required, MaxLength(3, ErrorMessage ="Invalid CVV"), RegularExpression("^[0-9]{3,4}$", ErrorMessage ="Invalid CVV")]
        public string CVV { get; set; }

        [Required, RegularExpression("^(0[1-9]|1[0-2])\\/?([0-9]{4}|[0-9]{2})$", ErrorMessage ="Please type expiry date in MM/YY format"), Display(Name = "Expiry Date")]
        public string ExpiryDate { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<bool> Deleted { get; set; }
    
        public virtual tbl_DonationCause tbl_DonationCause { get; set; }
        public virtual tbl_NGO tbl_NGO { get; set; }
        public virtual tbl_User tbl_User { get; set; }
    }
}
