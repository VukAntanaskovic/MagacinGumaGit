using MagacinGuma.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagacinGuma.Repository
{
    public class GumaRepository
    {
        private readonly ILoader _loader;
        public GumaRepository(ILoader loader)
        {
            _loader = loader;
        }

        public List<TipGume> GetTipGume()
        {
            _loader.ShowLoading();
            List<TipGume> tipoviGume = new List<TipGume>();

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Konekcija.conn;
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM TipGume ORDER BY 2 ASC", con);
                SqlDataReader sdr = cmd.ExecuteReader();

                tipoviGume.Add(new TipGume
                {
                    TipId = 0,
                    TipNaziv = "--Select--",
                    TipOpis = "--Select--"
                });

                while (sdr.Read())
                {
                    tipoviGume.Add(new TipGume
                    {
                        TipId = Convert.ToInt32(sdr["TipId"]),
                        TipNaziv = sdr["TipNaziv"].ToString(),
                        TipOpis = sdr["TipOpis"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            _loader.HideLoading();
            return tipoviGume;
        }

        public bool NewGuma(Guma guma)
        {
            _loader.ShowLoading();
            bool isSuccessful = false;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Konekcija.conn;
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Guma VALUES('"+guma.GumaProizvodjac+"', '"+guma.GumaDimenzija+"', "+guma.GumaMaxBrzina+", "+guma.GumaTip.TipId+", "+guma.GumaKolicina+", '"+guma.GumaDatumKreiranja+"', "+guma.GumaKreiraoKorisnik.KorisnikId+", NULL, NULL)", con);
                cmd.ExecuteNonQuery();
                isSuccessful = true;
            }
            catch(Exception ex)
            {
                _loader.HideLoading();
                throw ex;
            }

            _loader.HideLoading();
            return isSuccessful;
        }

        public List<Guma> GetGuma()
        {
            _loader.ShowLoading();
            List<Guma> gume = new List<Guma>();

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Konekcija.conn;
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT *, ik.korisnikusername as izmenio FROM Guma g INNER JOIN Korisnik k ON k.KorisnikId = g.GumaKreiraoKorisnik LEFT JOIN Korisnik ik ON ik.KorisnikId = g.GumaIzmenioKorisnik INNER JOIN TipGume t ON t.TipId = g.GumaTip ORDER BY 1 DESC", con);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    gume.Add(new Guma
                    {
                        GumaId = Convert.ToInt32(sdr["GumaId"]),
                        GumaProizvodjac = sdr["GumaProizvodjac"].ToString(),
                        GumaDimenzija = sdr["GumaDimenzija"].ToString(),
                        GumaMaxBrzina = Convert.ToDouble(sdr["GumaMaxBrzina"]),
                        GumaTip = new TipGume
                        {
                            TipId = Convert.ToInt32(sdr["TipId"]),
                            TipNaziv = sdr["TipNaziv"].ToString(),
                            TipOpis = sdr["TipOpis"].ToString()
                        },
                        GumaDatumKreiranja = Convert.ToDateTime(sdr["GumaDatumKreiranja"]),
                        GumaKreiraoKorisnik = new Korisnik
                        {
                            KorisnikUsername = sdr["KorisnikUsername"].ToString()
                        },
                        GumaDatumIzmene = sdr["GumaDatumIzmene"].ToString(),
                        IzmenioKorisnik = new Korisnik
                        {
                            KorisnikUsername = sdr["izmenio"].ToString()
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            _loader.HideLoading();
            return gume;
        }

        public bool UpdateGuma(int sifra, string proizvodjac, string dimenizje, double maxBrzina)
        {
            _loader.ShowLoading();
            bool isSuccessful = false;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Konekcija.conn;
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Guma SET GumaProizvodjac='" +proizvodjac+ "', GumaDimenzija='" +dimenizje+"', GumaMaxBrzina=" +maxBrzina+", GumaDatumIzmene=GETUTCDATE(), GumaIzmenioKorisnik= "+Session.UserId+" WHERE GumaId=" + sifra, con);
                cmd.ExecuteNonQuery();
                isSuccessful = true;
            }
            catch (Exception ex)
            {
                _loader.HideLoading();
                throw ex;
            }

            _loader.HideLoading();
            return isSuccessful;
        }

        public List<Guma> GetGumaByParameter(int? sifra, string proizvodjac, int? tipGume)
        {
            _loader.ShowLoading();
            List<Guma> gume = new List<Guma>();
            string filter = "WHERE 1=1";

            if(sifra != null && sifra > 0)
            {
                filter += " AND GumaId=" + sifra;
            }

            if (!string.IsNullOrEmpty(proizvodjac))
            {
                filter += " AND GumaProizvodjac='" + proizvodjac + "'";
            }

            if(tipGume > 0 && tipGume != null)
            {
                filter += " AND GumaTip=" + tipGume;
            }

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Konekcija.conn;
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Guma g inner join TipGume tg on g.GumaTip=tg.TipId "+filter, con);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    gume.Add(new Guma
                    {
                        GumaId = Convert.ToInt32(sdr["GumaId"]),
                        GumaProizvodjac = sdr["GumaProizvodjac"].ToString(),
                        GumaDimenzija = sdr["GumaDimenzija"].ToString(),
                        GumaMaxBrzina = Convert.ToDouble(sdr["GumaMaxBrzina"]),
                        GumaKolicina = Convert.ToInt32(sdr["GumaKolicina"]),
                        GumaTip = new TipGume
                        {
                            TipId = Convert.ToInt32(sdr["TipId"]),
                            TipNaziv = sdr["TipNaziv"].ToString(),
                            TipOpis = sdr["TipOpis"].ToString()
                        },
                        GumaDatumKreiranja = Convert.ToDateTime(sdr["GumaDatumKreiranja"]),
                        GumaDatumIzmene = sdr["GumaDatumIzmene"].ToString()

                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            _loader.HideLoading();
            return gume;
        }

        public Guma GetGumaById(int? sifra)
        {
            Guma guma = null;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Konekcija.conn;
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Guma g inner join TipGume tg on g.GumaTip=tg.TipId WHERE GumaId=" + sifra, con);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    guma = new Guma
                    {
                        GumaId = Convert.ToInt32(sdr["GumaId"]),
                        GumaProizvodjac = sdr["GumaProizvodjac"].ToString(),
                        GumaDimenzija = sdr["GumaDimenzija"].ToString(),
                        GumaMaxBrzina = Convert.ToDouble(sdr["GumaMaxBrzina"]),
                        GumaKolicina = Convert.ToInt32(sdr["GumaKolicina"]),
                        GumaTip = new TipGume
                        {
                            TipId = Convert.ToInt32(sdr["TipId"]),
                            TipNaziv = sdr["TipNaziv"].ToString(),
                            TipOpis = sdr["TipOpis"].ToString()
                        },
                        GumaDatumKreiranja = Convert.ToDateTime(sdr["GumaDatumKreiranja"]),
                        GumaDatumIzmene = sdr["GumaDatumIzmene"].ToString()

                    };
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return guma;
        }
    }
}
