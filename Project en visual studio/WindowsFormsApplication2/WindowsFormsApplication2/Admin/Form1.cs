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
    public partial class Form1 : Form
    {  
        public Form1()
        {
            InitializeComponent();
           
        }
        DEC d = new DEC();
        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
             
        }
     

        liste_employé l = new liste_employé();
        public DataRow dr1;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" && textBox1.Text == "")
                MessageBox.Show("Veuillez saisir l'Email et le mot de passe");
            else if (textBox1.Text == "")
                MessageBox.Show("Veuillez saisir l'Email");
            else if (textBox2.Text == "")
                MessageBox.Show("Veuillez saisir le mot de passe");
            else
            {
                d.cnx.Open();
                SqlCommand cmd = new SqlCommand("select * from Users where Email='" + textBox1.Text + "'", d.cnx);                
                SqlDataReader dr=cmd.ExecuteReader();
                if (dr.HasRows)
                { 
                while (dr.Read())
                {
                    if (textBox2.Text != dr[2].ToString())
                        MessageBox.Show("Mot de masse incorrect");
                    else
                    {
                        if (dr[3].ToString() == "Admin")
                        {
                            this.Hide();
                            l.Show();
                        }
                        else
                        {
                            this.Hide();
                            Informations_employé ie = new Informations_employé();

                           


                            DataRow dr3 = d.ds.Tables[0].Rows.Find(int.Parse(dr[0].ToString()));

                           


                            ie.label16.Text = dr3[1].ToString();
                            ie.label17.Text = dr3[2].ToString();
                            ie.label14.Text = dr3[3].ToString();
                            DataRow dr4 = dr3.GetChildRows("RUE")[0];
                            ie.label1.Text =dr4[1].ToString();
                      
                            DataRow dr5 = dr4.GetChildRows("REP")[0];
                            ie.label15.Text = dr5[1].ToString();
                            ie.label18.Text = dr5[5].ToString();
                            ie.label19.Text = dr5[2].ToString();
                            ie.label20.Text = dr5[6].ToString();
                            ie.label21.Text = dr5[3].ToString();
                            ie.label22.Text = dr5[4].ToString();
                            ie.label23.Text = dr5[7].ToString();
                            ie.Show();                       
                        }
                    }
                }
                }
                    else
                    MessageBox.Show("L'email saisi est incorrect");
                
                d.cnx.Close();

            
                
         


               
                                      


                
            }

           
          
              


            }



        }


    }


        
        

     
    

