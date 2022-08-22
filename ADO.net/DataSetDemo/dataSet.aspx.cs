using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataSetDemo
{
    public partial class dataSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //using(SqlConnection con = new SqlConnection("data source=.; database=student; integrated security=SSPI"))
            //{
            //    SqlDataAdapter sde = new SqlDataAdapter("Select * from student", con);
            //    DataSet ds = new DataSet();
            //    sde.Fill(ds);
            //    GridView1.DataSource = ds;
            //    GridView1.DataBind();
            //}

            try {
                SqlConnection con = new SqlConnection("data source=.; database=student; integrated security=SSPI");
                con.Open();
                SqlDataAdapter sde = new SqlDataAdapter("Select * from student", con);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            } catch(Exception a)
            {
                Console.WriteLine("Something went wrong" + a);
            }          
        }
    }
}