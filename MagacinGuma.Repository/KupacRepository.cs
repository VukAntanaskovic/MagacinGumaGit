using MagacinGuma.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagacinGuma.Repository
{
    public class KupacRepository
    {
        private readonly ILoader _loader;

        public KupacRepository(ILoader loader)
        {
            _loader = loader;
        }

        public List<Kupac> GetKupac()
        {
            _loader.ShowLoading();
            List<Kupac> kupac = new List<Kupac>();

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Konekcija.conn;
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Kupac ORDER BY 2 ASC", con);
                SqlDataReader sdr = cmd.ExecuteReader();

                kupac.Add(new Kupac
                {
                    KupacId = 0,
                    KupacIme = "--Select--",
                    KupacAdresa = "",
                    KupacPrezime = ""
                });

                while (sdr.Read())
                {
                    kupac.Add(new Kupac
                    {
                        KupacId = Convert.ToInt32(sdr["KupacId"]),
                        KupacIme = sdr["KupacIme"].ToString(),
                        KupacPrezime = sdr["KupacPrezime"].ToString(),
                        KupacAdresa = sdr["KupacAdresa"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            _loader.HideLoading();
            return kupac;
        }

        public bool NewKupac(Kupac kupac)
        {
            _loader.ShowLoading();
            bool isSuccessful = false;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Konekcija.conn;
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Kupac VALUES ('"+kupac.KupacIme+"', '"+kupac.KupacPrezime+"', '"+kupac.KupacAdresa+"')", con);
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
