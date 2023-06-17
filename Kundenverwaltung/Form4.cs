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
    public partial class Form4 : Form
    {
        private MySqlConnection connection;
        private string select;
        private string table;
        private string userCommand;


        public Form4()
        {
            InitializeComponent();
        }

        public Form4(string _select, string _table, MySqlConnection _connection, string _userCommand)
        {
            InitializeComponent();
            setSelect(_select);
            setTable(_table);
            setSelectConnection(_connection);
            setUserCommand(_userCommand);
            
            using(connection)
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(select, connection);
                cmd.CommandType = CommandType.Text;

                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();

                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
                }
            }
        }

        public void setSelect(string _select)
        {
            select = _select;
        }

        public void setSelectConnection(MySqlConnection _connection)
        {
            connection = _connection;
        }

        public void setTable(string _table)
        {
            table = _table;
        }

        public void setUserCommand(string _userCommand)
        {
            userCommand = _userCommand;
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            string columnValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            string primaryKeyColumnName = "";
            string query = "";
            string primaryKeyColumnValue = "";


            if (table == "ansprechpartner")
            {
                primaryKeyColumnName = "AnId";
                primaryKeyColumnValue = dataGridView1.Rows[e.RowIndex].Cells[primaryKeyColumnName].Value.ToString();
                query = "UPDATE ansprechpartner SET " + columnName + " = '" + columnValue + "' WHERE " + primaryKeyColumnName + " = '" + primaryKeyColumnValue + "'";
            }
            else if (table == "kunde")
            {
                primaryKeyColumnName = "KundenNr";
                primaryKeyColumnValue = dataGridView1.Rows[e.RowIndex].Cells[primaryKeyColumnName].Value.ToString();
                query = "UPDATE kunde SET " + columnName + " = '" + columnValue + "' WHERE " + primaryKeyColumnName + " = '" + primaryKeyColumnValue + "'";
            }
            else if (table == "ort")
            {
                primaryKeyColumnName = "OrtsId";
                primaryKeyColumnValue = dataGridView1.Rows[e.RowIndex].Cells[primaryKeyColumnName].Value.ToString();
                query = "UPDATE ort SET " + columnName + " = '" + columnValue + "' WHERE " + primaryKeyColumnName + " = '" + primaryKeyColumnValue + "'";
            }
            MySqlCommand command = new MySqlCommand(query, connection);

            // Execute the UPDATE statement
            using (connection)
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (userCommand == "delete")
            {
                if (e.RowIndex >= 0) // make sure the row index is valid
                {
                    // Get the primary key value of the selected row
                    string primaryKeyColumnName = "";
                    string primaryKeyColumnValue = "";
                    string query = "";

                    if (table == "ansprechpartner")
                    {
                        primaryKeyColumnName = "AnId";
                        primaryKeyColumnValue = dataGridView1.Rows[e.RowIndex].Cells[primaryKeyColumnName].Value.ToString();
                        query = "DELETE FROM ansprechpartner WHERE " + primaryKeyColumnName + " = '" + primaryKeyColumnValue + "'";
                    }
                    else if (table == "kunde")
                    {
                        primaryKeyColumnName = "KundenNr";
                        primaryKeyColumnValue = dataGridView1.Rows[e.RowIndex].Cells[primaryKeyColumnName].Value.ToString();
                        query = "DELETE FROM kunde WHERE " + primaryKeyColumnName + " = '" + primaryKeyColumnValue + "'";
                    }
                    else if (table == "ort")
                    {
                        primaryKeyColumnName = "OrtsId";
                        primaryKeyColumnValue = dataGridView1.Rows[e.RowIndex].Cells[primaryKeyColumnName].Value.ToString();
                        query = "DELETE FROM ort WHERE " + primaryKeyColumnName + " = '" + primaryKeyColumnValue + "'";
                    }

                    // Prompt the user to confirm the deletion
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this row?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        MySqlCommand command = new MySqlCommand(query, connection);

                        using (connection)
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

    }
}
