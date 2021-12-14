using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPPK_Web.Models
{
    public class Vozilo
    {
        public int IDVozilo { get; set; }
        public string Marka { get; set; }
        public string Tip { get; set; }
        public string GodinaProizvodnje { get; set; }
        public string InicijalnoStanjeKilometara { get; set; }
        public string Naziv { get => Marka + " " + Tip; }

        public Vozilo(int iDVozilo, string marka, string tip, string godinaProizvodnje, string inicijalnoStanjeKilometara)
        {
            IDVozilo = iDVozilo;
            Marka = marka;
            Tip = tip;
            GodinaProizvodnje = godinaProizvodnje;
            InicijalnoStanjeKilometara = inicijalnoStanjeKilometara;
        }
        public Vozilo()
        {
        }
    }
}