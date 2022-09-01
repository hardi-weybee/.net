using System;
using System.Data;
using System.Data.SqlClient;
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
    public partial class party : System.Web.UI.Page
    {
        conn c = new conn();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                displayData();
            }
        }
        protected void displayData()
        {
            try
            {
                SqlDataAdapter sde = new SqlDataAdapter("Select * from partyData", conn.GetSqlConnection());
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

        protected void EditBtn_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)(sender as System.Web.UI.Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(GridView1.Rows[rowIndex].Cells[0].Text);
            string name = GridView1.Rows[rowIndex].Cells[1].Text;

            Response.Redirect("addParty.aspx?id=" + id + "&name=" + name);
        }

        protected void DeleteBtn_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)(sender as System.Web.UI.Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(GridView1.Rows[rowIndex].Cells[0].Text);       

            try
            {
                SqlCommand sc = new SqlCommand("delete from partyData where ID=" + id, conn.GetSqlConnection());
                if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete this Party", "Conformation Page", (MessageBoxButtons)MessageBoxButton.YesNo) == DialogResult.Yes)
                {
                    sc.ExecuteNonQuery();
                    displayData();
                } else
                {
                    Response.Redirect("party.aspx");
                }             
            }
            catch (Exception ex)
            {
                error.Text = "You Cannot delete the selected party as it is assigned to the product...";
            }
            finally
            {
                c.CloseSqlConnection();
            }
        }
    }
}