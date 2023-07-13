using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Kianosh_Safarzadeh_Project
{
    public class Mydatabase
    {
        public static DataTable OpenSQL(string SQL) //Show Table
        {

            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "server=(localdb)\\localhost;database=Kianosh_Safarzadeh;integrated security=true";
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = SQL;
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                cn.Close();

                return dt;
            }
            catch (Exception ix)
            {
                MessageBox.Show("Error has been Accurde: \n" + ix);
                return null;
            }
        }
        public static void RunSQL(string SQL)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = "server=(localdb)\\localhost;database=Kianosh_Safarzadeh;integrated security=true";
                cn.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = cn,
                    CommandText = SQL
                };
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ix)
            {
                MessageBox.Show("Error has been Accuerde: \n" + ix);
            }
        }
    }
}
