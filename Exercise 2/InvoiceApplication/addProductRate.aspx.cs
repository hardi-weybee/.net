using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace InvoiceApplication
{
    public partial class addProductRate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dttb.Text = DateTime.Today.ToString("yyyy-MM-dd");
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=DESKTOP-SUG1Q46; database=invoice; integrated security=SSPI");
                    SqlDataAdapter sda = new SqlDataAdapter("select ID, ProductName from productData where ID not in (select productID from productRateData)", con);
                    con.Open();
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
                    con.Close();
                }                

                if (Request.QueryString["id"] != null)
                {
                    try
                    {
                        Label1.Text = "Update Product Rate";
                        string com2 = "select productID,Rate,DateOfRate from productRateData where ID=" + Request.QueryString["id"] + "";
                        SqlCommand scm = new SqlCommand(com2, con);
                        con.Open();
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
                        con.Close();
                    }
                 
                    update.Visible = true;
                    save.Visible = false;
                    dttb.Visible = true;

                    try
                    {
                        //con = new SqlConnection("data source=DESKTOP-SUG1Q46; database=invoice; integrated security=SSPI");
                        SqlCommand cm = new SqlCommand("select DateOfRate, Rate from productRateData where ID='" + Request.QueryString["id"] + "'", con);
                        con.Open();
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
                        con.Close();
                    }
                }
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=DESKTOP-SUG1Q46; database=invoice; integrated security=SSPI");
                SqlCommand sc = new SqlCommand("insert into productRateData(productID, Rate, DateOfRate)values('" + Convert.ToInt32(ddl1.SelectedValue) + "','" + productRate.Text + "','" + dttb.Text.ToString() + "')", con);
                con.Open();

                sc.ExecuteNonQuery();

                text.Text = "Added Successfully.....";

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

        protected void update_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=DESKTOP-SUG1Q46; database=invoice; integrated security=SSPI");
                SqlCommand sc = new SqlCommand("update productRateData set productID='" + Convert.ToInt32(ddl1.SelectedValue) + "', Rate='" + productRate.Text + "', DateOfRate='" + dttb.Text.ToString() + "'where ID='" + Request.QueryString["id"] + "'", con);
                con.Open();

                sc.ExecuteNonQuery();

                text.Text = "Updated Successfully.....";

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

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("productRate.aspx");
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