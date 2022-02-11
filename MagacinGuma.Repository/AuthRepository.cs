using MagacinGuma.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagacinGuma.Repository
{
    public class AuthRepository
    {
        private readonly ILoader _loader;
        public AuthRepository(ILoader loader)
        {
            _loader = loader;
        }

        public Korisnik AuthUser(string username, string password)
        {
            _loader.ShowLoading();
            Korisnik korisnik = null;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Konekcija.conn;
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT KorisnikId, KorisnikUsername, KorisnikIme, KorisnikPrezime, KorisnikRola FROM [dbo].[Korisnik] WHERE KorisnikUsername = '"+username+"' and KorisnikPassword = '"+password+"' and KorisnikAktivan = 1", con);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    korisnik = new Korisnik
                    {
                        KorisnikId = Convert.ToInt32(sdr["KorisnikId"]),
                        KorisnikUsername = sdr["KorisnikUsername"].ToString(),
                        KorisnikIme = sdr["KorisnikIme"].ToString(),
                        KorisnikPrezime = sdr["KorisnikPrezime"].ToString(),
                        KorisnikRola = Convert.ToInt32(sdr["KorisnikRola"])
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            _loader.HideLoading();
            return korisnik;
        }//pretraga korisnika iz baze
    }
}
