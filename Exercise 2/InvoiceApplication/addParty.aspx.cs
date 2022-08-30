using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows;

namespace InvoiceApplication
{
    public partial class addParty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.QueryString["id"] != null)
                {
                    Label1.Text = "Update Party";
                    partyName.Text = Request.QueryString["name"];
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
                SqlCommand cm = new SqlCommand("select PartyName from partyData where PartyName= '" + partyName.Text + "'", con);
                con.Open();
                SqlDataReader sd = cm.ExecuteReader();
                sd.Read();
                if (sd["PartyName"].ToString() != null)
                {
                    text.Text = "Party Name already exists... Please add other product";
                }
            } catch(Exception ex)
            {
                try
                {
                    con = new SqlConnection("data source=DESKTOP-SUG1Q46; database=invoice; integrated security=SSPI");
                    SqlCommand sc = new SqlCommand("insert into partyData(PartyName)values('" + partyName.Text + "')", con);
                    con.Open();
                    sc.ExecuteNonQuery();

                    text.Text = "Party Added Successfully.....";
                }
                catch (Exception em)
                {
                    Response.Write(em.Message);
                }
                finally
                {
                    con.Close();
                }
            } finally
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
                SqlCommand cm = new SqlCommand("select PartyName from partyData where PartyName= '" + partyName.Text + "'", con);
                con.Open();
                SqlDataReader sd = cm.ExecuteReader();
                sd.Read();
                if (sd["PartyName"].ToString() != null)
                {
                    text.Text = "Party Name already There... Cannot update";
                }
            } catch(Exception ex)
            {
                try
                {
                    con = new SqlConnection("data source=DESKTOP-SUG1Q46; database=invoice; integrated security=SSPI");
                    SqlCommand sc = new SqlCommand("update partyData set PartyName='" + partyName.Text + "'where ID='" + Request.QueryString["id"] + "'", con);
                    con.Open();
                    sc.ExecuteNonQuery();

                    text.Text = "Party Updated Successfully.....";
                }
                catch (Exception em)
                {
                    Response.Write(em.Message);
                }
                finally
                {
                    con.Close();
                }
            } finally
            {
                con.Close();
            }           
        } 

        protected void cancel_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Are you sure you want to cancel the operation", "Conformation Page", (MessageBoxButtons)MessageBoxButton.YesNo) == DialogResult.Yes)
            {
                Response.Redirect("party.aspx");               
            }
        }
    }
}