//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FiorentinoForm.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Addresses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Addresses()
        {
            this.Movings = new HashSet<Movings>();
            this.Movings1 = new HashSet<Movings>();
            this.People = new HashSet<People>();
        }
    
        public int ID { get; set; }
        public string Street { get; set; }
        public Nullable<int> Number { get; set; }
        public string CEP { get; set; }
        public Nullable<int> CityID { get; set; }
    
        public virtual Cities Cities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movings> Movings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Movings> Movings1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<People> People { get; set; }
    }
}
