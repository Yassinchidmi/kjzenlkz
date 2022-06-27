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
    public partial class Informations_employé : Form
    {
        public Informations_employé()
        {
            InitializeComponent();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
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
       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

         
        }

        private void Informations_employé_Load(object sender, EventArgs e)
        {
            //DataView view = new DataView();
            //view.Table = d.ds.Tables[1];
            //view.RowFilter = "nomemployé = '" + label1.Text + "'";
        }
    }
}
