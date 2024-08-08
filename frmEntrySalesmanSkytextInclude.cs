using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace K5GLONLINE
{
    public partial class frmEntrySalesmanSkytextInclude : Form
    {
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        private SqlConnection myconnection;
        private BindingSource bindingSource = null;
        BindingSource bsource = new BindingSource();
        //   DataSet ds = null;
        string sql;
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmEntrySalesmanSkytextInclude()
        {
            InitializeComponent();
        }

        private void frmNameEdit_Load(object sender, EventArgs e)
        {
                        ClsPermission1.ClsObjects(this.Text);
                        if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
                        {
                            MessageBox.Show("You do not have necessary permission to open this file", "GL");
                            this.Close();
                        }
                        else
                        {

                            ClsGetConnection1.ClsGetConMSSQL();
                            myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                            sql = "SELECT PC, PersonnelName, IncludeSkyText ";
                            sql += "FROM tblPersonnel";

                            da = new SqlDataAdapter(sql, myconnection);
                            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
                            da.SelectCommand.CommandTimeout = 600;
                            dataTable = new DataTable();
                            da.Fill(dataTable);
                            bindingSource = new BindingSource();
                            bindingSource.DataSource = dataTable;

                            //Adding PC TextBox
                            DataGridViewTextBoxColumn ColumnPC = new DataGridViewTextBoxColumn();
                            ColumnPC.HeaderText = "Code";
                            ColumnPC.Width = 80;
                            ColumnPC.DataPropertyName = "PC";
                            ColumnPC.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            ColumnPC.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            ColumnPC.Visible = false;
                            dgv1.Columns.Add(ColumnPC);

                            //Adding  PersonnelName TextBox
                            DataGridViewTextBoxColumn ColumnPersonnelName = new DataGridViewTextBoxColumn();
                            ColumnPersonnelName.HeaderText = "Name";
                            ColumnPersonnelName.Width = 250;
                            ColumnPersonnelName.DataPropertyName = "PersonnelName";
                            ColumnPersonnelName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            ColumnPersonnelName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            ColumnPersonnelName.ReadOnly = true;
                            dgv1.Columns.Add(ColumnPersonnelName);

                            //Adding  IncludeSkyText checkbox
                            DataGridViewCheckBoxColumn ColumnIncludeSkyText = new DataGridViewCheckBoxColumn();
                            ColumnIncludeSkyText.HeaderText = "Include Sky-Text";
                            ColumnIncludeSkyText.Width = 120;
                            ColumnIncludeSkyText.DataPropertyName = "IncludeSkyText";
                            ColumnIncludeSkyText.FalseValue = 0;
                            ColumnIncludeSkyText.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            ColumnIncludeSkyText.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dgv1.Columns.Add(ColumnIncludeSkyText);

                            //Setting Data Source for DataGridView
                            dgv1.DataSource = bindingSource;
                            myconnection.Close();
                            this.WindowState = FormWindowState.Maximized;
                            dgv1.AllowUserToAddRows = false;
                        }    
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                da.Update(dataTable);
                MessageBox.Show("Saved", "GL");

            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }

        }
    }
}
