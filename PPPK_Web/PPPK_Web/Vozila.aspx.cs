using PPPK_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPPK_Web
{
    public partial class Vozila : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PrikaziVozila();
            }
        }

        private void PrikaziVozila()
        {
            lbVozila.DataSource = Dao.SqlHandler.GetVozila();
            lbVozila.DataTextField = "Naziv";
            lbVozila.DataValueField = "IDVozilo";
            lbVozila.DataBind();
        }
        protected void lbVozila_SelectedIndexChanged(object sender, EventArgs e)
        {
            var voziloId = int.Parse(lbVozila.SelectedValue);

            Vozilo vozilo = Dao.SqlHandler.GetVozilo(voziloId);

            if (vozilo.IDVozilo != 0)
            {
                txtMarkaUpdate.Text = vozilo.Marka;
                txtTipUpdate.Text = vozilo.Tip;
                txtGodinaProizvodnjeUpdate.Text = vozilo.GodinaProizvodnje;
                txtStanjeKilometaraUpdate.Text = vozilo.InicijalnoStanjeKilometara;

            }
            else
            {
                txtMarkaUpdate.Text = "-";
                txtTipUpdate.Text = "-";
                txtGodinaProizvodnjeUpdate.Text = "-";
                txtStanjeKilometaraUpdate.Text = "-";
            }
        }
        protected void btnDodaj_Click(object sender, EventArgs e)
        {
            Vozilo vozilo = new Vozilo
            {
                Marka = txtMarka.Text,
                Tip = txtTip.Text,
                InicijalnoStanjeKilometara = txtStanjeKilometara.Text,
                GodinaProizvodnje = txtGodinaProizvodnje.Text
            };

            try
            {
                Dao.SqlHandler.DodajVozilo(vozilo);
                ResetForme();
                PrikaziVozila();
                lblInfo.Text = "";
            }
            catch (Exception)
            {
                lblInfo.Text = "Dogodila se greška!";
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Vozilo vozilo = new Vozilo
            {
                IDVozilo = int.Parse(lbVozila.SelectedValue),
                Marka = txtMarkaUpdate.Text,
                Tip = txtTipUpdate.Text,
                InicijalnoStanjeKilometara = txtStanjeKilometaraUpdate.Text,
                GodinaProizvodnje = txtGodinaProizvodnjeUpdate.Text
            };

            try
            {
                Dao.SqlHandler.UpdateVozilo(vozilo);
                ResetForme();
                PrikaziVozila();
                lblInfo.Text = "";
            }
            catch (Exception)
            {
                lblInfo.Text = "Dogodila se greška!";
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Dao.SqlHandler.DeleteVozilo(int.Parse(lbVozila.SelectedValue));
                ResetForme();
                PrikaziVozila();
                lblInfo.Text = "";
            }
            catch (Exception)
            {
                lblInfo.Text = "Dogodila se greška!";
            }
        }
        private void ResetForme()
        {
            txtMarka.Text = "";
            txtTip.Text = "";
            txtStanjeKilometara.Text = "";
            txtGodinaProizvodnje.Text = "";
            txtMarkaUpdate.Text = "";
            txtTipUpdate.Text = "";
            txtStanjeKilometaraUpdate.Text = "";
            txtGodinaProizvodnjeUpdate.Text = "";
            txtMarkaUpdate.Focus();
        }
    }
}