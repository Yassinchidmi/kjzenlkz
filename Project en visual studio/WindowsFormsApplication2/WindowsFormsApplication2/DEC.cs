using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace WindowsFormsApplication2
{
    public class DEC
    { public DataSet ds = new DataSet();
        public SqlDataAdapter DA1,DA2,DA3,DA4,DA5;
        public SqlConnection cnx = new SqlConnection(Properties.Settings.Default.c1);
        
        public DEC()
        {
            DA1 = new SqlDataAdapter("select * from Users", cnx);
            DA1.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DA1.Fill(ds, "USERS");

           

            DA2 = new SqlDataAdapter("select * from Employé", cnx);
            DA2.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DA2.Fill(ds, "EMPLOYE");

            DA3 = new SqlDataAdapter("select * from Profils", cnx);
            DA3.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DA3.Fill(ds, "PROFILS");

            DA4 = new SqlDataAdapter("select * from Administrateur", cnx);
            DA4.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DA4.Fill(ds, "ADMIN");

            DA5 = new SqlDataAdapter("select * from Departements", cnx);
            DA5.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DA5.Fill(ds, "DEPARTEMENTS");

            DataRelation dr = new DataRelation("RUA", ds.Tables[0].Columns[0],ds.Tables[3].Columns[2]);
            ds.Relations.Add(dr);
            DataRelation dr1 = new DataRelation("RUE", ds.Tables[0].Columns[0], ds.Tables[1].Columns[2]);
            ds.Relations.Add(dr1);
            DataRelation dr2 = new DataRelation("REP", ds.Tables[1].Columns[0], ds.Tables[2].Columns[8]);
            ds.Relations.Add(dr2);
            
          
        }
    }
}
