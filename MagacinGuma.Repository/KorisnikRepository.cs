using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagacinGuma.Model;
using System.Data.SqlClient;


namespace MagacinGuma.Repository
{
    public class KorisnikRepository
    {
        private readonly ILoader _loader;

        public KorisnikRepository(ILoader loader)
        {
            _loader = loader;
        }

        public List<Korisnik> GetKorisnik()
        {
            _loader.ShowLoading();
            List<Korisnik> listaKorisnik = new List<Korisnik>();

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Konekcija.conn;
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Korisnik", con);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    listaKorisnik.Add(new Korisnik
                    {
                        KorisnikId = Convert.ToInt32(sdr["KorisnikId"]),
                        KorisnikIme = sdr["KorisnikIme"].ToString(),
                        KorisnikPrezime = sdr["KorisnikPrezime"].ToString(),
                        KorisnikUsername = sdr["KorisnikUsername"].ToString(),
                        KorisnikPassword = sdr["KorisnikPassword"].ToString(),
                        KorisnikRola = Convert.ToInt32(sdr["KorisnikRola"]),
                        KorisnikAktivan=Convert.ToBoolean(sdr["KorisnikAktivan"])
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            _loader.HideLoading();
            return listaKorisnik;
        }

        public bool NewKorisnik(Korisnik korisnik)
        {
            _loader.ShowLoading();
            bool isSuccessful = false;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Konekcija.conn;
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Korisnik VALUES('" + korisnik.KorisnikIme + "', '" + korisnik.KorisnikPrezime + "', '"
                                                +korisnik.KorisnikUsername+ "', '" + korisnik.KorisnikPassword+"',"+korisnik.KorisnikRola+",'"
                                                +korisnik.KorisnikAktivan+"')", con);
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

        public bool UpdateKorisnik(int id, string ime, string prezime, bool aktivan)
        {
            _loader.ShowLoading();
            bool isSuccessful = false;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Konekcija.conn;
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Korisnik SET KorisnikIme='" + ime + "', KorisnikPrezime='" + prezime + "', KorisnikAktivan='" + aktivan  + "' WHERE KorisnikId=" + id, con);
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
    }
}
