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
        - Na tabu Korisnici treba obezbediti logiku za manipulacijom Korisnicima sistema 
        a ne Kupcima (Kupci ce biti na tabu prodaja kao dodatna funkcija, to cemo na kraju).

        *Instrukcije*
        - Dodati sve text boxove koji su potrebni za unos korisnika u bazu
        - Napraviti logiku za punjenje combo boxa iz baze tabela Rola (primer moze da bude GumaRepository metoda GetTipGume)

        pr. za punjenje comboboxa
        combobox.DataSource = role (List<Rola> koju vadimo iz repository metode);
        cmbTipGume.ValueMember = "RolaId";
        cmbTipGume.DisplayMember = "RolaNaziv";

        *Opis*
        - Napraviti novu klasu Rola(RolaId : int, RolaNaziv : string)
        - Napraviti novu Repository metodu u KorisnikRepository klasi -> GetRole
        - Obezbediti da na FormLoad event bude napunjen combo box na tabu za unos korisnika
        - Izmeniti metode u KorisnikRepository da se bave manipulacijom Korisnika (tabela Korisnik)

        database: magacingumadb

        rollback
     */
    public partial class frmPocetna : Form, ILoader
    {
        public frmPocetna()
        {
            InitializeComponent();
            pnlLogin.BringToFront(); //odmah nakon inicijalizacije dovodi login panel napred
        }

        public int GumaIdStavkaNarudzbenice { get; set; }
        public int KolicinaStavkaNarudzbenice { get; set; }

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

        public void FindGume(int? sifra, string proizvodjac, int? tipGume)
        {
            GumaRepository _gumaRepository = new GumaRepository(this);
            List<Guma> gume = new List<Guma>();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Proizvodjac");
            dataTable.Columns.Add("Dimenzija");
            dataTable.Columns.Add("Maksimalna Brzina");
            dataTable.Columns.Add("Tip gume");
            dataTable.Columns.Add("Kolicina");
            

            try
            {
                gume = _gumaRepository.GetGumaByParameter(sifra,proizvodjac,tipGume);

                if (gume.Count() > 0)
                {

                    foreach (var g in gume)
                    {
                        dataTable.Rows.Add(g.GumaId, g.GumaProizvodjac, g.GumaDimenzija, g.GumaMaxBrzina, g.GumaTip.TipNaziv, g.GumaKolicina);
                    }

                    lblNePostojiUnos.Visible = false;
                    dgvPretragaGume.DataSource = dataTable;
                }
                else
                {
                    lblNePostojiUnos.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska prilikom citanja iz baze " + ex.Message);
            }
        }

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

        public void LoadKorisnik() 
        {
            KorisnikRepository _korisnikRepository = new KorisnikRepository(this);
            List<Korisnik> listaKorisnik = new List<Korisnik>();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID"); 
            dataTable.Columns.Add("Ime");
            dataTable.Columns.Add("Prezime");
            dataTable.Columns.Add("Aktivan");

            try
            {
                listaKorisnik = _korisnikRepository.GetKorisnik();

                foreach (var lk in listaKorisnik)
                {
                    dataTable.Rows.Add(lk.KorisnikId,lk.KorisnikIme,lk.KorisnikPrezime,lk.KorisnikAktivan);
                }

                dataGridViewKorisnik.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska prilikom citanja iz baze " + ex.Message);
            }
        }//ucitavanje korisnika u data grid

        public void LoadNarudzbenice()
        {
            DokumentiRepository _dokumentiRepository = new DokumentiRepository(this);
            List<Narudzbenica> narudzbenice = new List<Narudzbenica>();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Kreirao");
            dataTable.Columns.Add("Datum kreiranja");

            try
            {
                narudzbenice = _dokumentiRepository.GetNarudzbenica();

                foreach (var n in narudzbenice)
                {
                    dataTable.Rows.Add(n.NarudzbenicaId, n.KreiraoKorisnik.KorisnikUsername, n.DatumKreiranja);
                }

                dgvKnjizenjeRobe.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska prilikom citanja iz baze " + ex.Message);
            }
        }

        public void LoadKupac()
        {
            KupacRepository _kupacRepository = new KupacRepository(this);
            List<Kupac> listaKupaca = new List<Kupac>();

            try
            {
                listaKupaca = _kupacRepository.GetKupac();
            }
            catch
            {
                MessageBox.Show("Greska prilikom citanja iz baze");
            }

            if (listaKupaca != null)
            {
                cmbKupac.DataSource = listaKupaca;
                cmbKupac.ValueMember = "KupacId";
                cmbKupac.DisplayMember = "IspisKupca";
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            List<TipGume> tipoviGuma = new List<TipGume>();
            GumaRepository _gumaRepository = new GumaRepository(this);
            List<Rola> role = new List<Rola>();
            KorisnikRepository _korisnikRepository = new KorisnikRepository(this);
            RolaRepository _rolaRepository = new RolaRepository(this);
            

            try
            {
                tipoviGuma = _gumaRepository.GetTipGume();
                LoadGume();
                role = _rolaRepository.GetRola();
                LoadKorisnik();
                LoadNarudzbenice();
                LoadKupac();
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

                cmbPretragaTipGume.DataSource = tipoviGuma;
                cmbPretragaTipGume.ValueMember = "TipId";
                cmbPretragaTipGume.DisplayMember = "TipNaziv";
            }

            if (role != null)
            {
                cmbKorisnikRola.DataSource = role;
                cmbKorisnikRola.ValueMember = "RolaId";
                cmbKorisnikRola.DisplayMember = "RolazNaziv";
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
                && numericGumaMaxBrzina.Value > 0 && Convert.ToInt32(cmbTipGume.SelectedValue) > 0) 
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
                        MessageBox.Show("Greska prilikom azuriranja gume");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Greska prilikom azuriranja gume " + ex.Message);
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
            Application.Restart();
        }

        private void btnPretraga_Click(object sender, EventArgs e)
        {
            int sifra = 0;

            int.TryParse(txtPretragaIDGume.Text, out sifra);

            try
            {
                FindGume(sifra ,txtPretragaProizvodjac.Text,Convert.ToInt32(cmbPretragaTipGume.SelectedValue));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUnesiNovogKorisnika_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbUnesiKorisnikIme.Text) && !string.IsNullOrEmpty(tbUnesiKorisnikPrezime.Text)
                && !string.IsNullOrEmpty(tbUnesiKorisnikUsername.Text) && !string.IsNullOrEmpty(tbUnesiKorisnikPassword.Text)
                && Convert.ToInt32(cmbKorisnikRola.SelectedValue)>0)
            {
                KorisnikRepository _korisnikRepository = new KorisnikRepository(this);

                Korisnik korisnik = new Korisnik
                {
                    KorisnikIme = tbUnesiKorisnikIme.Text,
                    KorisnikPrezime = tbUnesiKorisnikPrezime.Text,
                    KorisnikUsername =tbUnesiKorisnikUsername.Text,
                    KorisnikPassword = tbUnesiKorisnikPassword.Text,
                    KorisnikRola = Convert.ToInt32(cmbKorisnikRola.SelectedValue)
                };
                
                try
                {
                    if (_korisnikRepository.NewKorisnik(korisnik))
                    {
                        MessageBox.Show("Uspesno kreiran korisnik");
                        LoadKorisnik();
                    }
                    else
                    {
                        MessageBox.Show("Greska prilikom kreiranja korisnika");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Greska prilikom kreiranja korisnika "+ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Molimo popunite sva polja");
            }
        }//unos novog korisnika

        private void btnAzurirajKorisnik_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(tbAzurirajKorisnikIme.Text) &&
                !string.IsNullOrEmpty(tbAzurirajKorisnikPrezime.Text) &&
                cbAzurirajKorisnikAktivan!=null)
            {
                KorisnikRepository _korisnikRepository = new KorisnikRepository(this);

                try
                {
                    if (_korisnikRepository.UpdateKorisnik(int.Parse(tbAzurirajKorisnikId.Text),tbAzurirajKorisnikIme.Text,tbAzurirajKorisnikPrezime.Text,Boolean.Parse(cbAzurirajKorisnikAktivan.Checked.ToString())))
                    {
                        MessageBox.Show("Uspesno ste azurirali korisnika " + tbAzurirajKorisnikId.Text);
                        LoadKorisnik();
                    }
                    else
                    {
                        MessageBox.Show("Greska prilikom azuriranja v");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greska prilikom azuriranja korisnika " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Molimo popunite sva polja");
            }
        }

        private void dataGridViewKorisnik_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewKorisnik.SelectedRows)
            {
                tbAzurirajKorisnikId.Text = row.Cells[0].Value.ToString();
                tbAzurirajKorisnikIme.Text = row.Cells[1].Value.ToString();
                tbAzurirajKorisnikPrezime.Text = row.Cells[2].Value.ToString();

                cbAzurirajKorisnikAktivan.Checked=Convert.ToBoolean(row.Cells[3].Value.ToString());
            }
        }

        private void txtTraziArtikalNarudzba_KeyDown(object sender, KeyEventArgs e)
        {
            GumaRepository _gumaRepository = new GumaRepository(this);

            if(e.KeyCode == Keys.Enter) // da li je kliknut enter
            {
                try
                {
                    Guma guma = _gumaRepository.GetGumaById(int.Parse(txtTraziArtikalNarudzba.Text));

                    if(guma != null)
                    {
                        txtNadjeniArtikal.Text = guma.GumaId + " - " + guma.GumaProizvodjac + " - " + guma.GumaDimenzija;
                        GumaIdStavkaNarudzbenice = guma.GumaId;
                    }
                    else
                    {
                        MessageBox.Show("Trazena guma ne postoji");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Trazena guma ne postoji");
                }

            }
        }

        private void txtTraziArtikalNarudzba_Leave(object sender, EventArgs e)
        {
            GumaRepository _gumaRepository = new GumaRepository(this);

            if (string.IsNullOrEmpty(txtNadjeniArtikal.Text))
            {

                try
                {
                    Guma guma = _gumaRepository.GetGumaById(int.Parse(txtTraziArtikalNarudzba.Text));

                    if (guma != null)
                    {
                        txtNadjeniArtikal.Text = guma.GumaId + " - " + guma.GumaProizvodjac + " - " + guma.GumaDimenzija;
                        GumaIdStavkaNarudzbenice = guma.GumaId;
                    }
                    else
                    {
                        MessageBox.Show("Trazena guma ne postoji");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Trazena guma ne postoji");
                }
            }
        }

        List<Guma> stavke = new List<Guma>();
        private void btnDodajStavku_Click(object sender, EventArgs e)
        {
            GumaRepository _gumaRepository = new GumaRepository(this);

            if(numericKolicinaNarudzbina.Value > 0)
            {
                try
                {
                    KolicinaStavkaNarudzbenice = Convert.ToInt32(numericKolicinaNarudzbina.Value);
                    Guma guma = _gumaRepository.GetGumaById(GumaIdStavkaNarudzbenice);
                    guma.GumaKolicina = KolicinaStavkaNarudzbenice;
                    stavke.Add(guma);

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Id");
                    dataTable.Columns.Add("Proizvodjac");
                    dataTable.Columns.Add("Dimenzija");
                    dataTable.Columns.Add("Maksimalna Brzina");
                    dataTable.Columns.Add("Kolicina");

                    foreach(var g in stavke)
                    {
                        dataTable.Rows.Add(g.GumaId, g.GumaProizvodjac, g.GumaDimenzija, g.GumaMaxBrzina, g.GumaKolicina);
                    }

                    dgvNarudzbenicaStavke.DataSource = dataTable;
                    numericKolicinaNarudzbina.Value = 0;
                    txtTraziArtikalNarudzba.Text = string.Empty;
                    txtNadjeniArtikal.Text = string.Empty;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Kolicina mora biti veca od 0");
            }
        }

        private void btnPotvrditeNarudzbenicu_Click(object sender, EventArgs e)
        {
            DokumentiRepository _dokumentiRepository = new DokumentiRepository(this);

            try
            {
                if(stavke.Count() > 0)
                {
                    if (_dokumentiRepository.NewNarudzbenica(stavke)) // proverava isSuccessful
                    {
                        MessageBox.Show("Uspesno ste kreirali porudzbiu robe");
                        stavke = null;
                        numericKolicinaNarudzbina.Value = 0;
                        txtTraziArtikalNarudzba.Text = string.Empty;
                        txtNadjeniArtikal.Text = string.Empty;
                        dgvNarudzbenicaStavke.DataSource = null;
                    }
                    else
                    {
                        MessageBox.Show("Greska prilikom kreiranja narudzbenice");
                    }
                }
                else
                {
                    MessageBox.Show("Dokument ne sadrzi stavke");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
            }
        }

        int brNaruzbe;
        private void btnKnjizenje_Click(object sender, EventArgs e)
        {
            DokumentiRepository _dokumentiRepository = new DokumentiRepository(this);

            try
            {

                foreach (DataGridViewRow row in dgvKnjizenjeRobe.SelectedRows)
                {
                    brNaruzbe = Convert.ToInt32(row.Cells[0].Value);            
                }

                if (_dokumentiRepository.SetNewQuantity(brNaruzbe))
                {
                    LoadNarudzbenice();
                    MessageBox.Show("Uspesno ste uknjizili robu");
                }
                else
                {
                    MessageBox.Show("Greska prilikom knjizenja robe");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Greska prilikom knjizenja robe: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stavke = null;
            numericKolicinaNarudzbina.Value = 0;
            txtTraziArtikalNarudzba.Text = string.Empty;
            txtNadjeniArtikal.Text = string.Empty;
            dgvNarudzbenicaStavke.DataSource = null;
        }

        private void btnDodajKupca_Click(object sender, EventArgs e)
        {
            KupacForm kupacForm = new KupacForm(this);
            kupacForm.ShowDialog();
            kupacForm.Dispose();
        }

        private void txtArtikalRacun_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                GumaRepository _gumaRepository = new GumaRepository(this);

                try
                {
                    Guma guma = _gumaRepository.GetGumaById(int.Parse(txtArtikalRacun.Text));

                    if (guma != null)
                    {
                        txtArtikalNadjenRacun.Text = guma.GumaId + " - " + guma.GumaProizvodjac + " - " + guma.GumaDimenzija;
                        GumaIdStavkaRacuna = guma.GumaId;
                    }
                    else
                    {
                        MessageBox.Show("Trazena guma ne postoji");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Trazena guma ne postoji");
                }
            }
        }

        public int GumaIdStavkaRacuna { get; set; }
        public int KolicinaStavkeRacun { get; set; }
        private void txtArtikalRacun_Leave(object sender, EventArgs e)
        {
            GumaRepository _gumaRepository = new GumaRepository(this);

            if (string.IsNullOrEmpty(txtArtikalNadjenRacun.Text))
            {

                try
                {
                    Guma guma = _gumaRepository.GetGumaById(int.Parse(txtArtikalRacun.Text));

                    if (guma != null)
                    {
                        txtArtikalNadjenRacun.Text = guma.GumaId + " - " + guma.GumaProizvodjac + " - " + guma.GumaDimenzija;
                        GumaIdStavkaRacuna = guma.GumaId;
                    }
                    else
                    {
                        MessageBox.Show("Trazena guma ne postoji");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Trazena guma ne postoji");
                }
            }
        }
        List<Guma> stavkeRacuna = new List<Guma>();
        private void btnDodajArtikalRacun_Click(object sender, EventArgs e)
        {
            GumaRepository _gumaRepository = new GumaRepository(this);

            try
            {
                var duplikat = from n in stavkeRacuna
                               where n.GumaId == Convert.ToInt32(GumaIdStavkaRacuna)
                               select n;
                if (duplikat.Count() == 0)
                {
                    if (_gumaRepository.CheckQuantity(GumaIdStavkaRacuna, Convert.ToInt32(numericKolicinaRacun.Value)))
                    {
                        if (numericKolicinaRacun.Value > 0)
                        {

                            KolicinaStavkeRacun = Convert.ToInt32(numericKolicinaRacun.Value);
                            Guma guma = _gumaRepository.GetGumaById(GumaIdStavkaRacuna);
                            guma.GumaKolicina = KolicinaStavkeRacun;
                            stavkeRacuna.Add(guma);

                            DataTable dataTable = new DataTable();
                            dataTable.Columns.Add("Id");
                            dataTable.Columns.Add("Proizvodjac");
                            dataTable.Columns.Add("Dimenzija");
                            dataTable.Columns.Add("Maksimalna Brzina");
                            dataTable.Columns.Add("Kolicina");

                            foreach (var g in stavkeRacuna)
                            {
                                dataTable.Rows.Add(g.GumaId, g.GumaProizvodjac, g.GumaDimenzija, g.GumaMaxBrzina, g.GumaKolicina);
                            }

                            dgvRacunStavke.DataSource = dataTable;
                            numericKolicinaRacun.Value = 0;
                            txtArtikalRacun.Text = string.Empty;
                            txtArtikalNadjenRacun.Text = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Kolicina mora biti veca od 0");
                            numericKolicinaRacun.Value = 0;
                            txtArtikalRacun.Text = string.Empty;
                            txtArtikalNadjenRacun.Text = string.Empty;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Artikal " + GumaIdStavkaRacuna + " nema trazenu kolicinu u bazi");
                        numericKolicinaRacun.Value = 0;
                        txtArtikalRacun.Text = string.Empty;
                        txtArtikalNadjenRacun.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("Ne mozete uneti isti artikal vise puta");
                }
            }

            catch (Exception ex)
            {

            }
        }

        private void btnKreirajRacun_Click(object sender, EventArgs e)
        {
            DokumentiRepository _dokumentiRepository = new DokumentiRepository(this);

            try
            {
                if (stavkeRacuna.Count() > 0)
                {
                    if (_dokumentiRepository.NewRacun(stavkeRacuna, Convert.ToInt32(cmbKupac.SelectedValue))) // proverava isSuccessful
                    {
                        MessageBox.Show("Uspesno ste kreirali racun");
                        stavkeRacuna = null;
                        numericKolicinaRacun.Value = 0;
                        txtArtikalRacun.Text = string.Empty;
                        txtNadjeniArtikal.Text = string.Empty;
                        dgvRacunStavke.DataSource = null;
                        cmbKupac.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("Greska prilikom kreiranja racuna");
                    }
                }
                else
                {
                    MessageBox.Show("Dokument ne sadrzi stavke");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska: " + ex.Message);
            }
        }

        private void brnObrisiRacun_Click(object sender, EventArgs e)
        {
            stavkeRacuna = null;
            numericKolicinaRacun.Value = 0;
            txtArtikalRacun.Text = string.Empty;
            txtNadjeniArtikal.Text = string.Empty;
            dgvRacunStavke.DataSource = null;
            cmbKupac.SelectedIndex = 0;
        }
    }
}
