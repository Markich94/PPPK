using PPPK_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPPK_Web
{
    public partial class PutniNalozi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PrikaziPutneNaloge();
            }
        }

        private void PrikaziPutneNaloge()
        {
            lbPutniNalozi.DataSource = Dao.SqlHandler.GetPutniNalozi();
            lbPutniNalozi.DataTextField = "Naziv";
            lbPutniNalozi.DataValueField = "IDPutniNalog";
            lbPutniNalozi.DataBind();

            ddVozac.DataSource = Dao.SqlHandler.GetVozaci();
            ddVozac.DataTextField = "PunoIme";
            ddVozac.DataValueField = "IDVozac";
            ddVozac.DataBind();

            ddVozacUpdate.DataSource = Dao.SqlHandler.GetVozaci();
            ddVozacUpdate.DataTextField = "PunoIme";
            ddVozacUpdate.DataValueField = "IDVozac";
            ddVozacUpdate.DataBind();

            ddVozilo.DataSource = Dao.SqlHandler.GetVozila();
            ddVozilo.DataTextField = "Naziv";
            ddVozilo.DataValueField = "IDVozilo";
            ddVozilo.DataBind();

            ddVoziloUpdate.DataSource = Dao.SqlHandler.GetVozila();
            ddVoziloUpdate.DataTextField = "Naziv";
            ddVoziloUpdate.DataValueField = "IDVozilo";
            ddVoziloUpdate.DataBind();
        }
        protected void ddVozilo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var voziloId = int.Parse(ddVozilo.SelectedValue);

            Vozilo vozilo = Dao.SqlHandler.GetVozilo(voziloId);
        }
        protected void ddVoziloUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            var voziloId = int.Parse(ddVozilo.SelectedValue);

            Vozilo vozilo = Dao.SqlHandler.GetVozilo(voziloId);
        }
        protected void lbPutniNalozi_SelectedIndexChanged(object sender, EventArgs e)
        {
            var nalogId = int.Parse(lbPutniNalozi.SelectedValue);

            PutniNalog nalog = Dao.SqlHandler.GetPutniNalog(nalogId);

            if (nalog.IDPutniNalog != 0)
            {
                ddVozacUpdate.SelectedValue = nalog.VozacID.ToString();
                ddVoziloUpdate.Text = nalog.VoziloID.ToString();
                txtDatumUpdate.Text = nalog.Datum.ToString();
                txtTipUpdate.Text = nalog.Tip.ToString();
                txtKoordinataAUpdate.Text = nalog.KoordinataA;
                txtKoordinataBUpdate.Text = nalog.KoordinataB;
                txtKilometriUpdate.Text = nalog.PrijedeniKilometri.ToString();
                txtBrzinaUpdate.Text = nalog.ProsjecnaBrzina.ToString();
                txtGorivoUpdate.Text = nalog.PotrosenoGorivo.ToString();

            }
            else
            {
                ddVoziloUpdate.Text = "-";
                txtDatumUpdate.Text = "-";
                txtTipUpdate.Text = "-";
                txtKoordinataAUpdate.Text = "-";
                txtKoordinataBUpdate.Text = "-";
                txtKilometriUpdate.Text = "-";
                txtBrzinaUpdate.Text = "-";
                txtGorivoUpdate.Text = "-";
            }
        }
        protected void ddVozac_SelectedIndexChanged(object sender, EventArgs e)
        {
            var vozacId = int.Parse(ddVozac.SelectedValue);

            Vozac vozac = Dao.SqlHandler.GetVozac(vozacId);
        }
        protected void ddVozacUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            var vozacId = int.Parse(ddVozacUpdate.SelectedValue);

            Vozac vozac = Dao.SqlHandler.GetVozac(vozacId);
        }
        protected void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                PutniNalog nalog = new PutniNalog
                {
                    VozacID = int.Parse(ddVozac.Text),
                    VoziloID = int.Parse(ddVozilo.Text),
                    Datum = DateTime.Parse(txtDatum.Text),
                    KoordinataA = txtKoordinataA.Text,
                    KoordinataB = txtKoordinataB.Text
                };

                Dao.SqlHandler.DodajPutniNalog(nalog);
                ResetForme();
                PrikaziPutneNaloge();
                lblInfo.Text = "";
            }
            catch (Exception)
            {
                PutniNalog nalog = new PutniNalog
                {
                    //VozacID = int.Parse(txtVozac.Text),
                    VoziloID = int.Parse(ddVozilo.Text),
                    Datum = DateTime.Now,
                    KoordinataA = txtKoordinataA.Text,
                    KoordinataB = txtKoordinataB.Text
                };

                try
                {
                    Dao.SqlHandler.DodajPutniNalog(nalog);
                    ResetForme();
                    PrikaziPutneNaloge();
                    lblInfo.Text = "";
                }
                catch (Exception)
                {
                    lblInfo.Text = "Dogodila se greška!";
                }
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                PutniNalog nalog = new PutniNalog
                {
                    IDPutniNalog = int.Parse(lbPutniNalozi.SelectedValue),
                    VozacID = int.Parse(ddVozacUpdate.Text),
                    VoziloID = int.Parse(ddVoziloUpdate.Text),
                    Datum = DateTime.Parse(txtDatumUpdate.Text),
                    Tip = txtTipUpdate.Text,
                    KoordinataA = txtKoordinataAUpdate.Text,
                    KoordinataB = txtKoordinataBUpdate.Text,
                    PrijedeniKilometri = int.Parse(txtKilometriUpdate.Text),
                    ProsjecnaBrzina = int.Parse(txtBrzinaUpdate.Text),
                    PotrosenoGorivo = int.Parse(txtGorivoUpdate.Text)
                };

                Dao.SqlHandler.UpdatePutniNalog(nalog);
                ResetForme();
                PrikaziPutneNaloge();
                lblInfo.Text = "";
            }
            catch (Exception)
            {
                PutniNalog nalog = new PutniNalog
                {
                    IDPutniNalog = int.Parse(lbPutniNalozi.SelectedValue),
                    VozacID = int.Parse(ddVozacUpdate.Text),
                    VoziloID = int.Parse(ddVoziloUpdate.Text),
                    Datum = DateTime.Now,
                    Tip = txtTipUpdate.Text,
                    KoordinataA = txtKoordinataAUpdate.Text,
                    KoordinataB = txtKoordinataBUpdate.Text,
                    PrijedeniKilometri = int.Parse(txtKilometriUpdate.Text),
                    ProsjecnaBrzina = int.Parse(txtBrzinaUpdate.Text),
                    PotrosenoGorivo = int.Parse(txtGorivoUpdate.Text)
                };

                try
                {
                    Dao.SqlHandler.UpdatePutniNalog(nalog);
                    ResetForme();
                    PrikaziPutneNaloge();
                    lblInfo.Text = "";
                }
                catch (Exception)
                {
                    lblInfo.Text = "Dogodila se greška!";
                }
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Dao.SqlHandler.DeletePutniNalog(int.Parse(lbPutniNalozi.SelectedValue));
                ResetForme();
                PrikaziPutneNaloge();
                lblInfo.Text = "";
            }
            catch (Exception)
            {
                lblInfo.Text = "Dogodila se greška!";
            }
        }
        protected void btnDodajDAAB_Click(object sender, EventArgs e)
        {
            try
            {
                PutniNalog nalog = new PutniNalog
                {
                    VozacID = int.Parse(ddVozac.Text),
                    VoziloID = int.Parse(ddVozilo.Text),
                    Datum = DateTime.Parse(txtDatum.Text),
                    KoordinataA = txtKoordinataA.Text,
                    KoordinataB = txtKoordinataB.Text
                };

                Dao.DBHandler.InsertNalog(nalog);
                ResetForme();
                PrikaziPutneNaloge();
                lblInfo.Text = "";
            }
            catch (Exception)
            {
                PutniNalog nalog = new PutniNalog
                {
                    VozacID = int.Parse(ddVozac.Text),
                    VoziloID = int.Parse(ddVozilo.Text),
                    Datum = DateTime.Now,
                    KoordinataA = txtKoordinataA.Text,
                    KoordinataB = txtKoordinataB.Text
                };

                try
                {
                    Dao.DBHandler.InsertNalog(nalog);
                    ResetForme();
                    PrikaziPutneNaloge();
                    lblInfo.Text = "";
                }
                catch (Exception)
                {
                    lblInfo.Text = "Dogodila se greška!";
                }
            }
        }
        protected void btnUpdateDAAB_Click(object sender, EventArgs e)
        {
            try
            {
                PutniNalog nalog = new PutniNalog
                {
                    IDPutniNalog = int.Parse(lbPutniNalozi.SelectedValue),
                    VozacID = int.Parse(ddVozacUpdate.Text),
                    VoziloID = int.Parse(ddVoziloUpdate.Text),
                    Datum = DateTime.Parse(txtDatumUpdate.Text),
                    Tip = txtTipUpdate.Text,
                    KoordinataA = txtKoordinataAUpdate.Text,
                    KoordinataB = txtKoordinataBUpdate.Text,
                    PrijedeniKilometri = int.Parse(txtKilometriUpdate.Text),
                    ProsjecnaBrzina = int.Parse(txtBrzinaUpdate.Text),
                    PotrosenoGorivo = int.Parse(txtGorivoUpdate.Text)
                };

                Dao.DBHandler.UpdateNalog(nalog, nalog.IDPutniNalog);
                ResetForme();
                PrikaziPutneNaloge();
                lblInfo.Text = "";
            }
            catch (Exception)
            {
                PutniNalog nalog = new PutniNalog
                {
                    IDPutniNalog = int.Parse(lbPutniNalozi.SelectedValue),
                    VozacID = int.Parse(ddVozacUpdate.Text),
                    VoziloID = int.Parse(ddVoziloUpdate.Text),
                    Datum = DateTime.Now,
                    Tip = txtTipUpdate.Text,
                    KoordinataA = txtKoordinataAUpdate.Text,
                    KoordinataB = txtKoordinataBUpdate.Text,
                    PrijedeniKilometri = int.Parse(txtKilometriUpdate.Text),
                    ProsjecnaBrzina = int.Parse(txtBrzinaUpdate.Text),
                    PotrosenoGorivo = int.Parse(txtGorivoUpdate.Text)
                };

                try
                {
                    Dao.DBHandler.UpdateNalog(nalog, nalog.IDPutniNalog);
                    ResetForme();
                    PrikaziPutneNaloge();
                    lblInfo.Text = "";
                }
                catch (Exception)
                {
                    lblInfo.Text = "Dogodila se greška!";
                }
            }
        }
        protected void btnDeleteDAAB_Click(object sender, EventArgs e)
        {
            try
            {
                Dao.DBHandler.DeleteNalog(int.Parse(lbPutniNalozi.SelectedValue));
                ResetForme();
                PrikaziPutneNaloge();
                lblInfo.Text = "";
            }
            catch (Exception)
            {
                lblInfo.Text = "Dogodila se greška!";
            }
        }
        private void ResetForme()
        {
            //txtVozac.Text = "";
            //ddVozilo.Text = "";
            txtDatum.Text = "";
            txtKoordinataA.Text = "";
            txtKoordinataB.Text = "";
            //txtVozacUpdate.Text = "";
            //ddVoziloUpdate.Text = "";
            txtDatumUpdate.Text = "";
            txtKoordinataAUpdate.Text = "";
            txtKoordinataBUpdate.Text = "";
            txtKilometriUpdate.Text = "";
            txtBrzinaUpdate.Text = "";
            txtGorivoUpdate.Text = "";
            //txtVoziloUpdate.Focus();
        }
    }
}