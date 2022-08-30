using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;

namespace InvoiceApplication
{
    public partial class products : System.Web.UI.Page
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
                SqlDataAdapter sde = new SqlDataAdapter("Select * from productData", con);
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)(sender as System.Web.UI.Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(GridView1.Rows[rowIndex].Cells[0].Text);
            string name = GridView1.Rows[rowIndex].Cells[1].Text;
            //string productName = GridView1.Rows[rowIndex].Cells[2].Text;

            Response.Redirect("addProduct.aspx?id=" + id + "&name=" + name);
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)(sender as System.Web.UI.Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(GridView1.Rows[rowIndex].Cells[0].Text);

            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=DESKTOP-SUG1Q46; database=invoice; integrated security=SSPI");
                SqlCommand sc = new SqlCommand("delete from productData where ID=" + id, con);
                con.Open();
                if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete this Product", "myconfirm", (MessageBoxButtons)MessageBoxButton.YesNo) == DialogResult.Yes)
                {
                    sc.ExecuteNonQuery();
                    addData();
                }
                else
                {
                    Response.Redirect("products.aspx");
                }
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                error.Text = "You Cannot delete the selected product as it is assigned to the Party...";
            }
            finally
            {
                con.Close();
            }
        }
    }
}