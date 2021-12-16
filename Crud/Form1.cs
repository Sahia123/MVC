using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Crud
{
    
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=dbaptech;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            showdata();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand insert = new SqlCommand("insert into tblStd values('"+txtName.Text+ "','" + txtCity.Text + "','" + txtEmail.Text + "'," +
                "'" + txtPhone.Text + "','" + txtAddress.Text + "')", con);

            if (insert.ExecuteNonQuery()>0) {
                MessageBox.Show("Data Saved !!!!");
                txtName.Text = txtCity.Text = txtAddress.Text = txtEmail.Text = txtPhone.Text = null;
            }
            else
            {
                MessageBox.Show("Data Not Saved!!");
            }


            con.Close();
        }
        public void showdata()
        {
            DataTable xtable = new DataTable();
            new SqlDataAdapter("select * from tblStd", con).Fill(xtable);
            xGrid.DataSource = xtable;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            

        }

        private void xGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string A = xGrid.CurrentRow.Cells[0].Value.ToString();
            xpic.Load("images//"+A+".jpg");
        }
    }
}
