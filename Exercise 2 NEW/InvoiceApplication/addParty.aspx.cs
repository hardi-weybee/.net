using System;
using System.Data.SqlClient;
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
    public partial class addParty : System.Web.UI.Page
    {
        conn c = new conn();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
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
            if (!CheckPartyExists())
            {
                try
                {
                    SqlCommand sc = new SqlCommand("insert into partyData(PartyName)values('" + partyName.Text + "')", conn.GetSqlConnection());

                    sc.ExecuteNonQuery();

                    text.Text = "Party Added Successfully.....";
                }
                catch (Exception em)
                {
                    Response.Write(em.Message);
                }
                finally
                {
                    c.CloseSqlConnection();
                }
            }
        }

        private bool CheckPartyExists()
        {
            bool IsExists = false;
            SqlCommand cm = new SqlCommand("select PartyName from partyData where PartyName= '" + partyName.Text + "'", conn.GetSqlConnection());

            SqlDataReader sd = cm.ExecuteReader();
            sd.Read();
            if (sd["PartyName"].ToString() != null)
            {
                IsExists = true;
                text.Text = "Party Name already exists... Please add other party";
            }
            return IsExists;
        }

        protected void update_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cm = new SqlCommand("select PartyName from partyData where PartyName= '" + partyName.Text + "'", conn.GetSqlConnection());

                SqlDataReader sd = cm.ExecuteReader();
                sd.Read();
                if (sd["PartyName"].ToString() != null)
                {
                    text.Text = "Party Name already There... Cannot update";
                }
            }
            catch (Exception ex)
            {
                try
                {
                    SqlCommand sc = new SqlCommand("update partyData set PartyName='" + partyName.Text + "'where ID='" + Request.QueryString["id"] + "'", conn.GetSqlConnection());

                    sc.ExecuteNonQuery();

                    text.Text = "Party Updated Successfully.....";
                }
                catch (Exception em)
                {
                    Response.Write(em.Message);
                }
                finally
                {
                    c.CloseSqlConnection();
                }
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
                Response.Redirect("party.aspx");
            }
        }
    }
}