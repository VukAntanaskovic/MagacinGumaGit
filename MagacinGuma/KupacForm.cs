using MagacinGuma.Model;
using MagacinGuma.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagacinGuma
{
    public partial class KupacForm : Form,ILoader
    {
        private readonly frmPocetna _frmPocetna;
        public KupacForm(frmPocetna frmPocetna)
        {
            InitializeComponent();
            _frmPocetna = frmPocetna;
        }

        public void HideLoading()
        {
            progressBarLoad.Value = 100;
            pnlLoading.Visible = false;
            pnlLoading.SendToBack();
        }

        public void ShowLoading()
        {
            pnlLoading.Visible = true;
            pnlLoading.BringToFront();
            progressBarLoad.Value = 30;
        }

        private void btnUnosKupca_Click(object sender, EventArgs e)
        {
            KupacRepository _kupacRepository = new KupacRepository(this);

            if(    !string.IsNullOrEmpty(txtIme.Text)
                && !string.IsNullOrEmpty(txtPrezime.Text)
                && !string.IsNullOrEmpty(txtAdresa.Text))
            {
                Kupac kupac = new Kupac
                {
                    KupacIme = txtIme.Text,
                    KupacPrezime = txtPrezime.Text,
                    KupacAdresa = txtAdresa.Text
                };

                try
                {
                    if (_kupacRepository.NewKupac(kupac))
                    {
                        _frmPocetna.LoadKupac();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Greska prilikom unosa kupca");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Greska prilikom unosa kupca " +ex.Message);
                }
            }
        }
    }
}
