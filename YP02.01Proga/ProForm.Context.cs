﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProFormEntities : DbContext
    {
        public ProFormEntities()
            : base("name=ProFormEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<RoleSotrudnikas> RoleSotrudnikas { get; set; }
        public virtual DbSet<Sotrudniki> Sotrudniki { get; set; }
        public virtual DbSet<SrokiAbonements> SrokiAbonements { get; set; }
        public virtual DbSet<Abonements1> Abonements1Set { get; set; }
        public virtual DbSet<Clients1> Clients1Set { get; set; }
        public virtual DbSet<Oplati1> Oplati1Set { get; set; }
        public virtual DbSet<Treners1> Treners1Set { get; set; }
        public virtual DbSet<TrenerTypes1> TrenerTypes1Set { get; set; }
        public virtual DbSet<TypeDeystviyas1> TypeDeystviyas1Set { get; set; }
        public virtual DbSet<Zaniatiya1> Zaniatiya1Set { get; set; }
        public virtual DbSet<ZaniatiyaClients1> ZaniatiyaClients1Set { get; set; }
    }
}
