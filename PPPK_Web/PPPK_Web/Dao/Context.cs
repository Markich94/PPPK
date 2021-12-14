using PPPK_Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PPPK_Web.Dao
{
    public class Context : DbContext
    {
        public Context() : base("name=cs")
        {
        }
        public DbSet<Servis> Servisi { get; set; }
        public DbSet<Vozac> Vozaci { get; set; }
        public DbSet<PutniNalog> PutniNalozi { get; set; }
        public DbSet<Vozilo> Vozila { get; set; }
    }
}