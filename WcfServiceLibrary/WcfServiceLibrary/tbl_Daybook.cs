//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfServiceLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Daybook
    {
        public int IdDaybook { get; set; }
        public int IdGroup { get; set; }
        public System.DateTime LessonsDate { get; set; }
        public int IdUser { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> TimeLate { get; set; }
        public Nullable<int> ClassworkMark { get; set; }
    
        public virtual tbl_Group tbl_Group { get; set; }
        public virtual tbl_User tbl_User { get; set; }
    }
}
