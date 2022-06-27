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
    public partial class creer_employé : Form
    {
        public creer_employé()
        {
            InitializeComponent();
        }
        DEC d = new DEC();
        private void creer_employé_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Admin");
            comboBox1.Items.Add("Employé");
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Hide();
            liste_employé le = new liste_employé();
            le.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iduser = d.ds.Tables[0].Rows.Count + 1;
            int iduser1 = d.ds.Tables[0].Rows.Count;
            int idadmin = d.ds.Tables[3].Rows.Count + 1;
            int idemployé = d.ds.Tables[1].Rows.Count + 1;
            int idemployé1 = d.ds.Tables[1].Rows.Count;
            int numprofil = d.ds.Tables["Profils"].Rows.Count + 1;
            d.cnx.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into Users values(" + iduser + ",'" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "')", d.cnx);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            d.cnx.Close();
            if (comboBox1.Text == "Employé")
            {
                d.cnx.Open();
                try
                {
                    SqlCommand cmd1 = new SqlCommand("insert into Employé values(" + idemployé + ",'" + textBox1.Text + "'," + iduser + ")", d.cnx);
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
                d.cnx.Close();
            }
        
            d.cnx.Open();
            try
            {
                SqlCommand cmd1 = new SqlCommand("insert into Profils values(" + numprofil + ",'" + textBox2.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + dateTimePicker1.Text + "'," + idemployé + ")", d.cnx);
                cmd1.ExecuteNonQuery();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            d.cnx.Close();
            MessageBox.Show("Profils ajouter avec succés");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            comboBox1.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToString();
        }
    }
}
