using System;
using MySql.Data.MySqlClient;
using appXamarinDroid.Model.DTOs;

namespace appXamarinDroid.Model
{
    public class Connection
    {
        MySqlConnection sqlconn;
        Validations.Validations validations;

        public Connection()
        {
            validations = new Validations.Validations();
        }

        private void ConnectionBD()
        {
            try
            {
                string connsqlstring = "Server=mysql8.db4free.net;Port=3307;database=miguelxamarinapp;User Id=adminmiguel123;Password=admin1234@;charset=utf8";
                sqlconn = new MySqlConnection(connsqlstring);
                sqlconn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Login(string user, string pass)
        {
            ConnectionBD();
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass)) return false;

            string queryString = "SELECT * FROM Users where name = '" + user + "' and pass = '" + pass + "' and active = 1";
            MySqlCommand sqlcmd = new MySqlCommand(queryString, sqlconn);
            var result = Convert.IsDBNull(sqlcmd.ExecuteScalar()) ? default(string) : sqlcmd.ExecuteScalar().ToString();
            if (!string.IsNullOrWhiteSpace(result))
            {
                sqlconn.Close();
                return true;
            }
            else
            {
                sqlconn.Close();
                return false;
            }
        }

        public UserDto UserPerfil(string userName)
        {
            ConnectionBD();
            UserDto userDto;

            string queryString = "SELECT * FROM Users where name = '" + userName + "' and active = 1";
            MySqlCommand sqlcmd = new MySqlCommand(queryString, sqlconn);
            var result = sqlcmd.ExecuteReader();
            result.Read();
            userDto = new UserDto()
            {
                Name = result.GetString("name"),
                Surname = result.GetString("surname"),
                Pass = result.GetString("pass"),
                Email = result.GetString("email"),
                Active = result.GetBoolean("active")
            };

            return userDto;
        }
    }
}