//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YP02._01Proga
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clients1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clients1()
        {
            this.Oplati = new HashSet<Oplati1>();
            this.ZaniatiyaClients = new HashSet<ZaniatiyaClients1>();
        }
    
        public int ID_Client { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientMiddlename { get; set; }
        public string PhoneNumber { get; set; }
        public string DatePokupki { get; set; }
        public string DateOkonchaniya { get; set; }
        public int Abonement_ID { get; set; }
    
        public virtual Abonements1 Abonements { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Oplati1> Oplati { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ZaniatiyaClients1> ZaniatiyaClients { get; set; }
    }
}
