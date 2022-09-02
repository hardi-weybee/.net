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
    public partial class assignParty : System.Web.UI.Page
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
                SqlDataAdapter sde = new SqlDataAdapter("select apd.ID, PartyName, ProductName from assignPartyData apd, partyData pd, productData prd where pd.ID = apd.partyID and prd.ID = apd.productID", conn.GetSqlConnection());
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
            string name1 = GridView1.Rows[rowIndex].Cells[1].Text;
            string name2 = GridView1.Rows[rowIndex].Cells[2].Text;

            Response.Redirect("addAssign.aspx?id=" + id + "&name1=" + name1 + "&name2=" + name2);
        }

        protected void DeleteBtn_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)(sender as System.Web.UI.Control).NamingContainer).RowIndex;
            int id = Convert.ToInt32(GridView1.Rows[rowIndex].Cells[0].Text);
           
            try
            {
                SqlCommand sc = new SqlCommand("delete from assignPartyData where ID=" + id, conn.GetSqlConnection());
                
                if (System.Windows.Forms.MessageBox.Show("Are you sure you want to delete this Assigned Party", "myconfirm", (MessageBoxButtons)MessageBoxButton.YesNo) == DialogResult.Yes)
                {
                    sc.ExecuteNonQuery();
                    displayData();
                }
                else
                {
                    Response.Redirect("assignParty.aspx");
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