using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                SqlCommand sc = new SqlCommand("insert into partyData(PartyName)values('" + partyName.Text + "')", con);
                con.Open();

                sc.ExecuteNonQuery();

                text.Text = "Party Added Successfully.....";

            } catch(Exception ex)
            {
                Response.Write(ex.Message);
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
                SqlCommand sc = new SqlCommand("update partyData set PartyName='" + partyName.Text+ "'where ID='" +Request.QueryString["id"]+ "'", con);
                con.Open();

                sc.ExecuteNonQuery();

                text.Text = "Party Updated Successfully.....";

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
            Response.Redirect("party.aspx");
        }
    }
}