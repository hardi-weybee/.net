using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Windows.Forms;
using System.Windows;
using System.Configuration;

namespace InvoiceApplication
{
    public partial class addProductRate : System.Web.UI.Page
    {
        conn c = new conn();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dttb.Text = DateTime.Today.ToString("yyyy-MM-dd");
               
                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter("select ID, ProductName from productData where ID not in (select productID from productRateData)", conn.GetSqlConnection());
                    
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    ddl1.DataSource = dt;
                    ddl1.DataTextField = "ProductName";
                    ddl1.DataValueField = "ID";
                    ddl1.DataBind();
                    ddl1.Items.Insert(0, new ListItem("Select Product", "0"));
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    c.CloseSqlConnection();
                }                

                if (Request.QueryString["id"] != null)
                {
                    try
                    {
                        Label1.Text = "Update Product Rate";
                        SqlCommand scm = new SqlCommand("select productID,Rate,DateOfRate from productRateData where ID=" + Request.QueryString["id"] + "", conn.GetSqlConnection());
                        
                        SqlDataReader sdr = scm.ExecuteReader();
                        sdr.Read();
                        ddl1.SelectedItem.Value = sdr["productID"].ToString();
                        ddl1.SelectedItem.Text = Request.QueryString["name1"];
                        productRate.Text = sdr["Rate"].ToString();
                        dttb.Text = sdr["DateOfRate"].ToString();
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                    finally
                    {
                        c.CloseSqlConnection();
                    }
                 
                    update.Visible = true;
                    save.Visible = false;
                    dttb.Visible = true;

                    try
                    {
                        SqlCommand cm = new SqlCommand("select format(DateOfRate, 'yyyy-MM-dd') as DateOfRate, Rate from productRateData where ID='" + Request.QueryString["id"] + "'", conn.GetSqlConnection());
                        
                        SqlDataReader sd = cm.ExecuteReader();
                        sd.Read();
                        dttb.Text = sd["DateOfRate"].ToString();
                        productRate.Text = sd["Rate"].ToString();
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

        protected void save_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sc = new SqlCommand("insert into productRateData(productID, Rate, DateOfRate)values('" + Convert.ToInt32(ddl1.SelectedValue) + "','" + productRate.Text + "','" + dttb.Text.ToString() + "')", conn.GetSqlConnection());
                
                sc.ExecuteNonQuery();

                text.Text = "Added Successfully.....";

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

        protected void update_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sc = new SqlCommand("update productRateData set productID='" + Convert.ToInt32(ddl1.SelectedValue) + "', Rate='" + productRate.Text + "', DateOfRate='" + dttb.Text.ToString() + "'where ID='" + Request.QueryString["id"] + "'", conn.GetSqlConnection());
                
                sc.ExecuteNonQuery();

                text.Text = "Updated Successfully.....";

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

        protected void cancel_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Are you sure you want to cancel the operation", "Conformation Page", (MessageBoxButtons)MessageBoxButton.YesNo) == DialogResult.Yes)
            {
                Response.Redirect("productRate.aspx");
            }          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {           
            dt.Visible = true;
        }

        protected void dt_SelectionChanged(object sender, EventArgs e)
        {
            dttb.Visible = true;
            dttb.Text = dt.SelectedDate.ToString("yyyy-MM-dd");
            dt.Visible = false;
        }
    }
}