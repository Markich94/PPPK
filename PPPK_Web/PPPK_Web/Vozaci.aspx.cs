using PPPK_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPPK_Web
{
    public partial class Vozaci : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PrikaziVozace();
            }
        }

        private void PrikaziVozace()
        {
            lbVozaci.DataSource = Dao.SqlHandler.GetVozaci();
            lbVozaci.DataTextField = "PunoIme";
            lbVozaci.DataValueField = "IDVozac";
            lbVozaci.DataBind();
        }
        protected void lbVozaci_SelectedIndexChanged(object sender, EventArgs e)
        {
            var vozacId = int.Parse(lbVozaci.SelectedValue);

            Vozac vozac = Dao.SqlHandler.GetVozac(vozacId);

            if (vozac.IDVozac != 0)
            {
                txtImeUpdate.Text = vozac.Ime;
                txtPrezimeUpdate.Text = vozac.Prezime;
                txtBrojMobitelaUpdate.Text = vozac.BrojMobitela;
                txtBrojVozackeUpdate.Text = vozac.BrojVozacke;

            }
            else
            {
                txtImeUpdate.Text = "-";
                txtPrezimeUpdate.Text = "-";
                txtBrojMobitelaUpdate.Text = "-";
                txtBrojVozackeUpdate.Text = "-";
            }
        }
        protected void btnDodaj_Click(object sender, EventArgs e)
        {
            Vozac vozac = new Vozac
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                BrojMobitela = txtBrojMobitela.Text,
                BrojVozacke = txtBrojVozacke.Text
            };

            try
            {
                Dao.SqlHandler.DodajVozaca(vozac);
                ResetForme();
                PrikaziVozace();
                lblInfo.Text = "";
            }
            catch (Exception)
            {
                lblInfo.Text = "Dogodila se greška!";
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Vozac vozac = new Vozac
            {
                IDVozac = int.Parse(lbVozaci.SelectedValue),
                Ime = txtImeUpdate.Text,
                Prezime = txtPrezimeUpdate.Text,
                BrojMobitela = txtBrojMobitelaUpdate.Text,
                BrojVozacke = txtBrojVozackeUpdate.Text
            };

            try
            {
                Dao.SqlHandler.UpdateVozaca(vozac);
                ResetForme();
                PrikaziVozace();
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
                Dao.SqlHandler.DeleteVozac(int.Parse(lbVozaci.SelectedValue));
                ResetForme();
                PrikaziVozace();
                lblInfo.Text = "";
            }
            catch (Exception)
            {
                lblInfo.Text = "Dogodila se greška!";
            }
        }
        private void ResetForme()
        {
            txtIme.Text = "";
            txtPrezime.Text = "";
            txtBrojMobitela.Text = "";
            txtBrojVozacke.Text = "";
            txtImeUpdate.Text = "";
            txtPrezimeUpdate.Text = "";
            txtBrojMobitelaUpdate.Text = "";
            txtBrojVozackeUpdate.Text = "";
            txtImeUpdate.Focus();
        }
    }
}