using PPPK_I7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PPPK_I7
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
            using(PPPK_ProjektEntities context = new PPPK_ProjektEntities())
            {
                IEnumerable<Vozilo> vozila = new List<Vozilo>();
                vozila = context.Vozilo;

                lbServisiVozila.DataSource = vozila.ToList();
                lbServisiVozila.DataTextField = "Naziv";
                lbServisiVozila.DataValueField = "IDVozilo";
                lbServisiVozila.DataBind();

                ddVozilo.DataSource = vozila.ToList();
                ddVozilo.DataTextField = "Naziv";
                ddVozilo.DataValueField = "IDVozilo";
                ddVozilo.DataBind();
            }
        }
        protected void lbServisiVozila_SelectedIndexChanged(object sender, EventArgs e)
        {
            var voziloId = int.Parse(lbServisiVozila.SelectedValue);

            using(PPPK_ProjektEntities context = new PPPK_ProjektEntities())
            {
                Servis servis = context.Servis.FirstOrDefault(s => s.Vozilo == voziloId);

                if (servis != null)
                {
                    txtVoziloUpdate.Text = servis.Vozilo.ToString();
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

            //Servis servis = Dao.SqlHandler.GetServis(voziloId);
        }
        protected void ddVozilo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var voziloId = int.Parse(ddVozilo.SelectedValue);

            using(PPPK_ProjektEntities context = new PPPK_ProjektEntities())
            {
                Vozilo vozilo = context.Vozilo.FirstOrDefault(v => v.IDVozilo == voziloId);
            }

            //Vozilo vozilo = Dao.SqlHandler.GetVozilo(voziloId);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var voziloId = int.Parse(lbServisiVozila.SelectedValue);

            GetServisByCar(voziloId);
        }
        protected void btnDodaj_Click(object sender, EventArgs e)
        {
            try
            {
                Servis servis = new Servis
                {
                    Vozilo = int.Parse(ddVozilo.SelectedValue),
                    StanjeKilometara = int.Parse(txtStanjeKilometara.Text),
                    Napomena = txtNapomena.Text,
                    IduciServis = int.Parse(txtIduciServis.Text),
                    Cijena = int.Parse(txtCijena.Text)
                };

                using (PPPK_ProjektEntities context = new PPPK_ProjektEntities())
                {
                    context.Servis.Add(servis);
                    context.SaveChanges();
                }

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
        private static void GetServisByCar(int voziloId)
        {
            using (PPPK_ProjektEntities context = new PPPK_ProjektEntities())
            {
                Servis servis = context.Servis.FirstOrDefault(s => s.Vozilo == voziloId);
                Vozilo vozilo = context.Vozilo.FirstOrDefault(v => v.IDVozilo == servis.Vozilo);

                StringBuilder sb = new StringBuilder();

                sb.Append("<html>");

                sb.Append("<head>");
                sb.Append("<title>");
                sb.Append(vozilo.Naziv);
                sb.Append("</title>");
                sb.Append("</head>");

                sb.Append("<body>");
                sb.Append("<table>");
                sb.Append("<tr><th>Vozilo</th><td>");
                sb.Append(vozilo.Naziv);
                sb.Append("</td></tr>");
                sb.Append("<tr><th>Stanje kilometara</th><td>");
                sb.Append(servis.StanjeKilometara);
                sb.Append("</td></tr>");
                sb.Append("<tr><th>Napomena</th><td>");
                sb.Append(servis.Napomena);
                sb.Append("</td></tr>");
                sb.Append("<tr><th>Iduci servis</th><td>");
                sb.Append(servis.IduciServis);
                sb.Append("</td></tr>");
                sb.Append("<tr><th>Cijena</th><td>");
                sb.Append(servis.Cijena);
                sb.Append("</td></tr>");
                sb.Append("</table>");
                sb.Append("</body>");

                sb.Append("</html>");

                System.IO.File.WriteAllText(@"C:\Users\Marko\Dropbox\Algebra\5. semestar\Pristup podacima iz programskog koda\Projekt\servis.html", sb.ToString());
            }
        }
    }
}