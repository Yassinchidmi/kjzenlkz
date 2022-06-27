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
    public partial class liste_départements : Form
    {
        public liste_départements()
        {
            InitializeComponent();
        }
        DEC d = new DEC();
        private void liste_départements_Load(object sender, EventArgs e)
        {
            d.cnx.Open();
            SqlCommand cmd = new SqlCommand("select numdepartement as [Numéro département],nomdepartement as [Nom département],nomadmin as Gestionnaire from Departements d inner join Administrateur a on d.idadmin=a.idadmin", d.cnx);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            d.cnx.Close();
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

        private void employésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            liste_employé le = new liste_employé();
            le.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.SelectedCells[0].RowIndex;
            d.cnx.Open();
            SqlCommand cmd = new SqlCommand("delete Departements where numdepartement='" + int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()) + "'", d.cnx);
            cmd.ExecuteNonQuery();
            d.cnx.Close();
            liste_départements_Load(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            creer_département cd = new creer_département();
            cd.Show();
        }
    }
}
