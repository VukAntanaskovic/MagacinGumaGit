using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MagacinGuma.Repository;
using MagacinGuma.Model;

namespace MagacinGuma.Repository
{
    public class RolaRepository
    {
        private readonly ILoader _loader;
        public RolaRepository(ILoader loader)
        {
            _loader = loader;
        }

        public List<Rola> GetRola()
        {
            _loader.ShowLoading();
            List<Rola> tipRola = new List<Rola>();

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Konekcija.conn;
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Rola", con);
                SqlDataReader sdr = cmd.ExecuteReader();

                tipRola.Add(new Rola
                {
                    RolaId = 0,
                    RolazNaziv = "--Select--"
                });

                while (sdr.Read())
                {
                    tipRola.Add(new Rola
                    {
                        RolaId = Convert.ToInt32(sdr["RolaId"]),
                        RolazNaziv = sdr["RolazNaziv"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            _loader.HideLoading();
            return tipRola;
        }

        public bool NewRola(Rola rola)
        {
            _loader.ShowLoading();
            bool isSuccessful = false;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Konekcija.conn;
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Rola VALUES('" + rola.RolazNaziv + "')", con);
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

        public bool UpdateRola(int id, string ime)
        {
            _loader.ShowLoading();
            bool isSuccessful = false;

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Konekcija.conn;
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Rola SET RolaNaziv='" + ime + "' WHERE KorisnikId=" + id, con);
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
