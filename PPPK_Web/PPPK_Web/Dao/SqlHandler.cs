using PPPK_Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Linq;
using System.Web;
using System.Data;

namespace PPPK_Web.Dao
{
    public class SqlHandler
    {
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private const string SELECT = "SELECT_PUTNE_NALOGE";

        internal static IEnumerable<Vozac> GetVozaci()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetVozaci);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return new Vozac
                            (
                                (int)dr[nameof(Vozac.IDVozac)],
                                dr[nameof(Vozac.Ime)].ToString(),
                                dr[nameof(Vozac.Prezime)].ToString(),
                                dr[nameof(Vozac.BrojMobitela)].ToString(),
                                dr[nameof(Vozac.BrojVozacke)].ToString()
                            );
                        }
                    }
                }
            }
        }

        internal static void OcistiBazu()
        {
            SqlHelper.ExecuteNonQuery(cs, "OcistiBazu");
        }

        internal static void InicijalizirajBazu()
        {
            SqlHelper.ExecuteNonQuery(cs, "NapuniBazu");
        }

        internal static Vozac GetVozac(int vozacId)
        {
            var tblVozac = SqlHelper.ExecuteDataset(cs, "GetVozac", vozacId).Tables[0];
            Vozac vozac = new Vozac();

            foreach (DataRow row in tblVozac.Rows)
            {
                try
                {
                    vozac = new Vozac
                    {
                        IDVozac = (int)row["IDVozac"],
                        Ime = row["Ime"].ToString(),
                        Prezime = row["Prezime"].ToString(),
                        BrojMobitela = row["BrojMobitela"].ToString(),
                        BrojVozacke = row["BrojVozacke"].ToString()
                    };
                }
                catch
                {
                    vozac = new Vozac
                    {
                        IDVozac = 0,
                        Ime = "",
                        Prezime = "",
                        BrojMobitela = "",
                        BrojVozacke = ""
                    };
                }
            }

            return vozac;
        }

        internal static void DodajVozaca(Vozac vozac)
        {
            SqlHelper.ExecuteNonQuery(cs, "AddVozac", vozac.Ime, vozac.Prezime, vozac.BrojMobitela, vozac.BrojVozacke);
        }
        internal static void UpdateVozaca(Vozac vozac)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateVozac", vozac.IDVozac, vozac.Ime, vozac.Prezime, vozac.BrojMobitela, vozac.BrojVozacke);
        }
        internal static void DeleteVozac(int idVozac)
        {
            SqlHelper.ExecuteNonQuery(cs, "DeleteVozac", idVozac);
        }
        internal static IEnumerable<Vozilo> GetVozila()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetVozila);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return new Vozilo
                            (
                                (int)dr[nameof(Vozilo.IDVozilo)],
                                dr[nameof(Vozilo.Marka)].ToString(),
                                dr[nameof(Vozilo.Tip)].ToString(),
                                dr[nameof(Vozilo.InicijalnoStanjeKilometara)].ToString(),
                                dr[nameof(Vozilo.GodinaProizvodnje)].ToString()
                            );
                        }
                    }
                }
            }
        }

        internal static Vozilo GetVozilo(int voziloId)
        {
            var tblVozilo = SqlHelper.ExecuteDataset(cs, "GetVozilo", voziloId).Tables[0];
            Vozilo vozilo = new Vozilo();

            foreach (DataRow row in tblVozilo.Rows)
            {
                try
                {
                    vozilo = new Vozilo
                    {
                        IDVozilo = (int)row["IDVozilo"],
                        Marka = row["Marka"].ToString(),
                        Tip = row["Tip"].ToString(),
                        InicijalnoStanjeKilometara = row["InicijalnoStanjeKilometara"].ToString(),
                        GodinaProizvodnje = row["GodinaProizvodnje"].ToString()
                    };
                }
                catch
                {
                    vozilo = new Vozilo
                    {
                        IDVozilo = 0,
                        Marka = "",
                        Tip = "",
                        InicijalnoStanjeKilometara = "",
                        GodinaProizvodnje = ""
                    };
                }
            }

            return vozilo;
        }

        internal static void DodajVozilo(Vozilo vozilo)
        {
            SqlHelper.ExecuteNonQuery(cs, "AddVozilo", vozilo.Marka, vozilo.Tip, vozilo.GodinaProizvodnje, vozilo.InicijalnoStanjeKilometara);
        }
        internal static void UpdateVozilo(Vozilo vozilo)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdateVozilo", vozilo.IDVozilo, vozilo.Marka, vozilo.Tip, vozilo.InicijalnoStanjeKilometara, vozilo.GodinaProizvodnje);
        }
        internal static void DeleteVozilo(int idVozilo)
        {
            SqlHelper.ExecuteNonQuery(cs, "DeleteVozilo", idVozilo);
        }

        internal static IEnumerable<PutniNalog> GetPutniNalozi()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetPutniNalozi);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return new PutniNalog
                            (
                                (int)dr[nameof(PutniNalog.IDPutniNalog)],
                                (int)dr[nameof(PutniNalog.VozacID)],
                                (int)dr[nameof(PutniNalog.VoziloID)],
                                (DateTime)dr[nameof(PutniNalog.Datum)],
                                dr[nameof(PutniNalog.Tip)].ToString(),
                                dr[nameof(PutniNalog.KoordinataA)].ToString(),
                                dr[nameof(PutniNalog.KoordinataB)].ToString(),
                                (int)dr[nameof(PutniNalog.PrijedeniKilometri)],
                                (int)dr[nameof(PutniNalog.ProsjecnaBrzina)],
                                (int)dr[nameof(PutniNalog.PotrosenoGorivo)]
                            );
                        }
                    }
                }
            }
        }
        internal static PutniNalog GetPutniNalog(int nalogId)
        {
            var tblNalog = SqlHelper.ExecuteDataset(cs, "GetPutniNalog", nalogId).Tables[0];
            PutniNalog nalog = new PutniNalog();

            foreach (DataRow row in tblNalog.Rows)
            {
                try
                {
                    nalog = new PutniNalog
                    {
                        IDPutniNalog = (int)row["IDPutniNalog"],
                        VozacID = (int)row["VozacID"],
                        VoziloID = (int)row["VoziloID"],
                        Datum = (DateTime)row["Datum"],
                        Tip = row["Tip"].ToString(),
                        KoordinataA = row["KoordinataA"].ToString(),
                        KoordinataB = row["KoordinataB"].ToString(),
                        PrijedeniKilometri = (int)row["PrijedeniKilometri"],
                        ProsjecnaBrzina = (int)row["ProsjecnaBrzina"],
                        PotrosenoGorivo = (int)row["PotrosenoGorivo"]
                    };
                }
                catch
                {
                    nalog = new PutniNalog
                    {
                        IDPutniNalog = 0,
                        VozacID = 0,
                        VoziloID = 0,
                        Datum = DateTime.Now,
                        Tip = "",
                        KoordinataA = "",
                        KoordinataB = "",
                        PrijedeniKilometri = 0,
                        ProsjecnaBrzina = 0,
                        PotrosenoGorivo = 0
                    };
                }
            }

            return nalog;
        }
        internal static void DodajPutniNalog(PutniNalog nalog)
        {
            SqlHelper.ExecuteNonQuery(cs, "AddPutniNalog", nalog.VozacID, nalog.VoziloID, nalog.Datum, nalog.KoordinataA, nalog.KoordinataB);
        }
        internal static void UpdatePutniNalog(PutniNalog nalog)
        {
            SqlHelper.ExecuteNonQuery(cs, "UpdatePutniNalog", nalog.IDPutniNalog, nalog.VozacID, nalog.VoziloID, nalog.Datum, nalog.Tip, nalog.KoordinataA, nalog.KoordinataB, nalog.PrijedeniKilometri, nalog.ProsjecnaBrzina, nalog.PotrosenoGorivo);
        }
        internal static void DeletePutniNalog(int idPutniNalog)
        {
            SqlHelper.ExecuteNonQuery(cs, "DeletePutniNalog", idPutniNalog);
        }
        internal static void DodajServis(Servis servis)
        {
            SqlHelper.ExecuteNonQuery(cs, "AddServis", servis.VoziloID, servis.StanjeKilometara, servis.Napomena, servis.IduciServis, servis.Cijena);
        }
        internal static Servis GetServis(int voziloId)
        {
            var tblServis = SqlHelper.ExecuteDataset(cs, "GetServis", voziloId).Tables[0];
            Servis servis = new Servis();

            foreach (DataRow row in tblServis.Rows)
            {
                try
                {
                    servis = new Servis
                    {
                        IDServis = (int)row["IDServis"],
                        VoziloID = (int)row["Vozilo"],
                        StanjeKilometara = (int)row["StanjeKilometara"],
                        Napomena = row["Napomena"].ToString(),
                        IduciServis = (int)row["IduciServis"],
                        Cijena = (int)row["Cijena"]
                    };
                }
                catch
                {
                    servis = new Servis
                    {
                        IDServis = 0,
                        VoziloID = 0,
                        StanjeKilometara = 0,
                        Napomena = "-",
                        IduciServis = 0,
                        Cijena = 0
                    };
                }
            }

            return servis;
        }
        //internal DataSet CreateDataSet()
        //{
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        SqlDataAdapter da = new SqlDataAdapter(SELECT, con);
        //        DataSet ds = new DataSet("Nalozi");
        //        da.Fill(ds);
        //        ds.Tables[0].TableName = nameof(PutniNalog);
        //        return ds;
        //    }
        //}
    }
}