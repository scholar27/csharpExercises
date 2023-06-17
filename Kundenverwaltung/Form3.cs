using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kundenverwaltung
{
    public partial class Form3 : Form
    {
        private string userCommand;
        private MySqlConnection connection;

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(MySqlConnection _connection, string _userCommand)
        {
            InitializeComponent();
            setUserCommand(_userCommand);
            setConnection(_connection);
        }

        public void setUserCommand(string _userCommand)
        {
            userCommand = _userCommand;
        }

        public void setConnection(MySqlConnection _connection)
        {
            connection = _connection;
        }

        private void button_tabelle_ansprechpartner_Click(object sender, EventArgs e)
        {
            string tableString = "";
            string searchRequest = user_command_message.Text;

            using (connection)
            {
                connection.Open();
                string columns = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='ansprechpartner'";
                MySqlCommand cmd = new MySqlCommand(columns, connection);
                cmd.CommandType = CommandType.Text;
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        tableString += rdr["COLUMN_NAME"] + ", ";
                    }

                    tableString = tableString.Substring(0, tableString.Length - 2);
                }
            }

            string select = "Select * from ansprechpartner";
            if (searchRequest != "")
            {
                select += $" where '{searchRequest}' in ({tableString})";
            }
            Form4 f4 = new Form4(select, "ansprechpartner", connection, userCommand);
            f4.Show();
        }

        private void button_tabelle_kunde_Click(object sender, EventArgs e)
        {
            string tableString = "";
            string searchRequest = user_command_message.Text;

            using (connection)
            {
                connection.Open();
                string columns = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='kunde'";
                MySqlCommand cmd = new MySqlCommand(columns, connection);
                cmd.CommandType = CommandType.Text;
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        tableString += rdr["COLUMN_NAME"] + ", ";
                    }

                    tableString = tableString.Substring(0, tableString.Length - 2);
                }
            }

            string select = "Select * from kunde";
            if (searchRequest != "")
            {
                select += $" where '{searchRequest}' in ({tableString})";
            }
            Form4 f4 = new Form4(select, "kunde", connection, userCommand);
            f4.Show();
        }

        private void button_tabelle_ort_Click(object sender, EventArgs e)
        {
            string tableString = "";
            string searchRequest = user_command_message.Text;

            using (connection)
            {
                connection.Open();
                string columns = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='ort'";
                MySqlCommand cmd = new MySqlCommand(columns, connection);
                cmd.CommandType = CommandType.Text;
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        tableString += rdr["COLUMN_NAME"] + ", ";
                    }

                    tableString = tableString.Substring(0, tableString.Length - 2);
                }
            }

            string select = "Select * from ort";
            if (searchRequest != "")
            {
                select += $" where '{searchRequest}' in ({tableString})";
            }
            Form4 f4 = new Form4(select, "ort", connection, userCommand);
            f4.Show();
        }
    }
}
