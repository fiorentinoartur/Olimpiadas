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
    
    public partial class People
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public People()
        {
            this.CommutingPerson = new HashSet<CommutingPerson>();
            this.ContainerOccupation = new HashSet<ContainerOccupation>();
            this.Discounts = new HashSet<Discounts>();
            this.Documents = new HashSet<Documents>();
            this.Employees1 = new HashSet<Employees>();
            this.Payments = new HashSet<Payments>();
            this.People1 = new HashSet<People>();
            this.PersonBenefits = new HashSet<PersonBenefits>();
            this.Phones = new HashSet<Phones>();
        }
    
        public int ID { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> BirthDay { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public Nullable<int> ResponsibleID { get; set; }
        public Nullable<int> TypeID { get; set; }
        public Nullable<int> AddressID { get; set; }
    
        public virtual Addresses Addresses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CommutingPerson> CommutingPerson { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContainerOccupation> ContainerOccupation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Discounts> Discounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documents> Documents { get; set; }
        public virtual Employees Employees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employees> Employees1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payments> Payments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<People> People1 { get; set; }
        public virtual People People2 { get; set; }
        public virtual PersonTypes PersonTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonBenefits> PersonBenefits { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phones> Phones { get; set; }
    }
}
