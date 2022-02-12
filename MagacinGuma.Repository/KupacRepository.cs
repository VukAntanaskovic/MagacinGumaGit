using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagacinGuma.Model;
using System.Data.SqlClient;


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
            List<Kupac> listaKupac = new List<Kupac>();

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Konekcija.conn;
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Kupac", con);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    listaKupac.Add(new Kupac
                    {
                        KupacId = Convert.ToInt32(sdr["KupacId"]),
                        KupacIme = sdr["KupacIme"].ToString(),
                        KupacPrezime = sdr["KupacPrezime"].ToString(),
                        KupacAdresa=sdr["KupacAdresa"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            _loader.HideLoading();
            return listaKupac;
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
                SqlCommand cmd = new SqlCommand("INSERT INTO Kupac VALUES('" + kupac.KupacIme + "', '" + kupac.KupacPrezime + "', '" +kupac.KupacAdresa+ "')", con);
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

        public bool UpdateKupac(int id, string ime, string prezime, string adresa)
        {
            _loader.ShowLoading();
            bool isSuccessful = false;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Konekcija.conn;
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Kupac SET KupacIme='" + ime + "', KupacPrezime='" + prezime + "', KupacAdresa='" + adresa  + "' WHERE KupacId=" + id, con);
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
