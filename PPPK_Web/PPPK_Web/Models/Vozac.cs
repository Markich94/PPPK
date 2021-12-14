using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPPK_Web.Models
{
    public class Vozac
    {
        public int IDVozac { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojMobitela { get; set; }
        public string BrojVozacke { get; set; }
        public string PunoIme { get => Ime + " " + Prezime; }

        public Vozac(int iDVozac, string ime, string prezime, string brojMobitela, string brojVozacke)
        {
            IDVozac = iDVozac;
            Ime = ime;
            Prezime = prezime;
            BrojMobitela = brojMobitela;
            BrojVozacke = brojVozacke;
        }

        public Vozac()
        {
        }
    }
}