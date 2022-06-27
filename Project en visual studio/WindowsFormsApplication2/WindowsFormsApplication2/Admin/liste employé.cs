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
    public partial class liste_employé : Form
    {


        public liste_employé()
        {
            InitializeComponent();

        }

        private void départementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            liste_départements ld = new liste_départements();
            ld.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Etes vous sûr de vouloir déconnecter?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Hide();
                Form1 f = new Form1();
                f.Show();
            }
            else
            { } 
        }

        DEC d = new DEC();

        private void liste_employé_Load(object sender, EventArgs e)
        {
            d.cnx.Open();
            SqlCommand cmd = new SqlCommand("select E.idemployé as [Id employé],nomemployé as [Nom employé],poste as Poste from Employé E inner join Profils P on E.idemployé=p.idemployé", d.cnx);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            d.cnx.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string iduser;
            int i = dataGridView1.SelectedCells[0].RowIndex;
            DataRow dr = d.ds.Tables[1].Rows.Find(int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
            iduser = dr[2].ToString();
            DataRow dr1 = d.ds.Tables[0].Rows.Find(int.Parse(iduser));

           
            d.cnx.Open();
            SqlCommand cmd = new SqlCommand("delete Profils where idemployé='" + int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()) + "'", d.cnx);
            cmd.ExecuteNonQuery();
            d.cnx.Close();
            d.cnx.Open();
            SqlCommand cmd1 = new SqlCommand("delete Employé where idemployé='" + int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()) + "'", d.cnx);
            cmd1.ExecuteNonQuery();
            d.cnx.Close();
            d.cnx.Open();
            SqlCommand cmd2 = new SqlCommand("delete Users where iduser ='" + dr1[0] + "'", d.cnx);
            cmd2.ExecuteNonQuery();
            d.cnx.Close();
            liste_employé_Load(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            creer_employé ce = new creer_employé();
            ce.Show();
        }

        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            int idemployé = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            this.Hide();
            Afficher_employé ae = new Afficher_employé();
            ae.idemployé = idemployé;
            ae.label2.Text = "L'employé: " + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()  ;
            DataRow dr = d.ds.Tables[1].Rows.Find(idemployé);
            DataRow dr1 = d.ds.Tables[0].Rows.Find(int.Parse(dr[2].ToString()));
            ae.label3.Text = dr1[3].ToString();
             ae.label4.Text = dr1[1].ToString();
          ae.label6.Text = dr1[2].ToString();

            d.cnx.Open();
            SqlCommand cmd = new SqlCommand("select * from Profils where idemployé='" + idemployé + "'", d.cnx);
            SqlDataReader dr3 = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            while (dr3.Read())
            {
                ae.label1.Text = dr3[1].ToString();
               ae.label7.Text = dr3[5].ToString();
                ae.label9.Text = dr3[2].ToString();
               ae.label10.Text = dr3[6].ToString();
                ae.label11.Text = dr3[7].ToString();
               ae.label12.Text = dr3[4].ToString();
               ae.label13.Text = dr3[3].ToString();

                
                { }
            }
            d.cnx.Close();

            ae.Show();


          
        }  

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}