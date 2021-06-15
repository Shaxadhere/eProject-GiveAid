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

    public partial class tbl_OurAchievements
    {
        public int PK_ID { get; set; }

        [Required, DataType(DataType.Text), MaxLength(50, ErrorMessage ="Name must not exceed from 50 charecters"), Display(Name = "Name")]
        public string Name { get; set; }

        [DataType(DataType.Text), MaxLength(980, ErrorMessage = "Picture name must not exceed from 980 charecters"), Display(Name = "Picture")]
        public string Picture { get; set; }

        [Required, DataType(DataType.MultilineText), MaxLength(2500, ErrorMessage = "Description must not exceed from 2500 charecters"), Display(Name = "Description")]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> DateTime { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<bool> Deleted { get; set; }
    }
}