using System;
using System.Collections;
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
    public partial class frmuserpermission : Form
    {
        private SqlDataAdapter da;
        private DataTable dataTable = null;
        private SqlConnection myconnection;
        private BindingSource bindingSource = null;
        BindingSource bsource = new BindingSource();
        //   DataSet ds = null;
        string sql;
        SqlCommand mycommand;
        BindingSource dbind = new BindingSource();
        SqlDataReader dr;
        ClsPermission ClsPermission1 = new ClsPermission();
        ClsGetConnection ClsGetConnection1 = new ClsGetConnection(); 

        public frmuserpermission()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buildgroupcode()
        {
            try
            {
                ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
                myconnection.Open();
                mycommand = new SqlCommand("SELECT GroupCode, GroupName from tblGroup", myconnection);
                mycommand.CommandTimeout = 600;
                dr = mycommand.ExecuteReader();
                ArrayList T = new ArrayList();

                while (dr.Read())
                {
                    T.Add(new Clsaddvalue(dr.GetString(1), dr.GetString(0)));
                }
                dr.Close();
                myconnection.Close();

                this.cbogroupcode.DataSource = T;
                this.cbogroupcode.DisplayMember = "Display";
                this.cbogroupcode.ValueMember = "Value";
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                dr.Close();
                myconnection.Close();
            }
        }

        private void frmuserpermission_Load(object sender, EventArgs e)
        {
            ClsPermission1.ClsObjects(this.Text);
            if (new ClsValidation().emptytxt(ClsPermission1.plstxtObject))
            {
                MessageBox.Show("You do not have necessary permission to open this file", "GL");
                this.Close();
            }
            else
            {

                buildgroupcode();
                cbogroupcode.Text = "";
            }
        }
        private void showpermission()
        {
            ClsGetConnection1.ClsGetConMSSQL(); myconnection = new SqlConnection(ClsGetConnection1.plsMyConMSSQL);
            sql = "SELECT GroupCode, ObjectName, Num FROM tblPermission WHERE GroupCode = '" + cbogroupcode.SelectedValue + "'";

            da = new SqlDataAdapter(sql, myconnection);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(da);
            da.SelectCommand.CommandTimeout = 600;
            dataTable = new DataTable();
            da.Fill(dataTable);
            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            //Object Data Source
    //        string selectQueryStringcat = "SELECT ObjectName As ON1, ObjectName As ON2 FROM tblobjects";
              string selectQueryStringcat = "SELECT ObjectName FROM tblobjects";

            SqlDataAdapter sqlDataAdaptercat = new SqlDataAdapter(selectQueryStringcat, myconnection);
            SqlCommandBuilder sqlCommandBuildergroup = new SqlCommandBuilder(sqlDataAdaptercat);

            DataTable dataTableItem = new DataTable();
            sqlDataAdaptercat.Fill(dataTableItem);
            BindingSource bindingSourcegroup = new BindingSource();
            bindingSourcegroup.DataSource = dataTableItem;

            //Adding  GroupCode TextBox
            DataGridViewTextBoxColumn ColumnGroupCode = new DataGridViewTextBoxColumn();
            ColumnGroupCode.HeaderText = "Group Code";
            //ColumnGroupCode.Width = 80;
            ColumnGroupCode.DataPropertyName = "GroupCode";
            ColumnGroupCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnGroupCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnGroupCode.Visible = false;
            dgv1.Columns.Add(ColumnGroupCode);

            //Adding  ObjectName Combo
            DataGridViewComboBoxColumn ColumnObjectName = new DataGridViewComboBoxColumn();
            ColumnObjectName.DataPropertyName = "ObjectName";
            ColumnObjectName.HeaderText = "Object Name";
            ColumnObjectName.Width = 200;
            ColumnObjectName.DataSource = bindingSourcegroup;
            ColumnObjectName.ValueMember = "ObjectName";
            ColumnObjectName.DisplayMember = "ObjectName";
            dgv1.Columns.Add(ColumnObjectName);

            //Adding  Num TextBox
            DataGridViewTextBoxColumn ColumnNum = new DataGridViewTextBoxColumn();
            ColumnNum.HeaderText = "Num";
            //ColumnRowNum.Width = 80;
            ColumnNum.DataPropertyName = "Num";
            ColumnNum.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnNum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnNum.Visible = false;
            dgv1.Columns.Add(ColumnNum);

            //Setting Data Source for DataGridView
            dgv1.DataSource = bindingSource;
            myconnection.Close();
        //    dgv1.AutoResizeColumns();
        //    dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //            dgv1.AllowUserToAddRows = false;
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

        private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgv1.CurrentRow.Cells[0].Value = cbogroupcode.SelectedValue;

        }

        private void cbogroupcode_SelectedIndexChanged(object sender, EventArgs e)
        {
 

        }

        private void cbogroupcode_Validating(object sender, CancelEventArgs e)
        {
            dgv1.DataSource = null;
            showpermission();
        }

          
    }
}
