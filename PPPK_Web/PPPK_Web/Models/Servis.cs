using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PPPK_Web.Models
{
    [Table("Servis")]
    public class Servis
    {
        [Key]
        public int IDServis { get; set; }
        public int VoziloID { get; set; }
        public int StanjeKilometara { get; set; }
        public string Napomena { get; set; }
        public int IduciServis { get; set; }
        public int Cijena { get; set; }

        public Servis(int idServis, int voziloId, int stanjeKilometara, string napomena, int iduciServis, int cijena)
        {
            this.IDServis = idServis;
            this.VoziloID = voziloId;
            this.StanjeKilometara = stanjeKilometara;
            this.Napomena = napomena;
            this.IduciServis = iduciServis;
            this.Cijena = cijena;
        }
        public Servis()
        {

        }
    }
}