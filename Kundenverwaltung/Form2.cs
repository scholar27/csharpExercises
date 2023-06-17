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
using Org.BouncyCastle.Asn1.Anssi;

namespace Kundenverwaltung
{
    public partial class Form2 : Form
    {
        private MySqlCommand selectCmd;
        private MySqlConnection conn;
        private string selectCommand;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(MySqlCommand cmd, MySqlConnection connection)
        {
            InitializeComponent();
            setSelectCmd(cmd);
            setSelectConnection(connection);
            using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();

                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        public void setSelectCmd(MySqlCommand cmd)
        {
            selectCmd = cmd;
        }

        public void setSelect(string select)
        {
            selectCommand = select;
        }

        public void setSelectConnection(MySqlConnection connection)
        {
            conn = connection;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
