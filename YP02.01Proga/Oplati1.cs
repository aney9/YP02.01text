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
    
    public partial class Oplati1
    {
        public int ID_Oplati { get; set; }
        public string DateOplati { get; set; }
        public int CodeOplati { get; set; }
        public bool Skidka { get; set; }
        public decimal Summa { get; set; }
        public int Client_ID { get; set; }
    
        public virtual Clients1 Clients { get; set; }
    }
}
