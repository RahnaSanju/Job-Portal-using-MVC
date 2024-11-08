using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjectMVC.Models
{
    public class StateDistrictCls
    {
        string connectionString = ConfigurationManager.ConnectionStrings["JobCon"].ConnectionString;
        SqlConnection con;
        public StateDistrictCls()
        {
            con = new SqlConnection(connectionString);
        }

        public List<jStateClass> selectStates()
        {
            var getdata = new List<jStateClass>(); //same as List<StateClass> getdata= new List<StateClass>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_GetStates", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var o = new jStateClass
                    {
                        StId = Convert.ToInt32(dr["State_Id"]), //set
                        StName = dr["State_Name"].ToString()
                    };
                    getdata.Add(o);
                }
                con.Close();
                return getdata;
            }
            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }


        public List<jDistClass> selectDistricts(int StateId)
        {
            var getdata = new List<jDistClass>(); //same as List<DistClass> getdata= new List<DistClass>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_GetDistricts", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stId", StateId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var o = new jDistClass
                    {
                        DistId = Convert.ToInt32(dr["Dist_Id"]), //set
                        DistName = dr["Dist_Name"].ToString()
                    };
                    getdata.Add(o);
                }
                con.Close();
                return getdata;
            }
            catch
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                throw;
            }
        }
    }
}