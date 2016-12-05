using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication3
{
    
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection connEvent = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = "Server=mssql4.gear.host;Initial Catalog=cis4160db1;"
                    + "Integrated Security=False;User Id=cis4160db1;"
                    + "Password=" + Application["sqlPW"].ToString() +
                    ";MultipleActiveResultSets=True";
                SqlConnection connEvent = new SqlConnection(connString);
                connEvent.Open();
                SqlCommand comEvent = new SqlCommand("dbo.CreateOneThing", connEvent);
                comEvent.CommandType = CommandType.StoredProcedure;
                comEvent.Parameters.AddWithValue("@ThingDescr", txtInfo.Text);
                int iInserted = comEvent.ExecuteNonQuery();
            }
            catch(Exception exc)
            {
                Response.Write(exc.Message);
            }
            finally
            {
                if (connEvent != null)
                {
                    connEvent.Close();
                }
            }

        }
    }
}