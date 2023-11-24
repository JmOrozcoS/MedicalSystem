using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Cache
{
    public static class UserLoginCache
    {
        private static int idUser;
        private static string user;
        private static string firstName;
        private static string sname;
        private static string lastName;
        private static string ssurname;
        private static string position;
        private static string email;
        private static string estado;
        private static string pass;


        public static int IdUser { get => idUser; set => idUser = value; }
        public static string FirstName { get => firstName; set => firstName = value; }
        public static string LastName { get => lastName; set => lastName = value; }
        public static string Position { get => position; set => position = value; }
        public static string Email { get => email; set => email = value; }
        public static string User { get => user; set => user = value; }
        public static string Estado { get => estado; set => estado = value; }
        public static string Pass { get => pass; set => pass = value; }
        public static string Sname { get => sname; set => sname = value; }
        public static string Ssurname { get => ssurname; set => ssurname = value; }
    }
}
