﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class DB01Entities : DbContext
{
    public DB01Entities()
        : base("name=DB01Entities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Soru> Ders { get; set; }

    public virtual DbSet<Kayit> Kayit { get; set; }

    public virtual DbSet<Uye> Ogrenci { get; set; }

}

}

