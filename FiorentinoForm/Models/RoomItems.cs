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
    
    public partial class RoomItems
    {
        public int ID { get; set; }
        public Nullable<int> RoomID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> ServiceOrderID { get; set; }
    
        public virtual Items Items { get; set; }
        public virtual Rooms Rooms { get; set; }
        public virtual ServiceOrder ServiceOrder { get; set; }
    }
}
