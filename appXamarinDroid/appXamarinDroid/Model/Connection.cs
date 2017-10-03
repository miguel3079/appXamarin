using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MySql.Data.MySqlClient;

namespace appXamarinDroid.Model
{
    public class Connection
    {
        private string GetAccountCountFromMySQL()
        {
            try
            {
                MySqlConnection sqlconn;
                string connsqlstring = "Server=your.ip.address;Port=3306;database=YOUR_DATA_BASE;User Id=root;Password=password;charset=utf8";
                sqlconn = new MySqlConnection(connsqlstring);
                sqlconn.Open();
                string queryString = "select count(0) from ACCOUNT";
                MySqlCommand sqlcmd = new MySqlCommand(queryString, sqlconn);
                String result = sqlcmd.ExecuteScalar().ToString();
                return "conectado";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public bool Login(string user, string pass)
        {
            return true;
        }
    }
}