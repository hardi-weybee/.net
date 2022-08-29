using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceApplication
{
    public partial class party : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                addData();
            }
        }

        protected void addData()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=DESKTOP-SUG1Q46; database=invoice; integrated security=SSPI");
                con.Open();
                SqlDataAdapter sde = new SqlDataAdapter("Select * from partyData", con);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = GridView1.Rows[Convert.ToInt32(e.CommandArgument)];
            int id = Convert.ToInt32(gr.Cells[0].Text);
            string name = gr.Cells[1].Text;

            if (e.CommandName == "Edit") {
                Response.Redirect("addParty.aspx?id=" +id+ "&name=" +name);
            } else if (e.CommandName == "Del")
            {              
                SqlConnection con = null;
                try
                {                 
                    con = new SqlConnection("data source=DESKTOP-SUG1Q46; database=invoice; integrated security=SSPI");
                    SqlCommand sc = new SqlCommand("delete from partyData where ID=" + id, con);
                    con.Open();

                    sc.ExecuteNonQuery();
                    addData();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
               
                    con.Close();
                }
            }
        }       
    }
}