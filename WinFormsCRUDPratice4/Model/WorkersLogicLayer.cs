using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace WinFormsCRUDPratice4.Model
{
    
    class WorkersLogicLayer
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public List<Workers> GetWorkers()
        {
            List<Workers> li = new List<Workers>();

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("getAllData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while(rdr.Read())
                {
                    Workers w = new Workers();

                    w.id = Convert.ToInt32(rdr["id"].ToString());
                    w.fullName = rdr["fullName"].ToString();
                    w.gender = rdr["gender"].ToString();
                    w.states = rdr["states"].ToString();
                    w.DOB = Convert.ToDateTime(rdr["DOB"].ToString());
                    w.payments = Convert.ToInt32(rdr["payments"].ToString());
                    w.addressPlace = rdr["addressPlace"].ToString();

                    li.Add(w);
                }

            }
            catch
            {
                MessageBox.Show("Some Error....");
                //throw;
            }

            return li;
        } //Method close for getAllData


        public int insert(Workers wvm) //workers view model
        {
            int msg = -1;

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("insertData", con);
                cmd.Parameters.Add("@fullName", SqlDbType.VarChar, 100).Value = wvm.fullName;
                cmd.Parameters.Add("@gender", SqlDbType.VarChar, 100).Value = wvm.gender;
                cmd.Parameters.Add("@states", SqlDbType.VarChar, 100).Value = wvm.states;
                cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = wvm.DOB;
                cmd.Parameters.Add("@payments", SqlDbType.Int).Value = wvm.payments;
                cmd.Parameters.Add("@addressPlace", SqlDbType.VarChar, 100).Value = wvm.addressPlace;
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                msg = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                msg = 0;
                //throw;
            }

            return msg;
        }

        public Workers getElementById(int id)
        {
            Workers w = new Workers();

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("getDataById", con);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Workers w = new Workers();

                    w.id = Convert.ToInt32(rdr["id"].ToString());
                    w.fullName = rdr["fullName"].ToString();
                    w.gender = rdr["gender"].ToString();
                    w.states = rdr["states"].ToString();
                    w.DOB = Convert.ToDateTime(rdr["DOB"].ToString());
                    w.payments = Convert.ToInt32(rdr["payments"].ToString());
                    w.addressPlace = rdr["addressPlace"].ToString();

                    //li.Add(w);
                }

            }
            catch
            {
                MessageBox.Show("Some Error....");
                //throw;
            }

            return w;
        }//method close getElementById

        public int update(Workers wvm) //workers view model
        {
            int msg = -1;

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("updateData", con);
                con.Open();

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = wvm.id;
                cmd.Parameters.Add("@fullName", SqlDbType.VarChar, 100).Value = wvm.fullName;
                cmd.Parameters.Add("@gender", SqlDbType.VarChar, 100).Value = wvm.gender;
                cmd.Parameters.Add("@states", SqlDbType.VarChar, 100).Value = wvm.states;
                cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = wvm.DOB;
                cmd.Parameters.Add("@payments", SqlDbType.Int).Value = wvm.payments;
                cmd.Parameters.Add("@addressPlace", SqlDbType.VarChar, 100).Value = wvm.addressPlace;
                
                cmd.CommandType = CommandType.StoredProcedure;
                msg = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                msg = 0;
                //throw;
            }

            return msg;
        } //Method close for update


        public int delete(int id) //workers view model
        {
            int msg = -1;

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("deleteData", con);
                con.Open();

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                //cmd.Parameters.Add("@fullName", SqlDbType.VarChar, 100).Value = wvm.fullName;
                //cmd.Parameters.Add("@gender", SqlDbType.VarChar, 100).Value = wvm.gender;
                //cmd.Parameters.Add("@states", SqlDbType.VarChar, 100).Value = wvm.states;
                //cmd.Parameters.Add("@DOB", SqlDbType.DateTime).Value = wvm.DOB;
                //cmd.Parameters.Add("@payments", SqlDbType.Int).Value = wvm.payments;
                //cmd.Parameters.Add("@addressPlace", SqlDbType.VarChar, 100).Value = wvm.addressPlace;

                cmd.CommandType = CommandType.StoredProcedure;
                msg = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                msg = 0;
                //throw;
            }

            return msg;
        } //Method close for update

    }
}
