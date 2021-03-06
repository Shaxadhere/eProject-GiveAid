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

    public partial class tbl_Partner
    {
        public int PK_ID { get; set; }

        [Required, MaxLength(50, ErrorMessage ="Partner name must not exceed from 50 charecters"), Display(Name = "Partner Name")]
        public string PartnerName { get; set; }

        [Required, DataType(DataType.Url), Url, MaxLength(50, ErrorMessage ="Website url is too long that it must happen to be invalid")]
        public string Website { get; set; }

        [DataType(DataType.Text), MaxLength(980, ErrorMessage = "Logo name is too long it must not exceed from  980 charecters")]
        public string Logo { get; set; }

        [Required, DataType(DataType.MultilineText), MaxLength(2500, ErrorMessage ="Description must not exceed from 2500 charecters")]
        public string Description { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<bool> Deleted { get; set; }
    }
}
