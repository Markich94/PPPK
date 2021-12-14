using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPPK_Web.Models
{
    public class PutniNalog
    {
        public int IDPutniNalog { get; set; }
        public int VozacID { get; set; }
        public int VoziloID { get; set; }
        public DateTime Datum { get; set; }
        public string Tip { get; set; }
        public string KoordinataA { get; set; }
        public string KoordinataB { get; set; }
        public int PrijedeniKilometri { get; set; }
        public int ProsjecnaBrzina { get; set; }
        public int PotrosenoGorivo { get; set; }
        public string Naziv { get => KoordinataA + " - " + KoordinataB + ", " + Datum.ToShortDateString(); }

        public PutniNalog(int iDPutniNalog, int vozacID, int voziloID, DateTime datum, string tip, string koordinataA, string koordinataB, int prijedeniKilometri, int prosjecnaBrzina, int potrosenoGorivo)
        {
            IDPutniNalog = iDPutniNalog;
            VozacID = vozacID;
            VoziloID = voziloID;
            Datum = datum;
            Tip = tip;
            KoordinataA = koordinataA;
            KoordinataB = koordinataB;
            PrijedeniKilometri = prijedeniKilometri;
            ProsjecnaBrzina = prosjecnaBrzina;
            PotrosenoGorivo = potrosenoGorivo;
        }

        public PutniNalog()
        {
        }
    }

}