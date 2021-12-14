using PPPK_Web.Dao;
using PPPK_Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPPK_Web
{
    public partial class Baza : System.Web.UI.Page
    {
        private const string XML_PATH = "App_Data/export.xml";
        private const string XML_PATH_BACKUP = "App_Data/backup.xml";
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private const string SELECT = "SELECT_PUTNE_NALOGE";
        private const string SELECT_BACKUP = "SELECT_ALL";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInicijaliziraj_Click(object sender, EventArgs e)
        {
            try
            {
                Dao.SqlHandler.InicijalizirajBazu();
            }
            catch (Exception)
            {
                lblInfo.Text = "Dogodila se greška!";
            }
        }
        protected void btnOcisti_Click(object sender, EventArgs e)
        {
            try
            {
                Dao.SqlHandler.OcistiBazu();
            }
            catch (Exception)
            {
                lblInfo.Text = "Dogodila se greška!";
            }
        }
        protected void btnExportXml_Click(object sender, EventArgs e)
        {
            try
            {
                ExportXml();
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }
        protected void btnImportXml_Click(object sender, EventArgs e)
        {
            try
            {
                ImportXml();
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        private void ImportXml()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(MapPath(XML_PATH));

            ds.Tables[0].Rows.Cast<DataRow>()
                .ToList()
                .ForEach(row =>
                {
                    PutniNalog nalog = new PutniNalog();
                    nalog.VozacID = int.Parse(row[nameof(PutniNalog.VozacID)].ToString());
                    nalog.VoziloID = int.Parse(row[nameof(PutniNalog.VoziloID)].ToString());
                    nalog.Datum = (DateTime)row[nameof(PutniNalog.Datum)];
                    nalog.KoordinataA = row[nameof(PutniNalog.KoordinataA)].ToString();
                    nalog.KoordinataB = row[nameof(PutniNalog.KoordinataB)].ToString();

                    SqlHandler.DodajPutniNalog(nalog);
                });

            lblInfo.Text = "Import zavrsen!";
        }

        private void ExportXml()
        {
            DataSet ds = CreateDataSet();
            ds.WriteXml(MapPath(XML_PATH), XmlWriteMode.WriteSchema);

            lblInfo.Text = "Export zavrsen!";
        }
        private DataSet CreateDataSet()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter(SELECT, con);
                DataSet ds = new DataSet("Nalozi");
                da.Fill(ds);
                ds.Tables[0].TableName = nameof(PutniNalog);
                return ds;
            }
        }
        protected void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                Backup();
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        private void Backup()
        {
            DataSet ds = CreateBackupDataSet();
            ds.WriteXml(MapPath(XML_PATH_BACKUP), XmlWriteMode.WriteSchema);

            lblInfo.Text = "Backup zavrsen!";
        }
        private DataSet CreateBackupDataSet()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter(SELECT_BACKUP, con);
                DataSet ds = new DataSet("Backup");
                da.Fill(ds);
                ds.Tables[0].TableName = nameof(Vozac);
                ds.Tables[1].TableName = nameof(Vozilo);
                ds.Tables[2].TableName = nameof(PutniNalog);
                ds.Tables[3].TableName = nameof(Servis);
                return ds;
            }
        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                Restore();
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        private void Restore()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(MapPath(XML_PATH_BACKUP));

            ds.Tables[0].Rows.Cast<DataRow>()
                .ToList()
                .ForEach(row =>
                {
                    Vozac vozac = new Vozac();
                    vozac.IDVozac = int.Parse(row[nameof(Vozac.IDVozac)].ToString());
                    vozac.Ime = row[nameof(Vozac.Ime)].ToString();
                    vozac.Prezime = row[nameof(Vozac.Prezime)].ToString();
                    vozac.BrojMobitela = row[nameof(Vozac.BrojMobitela)].ToString();
                    vozac.BrojVozacke = row[nameof(Vozac.BrojVozacke)].ToString();

                    SqlHandler.DodajVozaca(vozac);
                });

            ds.Tables[1].Rows.Cast<DataRow>()
                .ToList()
                .ForEach(row =>
                {
                    Vozilo vozilo = new Vozilo();
                    vozilo.IDVozilo = int.Parse(row[nameof(Vozilo.IDVozilo)].ToString());
                    vozilo.Marka = row[nameof(Vozilo.Marka)].ToString();
                    vozilo.Tip = row[nameof(Vozilo.Tip)].ToString();
                    vozilo.GodinaProizvodnje = row[nameof(Vozilo.GodinaProizvodnje)].ToString();
                    vozilo.InicijalnoStanjeKilometara = row[nameof(Vozilo.InicijalnoStanjeKilometara)].ToString();

                    SqlHandler.DodajVozilo(vozilo);
                });

            ds.Tables[2].Rows.Cast<DataRow>()
                .ToList()
                .ForEach(row =>
                {
                    PutniNalog nalog = new PutniNalog();
                    nalog.IDPutniNalog = int.Parse(row[nameof(PutniNalog.IDPutniNalog)].ToString());
                    nalog.VozacID = int.Parse(row[nameof(PutniNalog.VozacID)].ToString());
                    nalog.VoziloID = int.Parse(row[nameof(PutniNalog.VoziloID)].ToString());
                    nalog.Datum = (DateTime)row[nameof(PutniNalog.Datum)];
                    nalog.KoordinataA = row[nameof(PutniNalog.KoordinataA)].ToString();
                    nalog.KoordinataB = row[nameof(PutniNalog.KoordinataB)].ToString();

                    SqlHandler.DodajPutniNalog(nalog);
                });

            ds.Tables[3].Rows.Cast<DataRow>()
                .ToList()
                .ForEach(row =>
                {
                    Servis servis = new Servis();
                    servis.IDServis = int.Parse(row[nameof(Servis.IDServis)].ToString());
                    servis.VoziloID = int.Parse(row[nameof(Servis.VoziloID)].ToString());
                    servis.StanjeKilometara = int.Parse(row[nameof(Servis.StanjeKilometara)].ToString());
                    servis.Napomena = row[nameof(Servis.Napomena)].ToString();
                    servis.IduciServis = int.Parse(row[nameof(Servis.IduciServis)].ToString());
                    servis.Cijena = int.Parse(row[nameof(Servis.Cijena)].ToString());

                    SqlHandler.DodajServis(servis);
                });

            lblInfo.Text = "Restore zavrsen!";
        }
    }
}