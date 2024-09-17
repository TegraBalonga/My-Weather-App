using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace My_Weather_App
{
    public partial class _Default : Page
    {
       
        SqlConnection sConnection = new SqlConnection(@"Data Source=DESKTOP-9A2QO06\MSSQL;Initial Catalog=Prog-POE;Integrated Security=True");
        HyperLink LogOff;

        string username, password;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUser.Visible = false;
            lblPass.Visible = false;
            txtUser.Visible = false;
            txtPass.Visible = false;
            lblError.Visible = false;
            btnLogIn.Visible = false;
            btnCancel.Visible = false;



             LogOff = (HyperLink)Page.Master.FindControl("hlLogOff");
            LogOff.Visible = false;
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            username = txtUser.Text;
            password = txtPass.Text;

            sConnection.Open();

            string sql = "SELECT * FROM USERS WHERE (USERNAME = @USER) AND (PASSWORD = @PASS)";
            
            SqlCommand checkUser = new SqlCommand(sql, sConnection);
            checkUser.Parameters.AddWithValue("@USER", username);
            checkUser.Parameters.AddWithValue("@PASS", password);


            SqlDataReader reader = checkUser.ExecuteReader();
            if (reader.HasRows)
            {
                //Username exist 
                sConnection.Close();
                
                LogOff.Visible = true;
                
                //var recoveryId = Guid.Parse(lbRecovery.SelectedValue);
                //var url = string.Format("{0}?RecoveryId={1}", @"../Recovery.aspx", vehicleId);

                //// Response.Redirect(url); // Old way

                //Response.Write("<script> window.open( '" + url + "','_blank' ); </script>");
                //Response.End();
                Response.Redirect("Weather.aspx?Parameter=" + username);
                

            }
            else
            {
                //Username doesn't exist.
                lblError.Visible = true;
                lblUser.Visible = true;
                lblPass.Visible = true;
                txtUser.Visible = true;
                txtPass.Visible = true;
                btnLogIn.Visible = true;
                btnCancel.Visible = true;
                sConnection.Close();
                
            }
        }

        protected void btnLog_Click(object sender, EventArgs e)
        {
            btnLog.Visible = false;
            lblUser.Visible = true;
            lblPass.Visible = true;
            txtUser.Visible = true;
            txtPass.Visible = true;
            btnLogIn.Visible = true;
            btnCancel.Visible = true;
        }
    }
}