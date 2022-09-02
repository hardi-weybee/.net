using System;
using System.Data.SqlClient;
using System.Data;
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
    public partial class addAssign : System.Web.UI.Page
    {
        conn c = new conn();
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
            {
                DisplayPartyProductDropDown();

                if (Request.QueryString["id"] != null)
                {
                    GetSelectedPartyName();
                    GetSelectedProductName();
                    update.Visible = true;
                    save.Visible = false;
                }
            }
        }

        private void DisplayPartyProductDropDown()
        {
            try
            {
                SqlDataAdapter sda1 = new SqlDataAdapter("select * from partyData", conn.GetSqlConnection());
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                DropDownListParty.DataSource = dt1;
                DropDownListParty.DataTextField = "PartyName";
                DropDownListParty.DataValueField = "ID";
                DropDownListParty.DataBind();
                DropDownListParty.Items.Insert(0, new ListItem("Select Party", "0"));


                SqlDataAdapter sda2 = new SqlDataAdapter("select * from productData", conn.GetSqlConnection());
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
            }
            finally
            {
                c.CloseSqlConnection();
            }
        }

        private void GetSelectedProductName()
        {
            try
            {
                SqlCommand scm1 = new SqlCommand("select productID from assignPartyData where ID=" + Request.QueryString["id"] + "", conn.GetSqlConnection());
                SqlDataReader sdr1 = scm1.ExecuteReader();
                sdr1.Read();
                DropDownListProduct.SelectedItem.Value = sdr1["productID"].ToString();
                DropDownListProduct.SelectedItem.Text = Request.QueryString["name2"];
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

        private void GetSelectedPartyName()
        {
            try
            {
                heading.Text = "Update Assign";
                SqlCommand scm = new SqlCommand("select partyID from assignPartyData where ID=" + Request.QueryString["id"] + "", conn.GetSqlConnection());
                SqlDataReader sdr = scm.ExecuteReader();
                sdr.Read();
                DropDownListParty.SelectedItem.Value = sdr["partyID"].ToString();
                DropDownListParty.SelectedItem.Text = Request.QueryString["name1"];
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

        protected void save_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sc = new SqlCommand("insert into assignPartyData(partyID, productID)values('" + Convert.ToInt32(DropDownListParty.SelectedValue) + "','" + Convert.ToInt32(DropDownListProduct.SelectedValue) + "')", conn.GetSqlConnection());
                sc.ExecuteNonQuery();
                textMsg.Text = "Added Successfully.....";
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
                SqlCommand sc = new SqlCommand("update assignPartyData set partyID='" + Convert.ToInt32(DropDownListParty.SelectedValue) + "', productID='" + Convert.ToInt32(DropDownListProduct.SelectedValue) + "'where ID='" + Request.QueryString["id"] + "'", conn.GetSqlConnection());                
                sc.ExecuteNonQuery();
                textMsg.Text = "Updated Successfully.....";
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
                Response.Redirect("assignParty.aspx");
            }           
        }
    }
}