//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FiorentionoDesktop.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            this.Notificacao = new HashSet<Notificacao>();
            this.PerguntaUsuario = new HashSet<PerguntaUsuario>();
            this.Usuarios1 = new HashSet<Usuarios>();
        }
    
        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public byte[] Foto { get; set; }
        public string apelido { get; set; }
        public string timeFavorito { get; set; }
        public string corFavorita { get; set; }
        public Nullable<System.DateTime> nascimento { get; set; }
        public Nullable<int> idIndicado { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
        public System.DateTime DataConvite { get; set; }
        public Nullable<bool> RecebeNotificacao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notificacao> Notificacao { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PerguntaUsuario> PerguntaUsuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuarios> Usuarios1 { get; set; }
        public virtual Usuarios Usuarios2 { get; set; }
    }
}
