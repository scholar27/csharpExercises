using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Asn1.X500;

namespace Kundenverwaltung
{
    public partial class Form1 : Form
    {
        static string server = "localhost";
        static string database = "schmid_kunden";
        static string user = "root";
        static string password = "";
        static string port = "3306";

        static string connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4};", server, port, user, password, database);
        static MySqlConnection connection = new MySqlConnection(connectionString);

        public Form1()
        {
            InitializeComponent();
        }

        private void such_button_Click(object sender, EventArgs e)
        {
            try
            {

                string tableString = "";

                string searchRequest = suchfeld.Text;

                string allCol = "SELECT TABLE_NAME, COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='schmid_kunden'";
            

                using (connection)
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(allCol, connection);
                    cmd.CommandType = CommandType.Text;
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            tableString += rdr["TABLE_NAME"] + "." + rdr["COLUMN_NAME"] + ", ";
                        }

                        tableString = tableString.Substring(0, tableString.Length - 2);

                    }
                }

                string selectCmd = $"Select distinct * from kunde natural join ansprechpartner natural join ort where '{searchRequest}' in ({tableString})";

                using (connection)
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(selectCmd, connection);
                    cmd.CommandType = CommandType.Text;

                    Form2 f2 = new Form2(cmd, connection);

                    f2.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"oops - {ex.Message}");
            }
            finally
            {
                connection.Dispose();
            }

        }

        private void button_change_Click(object sender, EventArgs e)
        {
            string userCommand = "change";
            Form3 f3 = new Form3(connection, userCommand);
            f3.Show();
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            string userCommand = "delete";
            Form3 f3 = new Form3(connection, userCommand);
            f3.Show();
        }
    }
}
