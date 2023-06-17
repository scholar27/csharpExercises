using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Kundenverwaltung
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private MySqlConnection databaseConnection()
        {
            string server = "localhost";
            string database = "schmid_kunden";
            string user = "root";
            string password = "";
            string port = "3306";

            string connectionString = String.Format("server={0};port={1};user id={2}; password={3}; database={4};", server, port, user, password, database);
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }


        private void checkTown(MySqlConnection connection, string plz, string ort)
        {
            string sqlCmdOrt = "SELECT * FROM ort WHERE PLZ = '" + plz + "';";


            MySqlCommand cmd = new MySqlCommand(sqlCmdOrt, connection);
            cmd.CommandType = CommandType.Text;

            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                rdr.Close();
            }
            else
            {
                rdr.Close();
                insertNewPostalCode(connection, plz, ort);
            }


        }
        private void insertNewPostalCode(MySqlConnection connection, string plz, string ort)
        {
            string sqlCmdNeuerOrt = "INSERT INTO ort (PLZ, Name) VALUES (@plz, @name)";
            MySqlCommand cmdInsertOrt = new MySqlCommand(sqlCmdNeuerOrt, connection);
            cmdInsertOrt.CommandType = CommandType.Text;
            cmdInsertOrt.CommandText = sqlCmdNeuerOrt;

            cmdInsertOrt.Parameters.Add("@plz", MySqlDbType.VarChar).Value = plz;
            cmdInsertOrt.Parameters.Add("@name", MySqlDbType.VarChar).Value = ort;
            cmdInsertOrt.ExecuteNonQuery();

        }

        private void checkIfEmpty(string input, ref List<string> fehler, string type)
        {
            if (string.IsNullOrEmpty(input))
            {
                fehler.Add(type + " darf nicht leer sein");
            }
            if (type == "Email")
            {
                validateEmail(input, ref fehler, type );
            }
        }

        private void validateEmail(string input, ref List<string> fehler, string type)
        {
            Regex regex = new Regex(@"^[\w.% +-]+@[A-Za-z\d.-]+\.[A-Za-z]{2,}$");
            MatchCollection matches = regex.Matches(input);

            if (matches.Count < 1)
            {
                fehler.Add(type + " entspricht nicht dem korrekten Format");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = databaseConnection();
            List<string> fehler = new List<string>();

            string betriebsname = BetriebsnameValue.Text;
            string strasse = StrasseValue.Text;
            string hausnummer = HausnrValue.Text;
            string plz = PLZValue.Text;
            string ort = OrtValue.Text;
            string vorname = AnVornameValue.Text;
            string nachname = AnNachnameValue.Text;
            string email = EmailValue.Text;
            string telefonnummer = TelefonValue.Text;

            checkIfEmpty(betriebsname, ref fehler, "Betriebsname");
            checkIfEmpty(strasse, ref fehler, "Strasse");
            checkIfEmpty(hausnummer, ref fehler, "Hausnummer");
            checkIfEmpty(ort, ref fehler, "Ort");
            checkIfEmpty(vorname, ref fehler, "Vorname");
            checkIfEmpty(nachname, ref fehler, "Nachname");
            checkIfEmpty(email, ref fehler, "Email");
            checkIfEmpty(telefonnummer, ref fehler, "Telefonnummer");

            if (!fehler.Any())
            {
                using (connection)
                {
                    string sqlCmdKunde = "INSERT INTO kunde (Betriebsname, Strasse, HausNr, Ortsid) VALUES (@betriebsname, @strasse, @hausnummer, (SELECT OrtsId FROM Ort WHERE PLZ = @plz ))";

                    try
                    {

                        connection.Open();
                        checkTown(connection, plz, ort);
                        using (MySqlCommand cmd2 = new MySqlCommand(sqlCmdKunde, connection))
                        {
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = sqlCmdKunde;
                            cmd2.Parameters.Add("@betriebsname", MySqlDbType.VarChar).Value = betriebsname;
                            cmd2.Parameters.Add("@strasse", MySqlDbType.VarChar).Value = strasse;
                            cmd2.Parameters.Add("@hausnummer", MySqlDbType.VarChar).Value = hausnummer;
                            cmd2.Parameters.Add("@plz", MySqlDbType.VarChar).Value = plz;

                            int rowsAdded = cmd2.ExecuteNonQuery();
                            if (rowsAdded > 0)
                                MessageBox.Show("Kunde hinzugefügt");
                            else
                                MessageBox.Show("Fehler beim hinzufügen");

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR:" + ex.Message);
                    }
                }

                using (connection)
                {
                    string sqlCmdAnsprechpartner = "INSERT INTO ansprechpartner (Nachname, Vorname, TelefonNr, Email, KundenNr) VALUES (@nachname, @vorname, @telefonnummer, @email, (SELECT KundenNr FROM kunde WHERE Betriebsname = @betriebsname ))";

                    try
                    {

                        connection.Open();
                        using (MySqlCommand cmd2 = new MySqlCommand(sqlCmdAnsprechpartner, connection))
                        {
                            cmd2.CommandType = CommandType.Text;
                            cmd2.CommandText = sqlCmdAnsprechpartner;

                            cmd2.Parameters.Add("@nachname", MySqlDbType.VarChar).Value = nachname;
                            cmd2.Parameters.Add("@vorname", MySqlDbType.VarChar).Value = vorname;
                            cmd2.Parameters.Add("@telefonnummer", MySqlDbType.VarChar).Value = telefonnummer;
                            cmd2.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;
                            cmd2.Parameters.Add("@betriebsname", MySqlDbType.VarChar).Value = betriebsname;


                            int rowsAdded = cmd2.ExecuteNonQuery();
                            if (rowsAdded > 0)
                                MessageBox.Show("Ansprechpartner hinzugefügt");
                            else
                                MessageBox.Show("Fehler beim hinzufügen");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR:" + ex.Message);
                    }
                }

            }
            else
            {
                foreach (string item in fehler)
                {
                    MessageBox.Show(item);
                }
            }
        }
    }
}
