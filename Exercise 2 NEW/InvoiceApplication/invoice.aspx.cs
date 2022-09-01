using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace InvoiceApplication
{
    public partial class invoice : System.Web.UI.Page
    {
        conn c = new conn();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Label2.Visible = false;
                grd.Visible = false;

                try
                {
                    SqlDataAdapter sda1 = new SqlDataAdapter("select distinct pa.ID, pa.PartyName from partyData pa, productData pd, assignPartyData apd where apd.productID = pd.ID and apd.partyID = pa.ID", conn.GetSqlConnection());
                    
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    ddl1.DataSource = dt1;
                    ddl1.DataTextField = "PartyName";
                    ddl1.DataValueField = "ID";
                    ddl1.DataBind();
                    ddl1.Items.Insert(0, new ListItem("Select Party", "0"));
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

        

        protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter sda2 = new SqlDataAdapter("select pd.ID, pd.ProductName from productData pd, assignPartyData asd, productRateData prd where asd.partyID ="+ddl1.SelectedItem.Value+" and pd.ID = asd.productID and pd.ID = prd.productID", conn.GetSqlConnection());
                
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                ddl2.DataSource = dt2;
                ddl2.DataTextField = "ProductName";
                ddl2.DataValueField = "ID";
                ddl2.DataBind();
                ddl2.Items.Insert(0, new ListItem("Select Product", "0"));                
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            } finally
            {
                c.CloseSqlConnection();
            }
        }

        protected void ddl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cm = new SqlCommand("select Rate from productRateData where productID=" + ddl2.SelectedItem.Value + "", conn.GetSqlConnection());
                
                SqlDataReader sd = cm.ExecuteReader();
                sd.Read();

                TextBox3.Text = sd["Rate"].ToString();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label2.Visible = true;
            grd.Visible = true;
            try
            {
                SqlCommand cm = new SqlCommand("insert into invoice(partyID, productID, RateOfProduct, Quantity, Total)values('" + Convert.ToInt32(ddl1.SelectedValue) + "','" + Convert.ToInt32(ddl2.SelectedValue) + "','" +TextBox3.Text+ "','" + TextBox4.Text+ "','" +(Convert.ToInt32(TextBox3.Text)*Convert.ToInt32(TextBox4.Text))+ "')", conn.GetSqlConnection());
                
                cm.ExecuteNonQuery();
            } catch(Exception ex)
            {
                Response.Write(ex.Message);
            } finally
            {
                c.CloseSqlConnection();
            }

            try
            {
                SqlDataAdapter sde = new SqlDataAdapter("select i.ID as ID, PartyName, ProductName , RateOfProduct, Quantity, Total from invoice i, partyData pa, productData pr where pa.ID =i.partyID  and pr.ID = i.productID and i.partyID="+ddl1.SelectedItem.Value+"" , conn.GetSqlConnection());
                DataSet ds = new DataSet();
                sde.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                c.CloseSqlConnection();
            }

            try
            {
                SqlCommand cm = new SqlCommand("select sum(Total) as res from invoice where partyID ='"+ddl1.SelectedItem.Value+"'", conn.GetSqlConnection());
                
                SqlDataReader sd = cm.ExecuteReader();
                sd.Read();

                Label2.Text = sd["res"].ToString();
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

        protected void Button2_Click(object sender, EventArgs e)
        {           
            Response.Redirect("invoice.aspx");            
        }
    }
}