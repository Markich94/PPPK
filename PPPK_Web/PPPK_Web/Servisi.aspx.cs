using PPPK_Web.Dao;
using PPPK_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPPK_Web
{
    public partial class Servisi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PrikaziServise();
            }
        }

        private void PrikaziServise()
        {
            lbServisiVozila.DataSource = Dao.SqlHandler.GetVozila();
            lbServisiVozila.DataTextField = "Naziv";
            lbServisiVozila.DataValueField = "IDVozilo";
            lbServisiVozila.DataBind();

            ddVozilo.DataSource = Dao.SqlHandler.GetVozila();
            ddVozilo.DataTextField = "Naziv";
            ddVozilo.DataValueField = "IDVozilo";
            ddVozilo.DataBind();
        }
        protected void lbServisiVozila_SelectedIndexChanged(object sender, EventArgs e)
        {
            var voziloId = int.Parse(lbServisiVozila.SelectedValue);

            Servis servis = Dao.SqlHandler.GetServis(voziloId);

            if (servis.IDServis != 0)
            {
                txtVoziloUpdate.Text = servis.VoziloID.ToString();
                txtStanjeKilometaraUpdate.Text = servis.StanjeKilometara.ToString();
                txtNapomenaUpdate.Text = servis.Napomena;
                txtIduciServisUpdate.Text = servis.IduciServis.ToString();
                txtCijenaUpdate.Text = servis.Cijena.ToString();

            }
            else
            {
                txtVoziloUpdate.Text = "-";
                txtStanjeKilometaraUpdate.Text = "-";
                txtNapomenaUpdate.Text = "-";
                txtIduciServisUpdate.Text = "-";
                txtCijenaUpdate.Text = "-";
            }
        }
        protected void ddVozilo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var voziloId = int.Parse(ddVozilo.SelectedValue);

            Vozilo vozilo = Dao.SqlHandler.GetVozilo(voziloId);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (var db = new Context())
            {
                GetServisByCar(db, 1046);
            }
        }
        protected void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                Servis servis = new Servis
                {
                    VoziloID = int.Parse(ddVozilo.SelectedValue),
                    StanjeKilometara = int.Parse(txtStanjeKilometara.Text),
                    Napomena = txtNapomena.Text,
                    IduciServis = int.Parse(txtIduciServis.Text),
                    Cijena = int.Parse(txtCijena.Text)
                };

                Dao.SqlHandler.DodajServis(servis);
                ResetForme();
                PrikaziServise();
                lblInfo.Text = "";
            }
            catch (Exception)
            {
                lblInfo.Text = "Dogodila se greška!";
            }
        }
        private void ResetForme()
        {
            txtCijena.Text = "-";
            txtIduciServis.Text = "-";
            txtNapomena.Text = "-";
            txtStanjeKilometara.Text = "-";
            txtVoziloUpdate.Text = "-";
        }
        private static void GetServisByCar(Context db, int voziloId)
        {
            var servisi = db.Servisi;
        }
    }
}