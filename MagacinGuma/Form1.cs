using MagacinGuma.Model;
using MagacinGuma.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagacinGuma
{
    /*                  #TODO               
        - U tabu Stanje u magacinu, kreirati data grid i filtere kao sto su dimenzija, proizvodjac...

        - Napraviti logiku za pregled korisnika, registraciju novih i azuriranje postojecih (tab Korisnici), pratiti istu logiku Guma (tab Gume)
        (Kreirati KorisnikRepository u Repository projektu, tamo cupati podatke iz baze)

        - Kreirati tabele u bazi: 
        Kupac(KupacId identity (1,1) PK, KupacIme, KupacPrezime, KupacAdresa), 
        Racun(RacunId identity(100, 1) PK, KreiraoKorisnik (FK na tabelu Korisnik), Kupac(FK na tabelu Kupac)),
        StavkeRacuna(StavkaId identity(1,1) PK, GumaId(FK na tabelu Guma), Kolicina, RacunId(FK na tabelu Racun))
     */
    public partial class frmPocetna : Form, ILoader
    {
        public frmPocetna()
        {
            InitializeComponent();
            pnlLogin.BringToFront(); //odmah nakon inicijalizacije dovodi login panel napred
        }

        void ShowTabs()
        {
            if (Session.RoleId == 1)
            {
                tabCtr.TabPages.Remove(tabGume);
                tabCtr.TabPages.Remove(tabKnjizenje);
                tabCtr.TabPages.Remove(tabKorisnici);
            }
            else if(Session.RoleId == 2)
            {
                tabCtr.TabPages.Remove(tabProdaja);
                tabCtr.TabPages.Remove(tabPorucivanje);
            }
        }//logika za uklanjanje tabova ako korisnik nema prava na njih


        public void LoadGume()
        {
            GumaRepository _gumaRepository = new GumaRepository(this);
            List<Guma> gume = new List<Guma>();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Proizvodjac");
            dataTable.Columns.Add("Dimenzija");
            dataTable.Columns.Add("Maksimalna Brzina");
            dataTable.Columns.Add("Tip gume");
            dataTable.Columns.Add("Datum kreiranja");
            dataTable.Columns.Add("Kreirao");
            dataTable.Columns.Add("Datum izmene");
            dataTable.Columns.Add("Izmenio");

            try
            {
                gume = _gumaRepository.GetGuma();

                foreach(var g in gume)
                {
                    dataTable.Rows.Add(g.GumaId, g.GumaProizvodjac, g.GumaDimenzija, g.GumaMaxBrzina, g.GumaTip.TipNaziv, g.GumaDatumKreiranja.ToShortDateString(), g.GumaKreiraoKorisnik.KorisnikUsername,g.GumaDatumIzmene, g.IzmenioKorisnik.KorisnikUsername);
                }

                dgvGume.DataSource = dataTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom citanja iz baze " + ex.Message);
            }
        }//ucitavanje guma u data grid


        private void Form1_Load(object sender, EventArgs e)
        {
            List<TipGume> tipoviGuma = new List<TipGume>();
            GumaRepository _gumaRepository = new GumaRepository(this);

            try
            {
                tipoviGuma = _gumaRepository.GetTipGume();
                LoadGume();
            }
            catch
            {
                MessageBox.Show("Greska prilikom citanja iz baze");
            }

            if (tipoviGuma != null)
            {
                cmbTipGume.DataSource = tipoviGuma;
                cmbTipGume.ValueMember = "TipId";
                cmbTipGume.DisplayMember = "TipNaziv";
            }
        }

        public void ShowLoading()
        {
            pnlLoading.Visible = true;
            pnlLoading.BringToFront();
            progressBarLoading.Value = 30;
        }//logika za prikaz loadinga

        public void HideLoading()
        {
            progressBarLoading.Value = 100;
            pnlLoading.Visible = false;
            pnlLoading.SendToBack();
        }// uklanjanje loadinga

        private void btnUnosGume_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGumaProizvodjac.Text) && !string.IsNullOrEmpty(txtGumaDimenzije.Text)
                && numericGumaMaxBrzina.Value > 0) 
            {
                GumaRepository _gumaRepository = new GumaRepository(this);
                Guma guma = new Guma
                {
                    GumaProizvodjac = txtGumaProizvodjac.Text,
                    GumaDimenzija = txtGumaDimenzije.Text,
                    GumaMaxBrzina = Convert.ToDouble(numericGumaMaxBrzina.Value),
                    GumaKolicina = 0,
                    GumaTip = new TipGume { TipId = Convert.ToInt32(cmbTipGume.SelectedValue) },
                    GumaKreiraoKorisnik = new Korisnik { KorisnikId = Session.UserId },
                    GumaDatumKreiranja = DateTime.UtcNow,
                    GumaDatumIzmene = null,
                    IzmenioKorisnik = null
                };

                try
                {
                    if (_gumaRepository.NewGuma(guma))
                    {
                        MessageBox.Show("Uspesno kreirana guma");
                        LoadGume();
                    }
                    else
                    {
                        MessageBox.Show("Greska prilikom kreiranja gume");
                    }
                }
                catch
                {
                    MessageBox.Show("Greska prilikom kreiranja gume");
                }
            }
            else
            {
                MessageBox.Show("Molimo popunite sva polja");
            }
        }

        private void dgvGume_SelectionChanged(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dgvGume.SelectedRows)
            {
                txtAzuriranjeId.Text = row.Cells[0].Value.ToString();
                txtAzuriranjeProizvodjac.Text = row.Cells[1].Value.ToString();
                txtAzuriranjeDimenzije.Text = row.Cells[2].Value.ToString();
                numericAzuriranjeBrzina.Value = Convert.ToDecimal(row.Cells[3].Value);
            }
        }//punjenje text boxova iz selektovanog reda data grida

        private void btnAzuriranjeGume_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtAzuriranjeDimenzije.Text) &&
                !string.IsNullOrEmpty(txtAzuriranjeProizvodjac.Text) &&
                numericAzuriranjeBrzina.Value > 0)
            {
                GumaRepository _gumaRepository = new GumaRepository(this);

                try
                {
                    if(_gumaRepository.UpdateGuma(int.Parse(txtAzuriranjeId.Text), txtAzuriranjeProizvodjac.Text, txtAzuriranjeDimenzije.Text, Convert.ToDouble(numericAzuriranjeBrzina.Value)))
                    {
                        MessageBox.Show("Uspesno ste azurirali gumu " + txtAzuriranjeId.Text);
                        LoadGume();
                    }
                    else
                    {
                        MessageBox.Show("Greska prilikom kreiranja gume");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Greska prilikom kreiranja gume " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Molimo popunite sva polja");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            AuthRepository _authRepository = new AuthRepository(this);

            try
            {

                Korisnik korisnik = _authRepository.AuthUser(txtUsername.Text, txtPassword.Text);

                if (korisnik != null)
                {
                    pnlLogin.Visible = false;
                    Session.SessionStart(korisnik.KorisnikId, korisnik.KorisnikUsername, korisnik.KorisnikIme, korisnik.KorisnikPrezime, korisnik.KorisnikRola);
                    ShowTabs();
                }
                else
                {
                    MessageBox.Show("Pogresni kredencijali");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Greska " + ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            pnlLogin.Visible = true;
            Session.SessionDestroy();
        }
    }
}
