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
    
    public partial class tbl_Group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Group()
        {
            this.tbl_AdminDaybook = new HashSet<tbl_AdminDaybook>();
            this.tbl_ConGroup = new HashSet<tbl_ConGroup>();
            this.tbl_Daybook = new HashSet<tbl_Daybook>();
            this.tbl_Homework = new HashSet<tbl_Homework>();
            this.tbl_TrainingMaterial = new HashSet<tbl_TrainingMaterial>();
        }
    
        public int IdGroup { get; set; }
        public string Name { get; set; }
        public string CurrentSubject { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_AdminDaybook> tbl_AdminDaybook { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ConGroup> tbl_ConGroup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Daybook> tbl_Daybook { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Homework> tbl_Homework { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_TrainingMaterial> tbl_TrainingMaterial { get; set; }
    }
}