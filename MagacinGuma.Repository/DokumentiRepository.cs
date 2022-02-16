using MagacinGuma.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagacinGuma.Repository
{
    public class DokumentiRepository
    {
        private readonly ILoader _loader;
        public DokumentiRepository(ILoader loader)
        {
            _loader = loader;
        }

        public List<Narudzbenica> GetNarudzbenica()
        {
            List<Narudzbenica> narudzbenice = new List<Narudzbenica>();
            _loader.ShowLoading();

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Konekcija.conn;
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT n.NarudzbenicaId, n.DatumKreiranja, k.KorisnikUsername FROM Narudzbenica n INNER JOIN Korisnik k on k.KorisnikId = n.KreiraoKorisnik WHERE NarudzbenicaOtvorena = 1", con);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    narudzbenice.Add(new Narudzbenica
                    {
                        NarudzbenicaId = Convert.ToInt32(sdr["NarudzbenicaId"]),
                        DatumKreiranja = Convert.ToDateTime(sdr["DatumKreiranja"]),
                        KreiraoKorisnik = new Korisnik
                        {
                            KorisnikUsername = sdr["KorisnikUsername"].ToString()
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                _loader.HideLoading();
                throw ex;
            }

            _loader.HideLoading();
            return narudzbenice;
        }

        public int GetNarudzbenicaId()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Konekcija.conn;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 NarudzbenicaId FROM Narudzbenica ORDER BY 1 DESC", con);
            int brNarudzbe = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            return brNarudzbe;
        }//broj poslednje unete narudzbenice

        public bool NewNarudzbenica(List<Guma> stavke)
        {
            _loader.ShowLoading();
            bool isSuccessful = false;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Konekcija.conn;
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Narudzbenica VALUES(" + Session.UserId + ", '" + DateTime.UtcNow + "', 1)", con);
                cmd.ExecuteNonQuery();
                con.Close();

                int brNarudzbe = GetNarudzbenicaId();

                foreach(var s in stavke)
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("INSERT INTO StavkeNarudzbenice VALUES(" + s.GumaId + ", " + s.GumaKolicina + ", "+ brNarudzbe +")", con);
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }//dodavanje stavki

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

        public bool SetNewQuantity(int brNarudzbe)
        {
            List<Guma> stavke = new List<Guma>();
            bool isSuccessful = false;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Konekcija.conn;
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT GumaId, Kolicina FROM StavkeNarudzbenice WHERE NarudzbenicaId = " + brNarudzbe, con);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    stavke.Add(new Guma
                    {
                        GumaId = Convert.ToInt32(sdr["GumaId"]),
                        GumaKolicina = Convert.ToInt32(sdr["Kolicina"])
                    });
                }
                con.Close();

                foreach(var s in stavke)
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("USP_KnjizenjeRobe", con) { CommandType = System.Data.CommandType.StoredProcedure };
                    cmd1.Parameters.Clear();
                    cmd1.Parameters.Add(new SqlParameter("@GumaId", s.GumaId));
                    cmd1.Parameters.Add(new SqlParameter("@Kolicina", s.GumaKolicina));
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }

                con.Open();
                SqlCommand cmd2 = new SqlCommand("UPDATE Narudzbenica SET NarudzbenicaOtvorena = 0 WHERE NarudzbenicaId = " + brNarudzbe, con); // NarudzbenicaOtvorena (bit)
                cmd2.ExecuteNonQuery();
                con.Close();

                isSuccessful = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isSuccessful;
        }

        public int GetRacunId()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Konekcija.conn;
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 RacunId FROM Racun ORDER BY 1 DESC", con);
            int brNarudzbe = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            return brNarudzbe;
        }

        public bool NewRacun(List<Guma> stavke, int kupac)
        {
            _loader.ShowLoading();
            bool isSuccessful = false;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Konekcija.conn;
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Racun VALUES(" + Session.UserId + ", " + kupac + ")", con);
                cmd.ExecuteNonQuery();
                con.Close();

                int brRacuna = GetRacunId();

                foreach (var s in stavke)
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("INSERT INTO StavkeRacuna VALUES(" + s.GumaId + ", " + s.GumaKolicina + ", " + brRacuna + ")", con);
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }//dodavanje stavki

                foreach (var s in stavke)
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("USP_ProdajaRobe", con) { CommandType = System.Data.CommandType.StoredProcedure };
                    cmd1.Parameters.Clear();
                    cmd1.Parameters.Add(new SqlParameter("@GumaId", s.GumaId));
                    cmd1.Parameters.Add(new SqlParameter("@Kolicina", s.GumaKolicina));
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }

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
