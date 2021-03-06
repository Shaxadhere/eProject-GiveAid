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

    public partial class tbl_IntrestActivities
    {
        public int PK_ID { get; set; }
        public Nullable<int> FK_User { get; set; }
        public Nullable<int> FK_Activity { get; set; }

        [Required, DataType(DataType.MultilineText), MaxLength(2500, ErrorMessage = "Message must not exceed from 2500 charecters"), Display(Name = "Message")]
        public string Message { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<bool> Deleted { get; set; }
    
        public virtual tbl_User tbl_User { get; set; }
    }
}
