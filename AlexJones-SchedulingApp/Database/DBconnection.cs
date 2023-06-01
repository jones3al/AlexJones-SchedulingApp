using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlexJones_SchedulingApp.Database
{
    public static class DBconnection
    {
        public static MySqlConnection Connection{ get; set; }

        public static void StartConnection()
        {

            try
            {
                //get connection string
                string dbstring = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
                Connection = new MySqlConnection(dbstring);

                //open connection
                Connection.Open();

                MessageBox.Show("You are connected to Database");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void CloseConnection()
        {
            try
            {
                //close connection
                if (Connection != null)
                {
                    Connection.Close();
                }
                Connection = null;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        

        }
    }
}
