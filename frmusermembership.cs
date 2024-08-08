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
    public partial class frmusermembership : Form
    {
        private SqlDataAdapter da;
        private SqlConnection myconnection;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
    //    DataSet ds = null;
        string sql;
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmusermembership()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmusermembership_Load(object sender, EventArgs e)
        {
                        ClsPermission1.ClsObjects(this.Text);
                        if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
                        {
                            MessageBox.Show("You do not have necessary permission to open this file", "GL");
                            this.Close();
                        }
                        else
                        {

                            ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);

                            sql = "SELECT UserCode, UserName, GroupCode FROM tblUser";

                            da = new SqlDataAdapter(sql, myconnection);
                            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
                            da.SelectCommand.CommandTimeout = 600;
                            dataTable = new DataTable();
                            da.Fill(dataTable);
                            bindingSource = new BindingSource();
                            bindingSource.DataSource = dataTable;

                            //Item Data Source

                            string selectQueryStringgroup = "SELECT GroupCode,GroupName FROM tblgroup";

                            SqlDataAdapter sqlDataAdaptergroup = new SqlDataAdapter(selectQueryStringgroup, myconnection);
                            SqlCommandBuilder sqlCommandBuildergroup = new SqlCommandBuilder(sqlDataAdaptergroup);

                            DataTable dataTableItem = new DataTable();
                            sqlDataAdaptergroup.Fill(dataTableItem);
                            BindingSource bindingSourcegroup = new BindingSource();
                            bindingSourcegroup.DataSource = dataTableItem;

                            //Adding  UserCode TextBox
                            DataGridViewTextBoxColumn ColumnUserCode = new DataGridViewTextBoxColumn();
                            ColumnUserCode.Visible = false;
                            ColumnUserCode.HeaderText = "User Code";
                            ColumnUserCode.Width = 80;
                            ColumnUserCode.DataPropertyName = "UserCode";
                            dgv1.Columns.Add(ColumnUserCode);

                            //Adding  UserName TextBox
                            DataGridViewTextBoxColumn ColumnUserName = new DataGridViewTextBoxColumn();
                            ColumnUserName.ReadOnly = true;
                            ColumnUserName.HeaderText = "User";
                            ColumnUserName.Width = 80;
                            ColumnUserName.DataPropertyName = "UserName";
                            dgv1.Columns.Add(ColumnUserName);

                            //Adding  Group Combo
                            DataGridViewComboBoxColumn ColumnGroup = new DataGridViewComboBoxColumn();
                            ColumnGroup.DataPropertyName = "GroupCode";
                            ColumnGroup.HeaderText = "Group";
                            ColumnGroup.Width = 120;

                            ColumnGroup.DataSource = bindingSourcegroup;
                            ColumnGroup.ValueMember = "GroupCode";
                            ColumnGroup.DisplayMember = "GroupName";
                            dgv1.Columns.Add(ColumnGroup);


                            ////Adding  Login checkbox
                            //DataGridViewCheckBoxColumn ColumnLogin = new DataGridViewCheckBoxColumn();
                            //ColumnLogin.HeaderText = "Login";
                            //ColumnLogin.Width = 80;
                            //ColumnLogin.DataPropertyName = "Login";
                            //ColumnLogin.FalseValue = 0;
                            //dgv1.Columns.Add(ColumnLogin);

                            //Setting Data Source for DataGridView

                            dgv1.DataSource = bindingSource;
                            //dgv1.AutoResizeColumns();
                            //dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                            dgv1.AllowUserToAddRows = false;
                        }
            }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                da.Update(dataTable);
                MessageBox.Show("Saved", "IS");
            
            }
            catch (Exception exceptionObj)
            {
                MessageBox.Show(exceptionObj.Message.ToString());
            }
        }

 
    }
}
