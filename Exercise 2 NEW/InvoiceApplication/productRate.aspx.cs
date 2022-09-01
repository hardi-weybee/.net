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
using System.Configuration;

namespace InvoiceApplication
{
    public partial class productRate : System.Web.UI.Page
    {
        conn c = new conn();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                addData();
            }           
        }

        protected void addData()
        {
            try
            {
                SqlDataAdapter sde = new SqlDataAdapter("select prd.ID, pd.ProductName, Rate, format(DateOfRate, 'dd-MM-yyyy') as DateOfRate from productRateData prd, productData pd where pd.ID = prd.productID", conn.GetSqlConnection());
                
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
                c.CloseSqlConnection();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)(sender as System.Web.UI.Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(GridView1.Rows[rowIndex].Cells[0].Text);
            string name1 = GridView1.Rows[rowIndex].Cells[1].Text;
            //string productName = GridView1.Rows[rowIndex].Cells[2].Text;

            Response.Redirect("addProductRate.aspx?id=" + id + "&name1=" + name1);
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)(sender as System.Web.UI.Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(GridView1.Rows[rowIndex].Cells[0].Text);

            try
            {
                SqlCommand sc = new SqlCommand("delete from productRateData where ID=" + id, conn.GetSqlConnection());
               
                if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete this Product Detail", "myconfirm", (MessageBoxButtons)MessageBoxButton.YesNo) == DialogResult.Yes)
                {
                    sc.ExecuteNonQuery();
                    addData();
                }
                else
                {
                    Response.Redirect("productRate.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                c.CloseSqlConnection();
            }
        }        
    }
}