
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace anketproje.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Uye
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Uye()
    {

        this.Kayit = new HashSet<Kayit>();

    }


    public string uyeId { get; set; }

    public string uyeNo { get; set; }

    public string uyeAdsoyad { get; set; }

    public int uyeKayitTarih { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Kayit> Kayit { get; set; }

}

}
