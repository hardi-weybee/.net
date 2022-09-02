using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows;
using System.Configuration;

namespace InvoiceApplication
{
    public partial class addProduct : System.Web.UI.Page
    {
        conn c = new conn();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    heading.Text = "Update Product";
                    productName.Text = Request.QueryString["name"];
                    update.Visible = true;
                    save.Visible = false;
                }
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            if(!CheckProductExists())
            {
                try
                {
                    SqlCommand sc = new SqlCommand("insert into productData(ProductName)values('" + productName.Text + "')", conn.GetSqlConnection());
                    sc.ExecuteNonQuery();

                    textMsg.Text = "Product Added Successfully.....";
                }
                catch (Exception em)
                {
                    Response.Write(em.Message);
                }
                finally
                {
                    c.CloseSqlConnection();
                }
            }
        }

        private bool CheckProductExists()
        {
            bool IsExists = false;
            SqlCommand cm = new SqlCommand("select ProductName from productData where ProductName= '" + productName.Text + "'", conn.GetSqlConnection());

            SqlDataReader sd = cm.ExecuteReader();
            sd.Read();
            if(sd.HasRows)
            {               
                IsExists = true;
                textMsg.Text = "Product Name already exists...";             
            }
            c.CloseSqlConnection();
            return IsExists;
        }

        protected void update_Click(object sender, EventArgs e)
        {
            if (!CheckProductExists())
            {
                try
                {
                    SqlCommand sc = new SqlCommand("update productData set ProductName='" + productName.Text + "'where ID='" + Request.QueryString["id"] + "'", conn.GetSqlConnection());

                    sc.ExecuteNonQuery();

                    textMsg.Text = "Product Updated Successfully.....";
                }
                catch (Exception em)
                {
                    Response.Write(em.Message);
                }
                finally
                {
                    c.CloseSqlConnection();
                }
            }
        }
                                                        
        protected void cancel_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Are you sure you want to cancel the operation", "Conformation Page", (MessageBoxButtons)MessageBoxButton.YesNo) == DialogResult.Yes)
            {
                Response.Redirect("products.aspx");
            }          
        }
    }
}