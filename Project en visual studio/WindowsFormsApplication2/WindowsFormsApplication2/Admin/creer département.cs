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

namespace WindowsFormsApplication2
{
    public partial class creer_département : Form
    {
        public creer_département()
        {
            InitializeComponent();
        }
        DEC d = new DEC();
        private void button1_Click(object sender, EventArgs e)
        {
           
                int numd = d.ds.Tables[4].Rows.Count + 1;
                d.cnx.Open();
                SqlCommand cmd = new SqlCommand("insert into Departements values(" + numd + ",'" + textBox1.Text + "'," + comboBox1.SelectedValue + ")", d.cnx);
                cmd.ExecuteNonQuery();
                d.cnx.Close();
                MessageBox.Show("Département ajouter avec succés");
                textBox1.Clear();
                comboBox1.Text = "";
            
        }
        
        private void creer_département_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = d.ds.Tables[3];
            comboBox1.DisplayMember = "nomadmin";
            comboBox1.ValueMember = "idadmin";
            comboBox1.Text = "";
          
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            liste_départements ld = new liste_départements();
            ld.Show();
        }
    }
}
