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
                try
                {
                    SqlDataAdapter sda1 = new SqlDataAdapter("select * from partyData", conn.GetSqlConnection());
                    
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    ddl1.DataSource = dt1;
                    //ddl1.DataBind();
                    ddl1.DataTextField = "PartyName";
                    ddl1.DataValueField = "ID";
                    ddl1.DataBind();
                    ddl1.Items.Insert(0, new ListItem("Select Party", "0"));

                    SqlDataAdapter sda2 = new SqlDataAdapter("select * from productData", conn.GetSqlConnection());
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);
                    ddl2.DataSource = dt2;
                    //ddl2.DataBind();
                    ddl2.DataTextField = "ProductName";
                    ddl2.DataValueField = "ID";
                    ddl2.DataBind();
                    ddl2.Items.Insert(0, new ListItem("Select Product", "0"));

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
                        Label1.Text = "Update Assign";
                        SqlCommand scm = new SqlCommand("select partyID from assignPartyData where ID=" + Request.QueryString["id"] + "", conn.GetSqlConnection());
                        
                        SqlDataReader sdr = scm.ExecuteReader();
                        sdr.Read();
                        ddl1.SelectedItem.Value = sdr["partyID"].ToString();
                        ddl1.SelectedItem.Text = Request.QueryString["name1"];
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
                        SqlCommand scm1 = new SqlCommand("select productID from assignPartyData where ID=" + Request.QueryString["id"] + "", conn.GetSqlConnection());
                        
                        SqlDataReader sdr1 = scm1.ExecuteReader();
                        sdr1.Read();
                        ddl2.SelectedItem.Value = sdr1["productID"].ToString();
                        ddl2.SelectedItem.Text = Request.QueryString["name2"];                       
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
                }
            }     
        }

        protected void save_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sc = new SqlCommand("insert into assignPartyData(partyID, productID)values('" + Convert.ToInt32(ddl1.SelectedValue) + "','" + Convert.ToInt32(ddl2.SelectedValue) + "')", conn.GetSqlConnection());               
                                                       
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
                SqlCommand sc = new SqlCommand("update assignPartyData set partyID='" + Convert.ToInt32(ddl1.SelectedValue) + "', productID='" + Convert.ToInt32(ddl2.SelectedValue) + "'where ID='" + Request.QueryString["id"] + "'", conn.GetSqlConnection());
                
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
                Response.Redirect("assignParty.aspx");
            }           
        }
    }
}