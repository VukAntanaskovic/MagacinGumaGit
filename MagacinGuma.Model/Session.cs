using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagacinGuma.Model
{
    public class Session
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static string Name { get; set; }
        public static string SecondName { get; set; }

        public static int RoleId { get; set; }

        public static void SessionStart(int userid, string username, string name, string secondname, int roleid)
        {
            Session.UserId = userid;
            Session.Username = username;
            Session.Name = name;
            Session.SecondName = secondname;
            Session.RoleId = roleid;
        }//startovanje sesije za ulogovanog korisnika

        public static void SessionDestroy()
        {
            Session.UserId = 0;
            Session.Username = "";
            Session.Name = "";
            Session.SecondName = "";
            Session.RoleId = 0;
        }//prekidanje sesije
    }
}
