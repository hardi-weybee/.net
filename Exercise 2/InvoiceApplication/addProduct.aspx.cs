using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceApplication
{
    public partial class addProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    Label1.Text = "Update Product";
                    productName.Text = Request.QueryString["name"];
                    update.Visible = true;
                    save.Visible = false;
                }
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
              
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=DESKTOP-SUG1Q46; database=invoice; integrated security=SSPI");
                SqlCommand cm = new SqlCommand("select ProductName from productData where ProductName= '"+ productName.Text + "'", con);
                con.Open();
                SqlDataReader sd = cm.ExecuteReader();
                sd.Read();
                if(sd["ProductName"].ToString() != null)
                {
                    text.Text = "Product Name already exists... Please add other product";
                   
                }             
            }
            catch (Exception ex)
            {
                try
                {
                    con.Close();
                    con = new SqlConnection("data source=DESKTOP-SUG1Q46; database=invoice; integrated security=SSPI");
                    SqlCommand sc = new SqlCommand("insert into productData(ProductName)values('" + productName.Text + "')", con);
                    con.Open();
                    sc.ExecuteNonQuery();

                    text.Text = "Product Added Successfully.....";
                } catch(Exception em)
                {
                    Response.Write(em.Message);
                } finally
                {
                    con.Close();
                }
            }
            finally
            {   
                con.Close();
            }
        }
      
        protected void update_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=DESKTOP-SUG1Q46; database=invoice; integrated security=SSPI");
                SqlCommand cm = new SqlCommand("select ProductName from productData where ProductName= '" + productName.Text + "'", con);
                con.Open();
                SqlDataReader sd = cm.ExecuteReader();
                sd.Read();
                if (sd["ProductName"].ToString() != null)
                {
                    text.Text = "Product Name already There... Cannot update";
                }               
            }
            catch (Exception ex)
            {
                try
                {
                    con = new SqlConnection("data source=DESKTOP-SUG1Q46; database=invoice; integrated security=SSPI");
                    SqlCommand sc = new SqlCommand("update productData set ProductName='" + productName.Text + "'where ID='" + Request.QueryString["id"] + "'", con);
                    con.Open();

                    sc.ExecuteNonQuery();

                    text.Text = "Product Updated Successfully.....";
                } catch(Exception em)
                {
                    Response.Write(em.Message);
                } finally
                {
                    con.Close();
                }               
            }
            finally
            {
                con.Close();
            }
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("products.aspx");
        }
    }
}