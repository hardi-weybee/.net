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
                answer.Visible = false;
                GrandTotal.Visible = false;

                try
                {
                    SqlDataAdapter sda1 = new SqlDataAdapter("select distinct pa.ID, pa.PartyName from partyData pa, productData pd, assignPartyData apd where apd.productID = pd.ID and apd.partyID = pa.ID", conn.GetSqlConnection());
                    
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    DropDownListParty.DataSource = dt1;
                    DropDownListParty.DataTextField = "PartyName";
                    DropDownListParty.DataValueField = "ID";
                    DropDownListParty.DataBind();
                    DropDownListParty.Items.Insert(0, new ListItem("Select Party", "0"));
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

        

        protected void DropDownListParty_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter sda2 = new SqlDataAdapter("select pd.ID, pd.ProductName from productData pd, assignPartyData asd, productRateData prd where asd.partyID ="+ DropDownListParty.SelectedItem.Value+" and pd.ID = asd.productID and pd.ID = prd.productID", conn.GetSqlConnection());
                
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                DropDownListProduct.DataSource = dt2;
                DropDownListProduct.DataTextField = "ProductName";
                DropDownListProduct.DataValueField = "ID";
                DropDownListProduct.DataBind();
                DropDownListProduct.Items.Insert(0, new ListItem("Select Product", "0"));                
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            } finally
            {
                c.CloseSqlConnection();
            }
        }

        protected void DropDownListProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cm = new SqlCommand("select Rate from productRateData where productID=" + DropDownListProduct.SelectedItem.Value + "", conn.GetSqlConnection());
                
                SqlDataReader sd = cm.ExecuteReader();
                sd.Read();

                RateTB.Text = sd["Rate"].ToString();
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

        protected void AddInvoiceBtn_Click(object sender, EventArgs e)
        {
            answer.Visible = true;
            GrandTotal.Visible = true;
            InsertToInvoice();
            DisplayInvoice();
            DoTotal();
        }

        private void DoTotal()
        {
            try
            {
                SqlCommand cm = new SqlCommand("select sum(Total) as res from invoice where partyID ='" + DropDownListParty.SelectedItem.Value + "'", conn.GetSqlConnection());

                SqlDataReader sd = cm.ExecuteReader();
                sd.Read();

                answer.Text = sd["res"].ToString();
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

        private void DisplayInvoice()
        {
            try
            {
                SqlDataAdapter sde = new SqlDataAdapter("select i.ID as ID, PartyName, ProductName , RateOfProduct, Quantity, Total from invoice i, partyData pa, productData pr where pa.ID =i.partyID  and pr.ID = i.productID and i.partyID=" + DropDownListParty.SelectedItem.Value + "", conn.GetSqlConnection());
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
        }

        private void InsertToInvoice()
        {
            try
            {
                SqlCommand cm = new SqlCommand("insert into invoice(partyID, productID, RateOfProduct, Quantity, Total)values('" + Convert.ToInt32(DropDownListParty.SelectedValue) + "','" + Convert.ToInt32(DropDownListProduct.SelectedValue) + "','" + RateTB.Text + "','" + TextBox4.Text + "','" + (Convert.ToInt32(RateTB.Text) * Convert.ToInt32(TextBox4.Text)) + "')", conn.GetSqlConnection());
                cm.ExecuteNonQuery();
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

        protected void CloseInvoiceBtn_Click(object sender, EventArgs e)
        {           
            Response.Redirect("invoice.aspx");            
        }
    }
}