//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BilgeKolejii.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ogrenciler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ogrenciler()
        {
            this.Sinavlar = new HashSet<Sinavlar>();
            this.Veliler = new HashSet<Veliler>();
            this.Yoklama = new HashSet<Yoklama>();
        }
    
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Cinsiyet { get; set; }
        public string TCNo { get; set; }
        public string Gsm { get; set; }
        public Nullable<int> OkulNo { get; set; }
        public Nullable<int> SinifId { get; set; }
        public string SubeId { get; set; }
        public string DevamDurumu { get; set; }
        public string BitirdigiOkul { get; set; }
        public Nullable<decimal> NotOrt { get; set; }
    
        public virtual Sube Sube { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sinavlar> Sinavlar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Veliler> Veliler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yoklama> Yoklama { get; set; }
    }
}
