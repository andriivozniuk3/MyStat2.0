//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceDll
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_AdminDaybook
    {
        public int IdAdminDaybook { get; set; }
        public Nullable<int> IdGroup { get; set; }
        public Nullable<int> IdTeacher { get; set; }
        public System.DateTime LessonsDate { get; set; }
        public string Subject { get; set; }
    
        public virtual tbl_Group tbl_Group { get; set; }
        public virtual tbl_User tbl_User { get; set; }
    }
}
