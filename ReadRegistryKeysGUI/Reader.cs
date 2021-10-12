using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegistryKeyReader;


namespace ReadRegistryKeysGUI
{
    public partial class Reader : Form
    {
        public Reader()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            

            if (string.IsNullOrEmpty(tbInput.Text))
                lblError.Text = "Insert a registry key to read";

            try
            {
                var reader = new RegistryStream();
                var keyValues = reader.Read(tbInput.Text).ToList();
                dvOutput.AutoGenerateColumns = true;
                dvOutput.DataSource = keyValues;
            }
            catch (Exception error)
            {
                lblError.Text = error.Message;
                return;
            }

            dvOutputSetup();

            lblPath.Text = tbInput.Text + ":";
            ClearInput();

            btnClear.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTable();
            ClearInput();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dvOutputSetup()
        {
            if (dvOutput.Columns.Count == 3)
                ClearTable();


            dvOutput.ReadOnly = true;
            dvOutput.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dvOutput.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dvOutput.ColumnHeadersDefaultCellStyle.Font =
                new Font(dvOutput.Font, FontStyle.Bold);


            InsertColumn(nameof(RegistryValueElement.Name), "Name");
            InsertColumn(nameof(RegistryValueElement.ValueType), "Type");
            InsertColumn(nameof(RegistryValueElement.Value), "Value");


            dvOutput.Columns[2].Width = 300;

            dvOutput.Name = "Registry Key";
            dvOutput.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dvOutput.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            dvOutput.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dvOutput.GridColor = Color.Black;
            dvOutput.RowHeadersVisible = false;

            dvOutput.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }

        public DataGridViewColumn GenerateColumn(string columnName, string displayValue)
        {
            var column = new DataGridViewTextBoxColumn();
            column.Name = columnName;
            column.HeaderText = displayValue;
            column.DataPropertyName = columnName;
            return column;
        }

        public void InsertColumn(string columnName, string displayValue)
        {
            dvOutput.Columns.Add(GenerateColumn(columnName, displayValue));
        }

        private void ClearTable()
        {
            dvOutput.Columns.Clear();
            lblPath.Text = "";
            btnClear.Enabled = false;
        }

        private void ClearInput()
        {
            tbInput.Clear();
        }

    }
}
