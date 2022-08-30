using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceApplication
{
    public partial class addAssign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             
                SqlConnection con = null;
                try
                {
                    con = new SqlConnection("data source=DESKTOP-SUG1Q46; database=invoice; integrated security=SSPI");
                    SqlDataAdapter sda1 = new SqlDataAdapter("select * from partyData", con);
                    con.Open();
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    ddl1.DataSource = dt1;
                    //ddl1.DataBind();
                    ddl1.DataTextField = "PartyName";
                    ddl1.DataValueField = "ID";
                    ddl1.DataBind();
                    ddl1.Items.Insert(0, new ListItem("Select Party", "0"));

                    SqlDataAdapter sda2 = new SqlDataAdapter("select * from productData", con);
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
                    con.Close();
                }
                if (Request.QueryString["id"] != null)
                {
                    try
                    {
                        Label1.Text = "Update Assign";
                        string com2 = "select productID from assignPartyData where ID=" + Request.QueryString["id"] + "";
                        SqlCommand scm = new SqlCommand(com2, con);
                        con.Open();
                        SqlDataReader sdr = scm.ExecuteReader();
                        sdr.Read();
                        ddl2.SelectedItem.Value = sdr["productID"].ToString();
                        ddl2.SelectedItem.Text = Request.QueryString["name2"];
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);

                    }
                    finally
                    {
                        con.Close();
                    }
                    try
                    {
                        string com3 = "select partyID from assignPartyData where ID=" + Request.QueryString["id"] + "";
                        SqlCommand scm1 = new SqlCommand(com3, con);
                        con.Open();
                        SqlDataReader sdr1 = scm1.ExecuteReader();
                        sdr1.Read();
                        ddl1.SelectedItem.Value = sdr1["partyID"].ToString();
                        ddl1.SelectedItem.Text = Request.QueryString["name1"];
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
                }
            }     
        }

        protected void save_Click(object sender, EventArgs e)
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=DESKTOP-SUG1Q46; database=invoice; integrated security=SSPI");
                SqlCommand sc = new SqlCommand("insert into assignPartyData(partyID, productID)values('" + Convert.ToInt32(ddl1.SelectedValue) + "','" + Convert.ToInt32(ddl2.SelectedValue) + "')", con);
                
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
                SqlCommand sc = new SqlCommand("update assignPartyData set partyID='" + Convert.ToInt32(ddl1.SelectedValue) + "', productID='" + Convert.ToInt32(ddl2.SelectedValue) + "'where ID='" + Request.QueryString["id"] + "'", con);
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
            Response.Redirect("assignParty.aspx");
        }
    }
}