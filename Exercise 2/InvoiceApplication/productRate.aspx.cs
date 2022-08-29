using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceApplication
{
    public partial class productRate : System.Web.UI.Page
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
                SqlDataAdapter sde = new SqlDataAdapter("select prd.ID, pd.ProductName, Rate, format(DateOfRate, 'dd-MM-yyyy') as DateOfRate from productRateData prd, productData pd where pd.ID = prd.productID", con);
                
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
            string name1 = gr.Cells[1].Text;
            //string rate = gr.Cells[2].Text;
            //string d = gr.Cells[3].Text;

            if (e.CommandName == "Edit")
            {
                Response.Redirect("addProductRate.aspx?id=" + id + "&name1=" + name1);

            }
            else if (e.CommandName == "Del")
            {
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=DESKTOP-SUG1Q46; database=invoice; integrated security=SSPI");
                    SqlCommand sc = new SqlCommand("delete from productRateData where ID=" + id, con);
                    con.Open();

                    sc.ExecuteNonQuery();
                    addData();
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
        }
    }
}