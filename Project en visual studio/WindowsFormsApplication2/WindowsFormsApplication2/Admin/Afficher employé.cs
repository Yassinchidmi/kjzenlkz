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
    public partial class Afficher_employé : Form
    {
        public Afficher_employé()
        {
            InitializeComponent();
        }
        DEC d = new DEC();
        liste_employé le = new liste_employé();
       
        private void label15_Click(object sender, EventArgs e)
        {
            this.Hide();
            liste_employé le = new liste_employé();
            le.Show();
        }

        private void Afficher_employé_Load(object sender, EventArgs e)
        {
            
    }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        public int idemployé;
        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Visible = true; textBox2.Visible = true; textBox3.Visible = true; textBox4.Visible = true; textBox5.Visible = true; textBox6.Visible = true; textBox7.Visible = true; textBox8.Visible = true; textBox9.Visible = true;
            dateTimePicker1.Visible = true;

            
            label3.Visible=false;
            label4.Visible=false;
            label6.Visible=false;
                label1.Visible=false;
            label7.Visible=false;
            label9.Visible=false;
               label10.Visible=false;
                label11.Visible=false;
               label12.Visible=false;
               label13.Visible = false;

            DataRow dr = d.ds.Tables[1].Rows.Find(idemployé);
            DataRow dr1 = d.ds.Tables[0].Rows.Find(int.Parse(dr[2].ToString()));

         
            textBox2.Text = dr1[3].ToString();
            textBox3.Text = dr1[1].ToString();
            textBox4.Text = dr1[2].ToString();
            d.cnx.Open();
            SqlCommand cmd1 = new SqlCommand("select * from Profils where idemployé='" + idemployé + "'", d.cnx);
            SqlDataReader dr3 = cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            while (dr3.Read())
            {
                textBox1.Text = dr3[1].ToString();
                textBox5.Text = dr3[5].ToString();
                textBox6.Text = dr3[2].ToString();
                textBox7.Text = dr3[6].ToString();
                dateTimePicker1.Text = dr3[7].ToString();
                textBox9.Text = dr3[4].ToString();
                textBox8.Text = dr3[3].ToString();
            }
            d.cnx.Close();
            button1.Visible = false;
            button2.Visible = true;
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow dr = d.ds.Tables[1].Rows.Find(idemployé);
            DataRow dr1 = d.ds.Tables[0].Rows.Find(int.Parse(dr[2].ToString()));

            
          
            d.cnx.Open();
            SqlCommand cmd = new SqlCommand("update Users set Email='" + textBox3.Text + "',Upassword='" + textBox4.Text + "',Urole='" + textBox2.Text + "' where iduser=" + int.Parse(dr1[0].ToString()), d.cnx);
            cmd.ExecuteNonQuery();
            d.cnx.Close();
            DataRow dr2 = dr.GetChildRows("REP")[0];
            d.cnx.Open();
            SqlCommand cmd2 = new SqlCommand("update Profils set poste='" + textBox1.Text + "',adresse='" + textBox5.Text + "',RIB='" + textBox6.Text + "',nationnalité='" + textBox7.Text + "',datenaissance='" + DateTime.Parse(dateTimePicker1.Text) + "',telephoneproche='" + textBox8.Text + "',telephone='" + textBox9.Text + "' where numprofil=" + int.Parse(dr2[0].ToString()), d.cnx);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Modification effectue avec succés");
            d.cnx.Close();


            label3.Visible = true;
            label4.Visible = true;
            label6.Visible = true;
            label1.Visible = true;
            label7.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;

            label3.Text = dr1[3].ToString();
            label4.Text = dr1[1].ToString();
            label6.Text = dr1[2].ToString();

            d.cnx.Open();
            SqlCommand cmd1 = new SqlCommand("select * from Profils where idemployé='" + idemployé + "'", d.cnx);
            SqlDataReader dr3 = cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            while (dr3.Read())
            {
                label1.Text = dr3[1].ToString();
                label7.Text = dr3[5].ToString();
                label9.Text = dr3[2].ToString();
                label10.Text = dr3[6].ToString();
                label11.Text = dr3[7].ToString();
                label12.Text = dr3[4].ToString();
                label13.Text = dr3[3].ToString();
            }
            d.cnx.Close();

            textBox1.Visible = false; textBox2.Visible = false; textBox3.Visible = false; textBox4.Visible = false; textBox5.Visible = false; textBox6.Visible = false; textBox7.Visible = false; textBox8.Visible = false; textBox9.Visible = false;
            dateTimePicker1.Visible = false;


            button2.Visible = false;
            button1.Visible = true;
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

      
    }
}
 