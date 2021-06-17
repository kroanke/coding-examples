using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace gym
{
    public partial class signUp : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            
            
                
                
            
        }
        protected void btn_register_Click(object sender, EventArgs e)
        {
            string constring = "Data Source = (local); Initial Catalog = user_DB; Integrated Security = True";

            SqlConnection connect = new SqlConnection(constring);

            TextBox txtUsername = (TextBox)FindControl("txt_Username");
            TextBox txtSurname = (TextBox)FindControl("txt_surname");
            TextBox txtMail = (TextBox)FindControl("txt_mail");
            TextBox txtPassword = (TextBox)FindControl("txt_password");

            try
            {
                if (connect.State == System.Data.ConnectionState.Closed)
                {
                    connect.Open();

                    string insertQuery = "insert into userTable(userName,userSurname,userMail,userPassword)values (@userName,@userSurname,@userMail,@userPassword)";
                    SqlCommand cmd = new SqlCommand(insertQuery, connect);
                    cmd.Parameters.AddWithValue("@userName", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@userSurname", txtSurname.Text);
                    cmd.Parameters.AddWithValue("@userMail", txtMail.Text);
                    cmd.Parameters.AddWithValue("@userPassword", txtPassword.Text);
                    cmd.ExecuteNonQuery();

                    HtmlMeta meta = new HtmlMeta();
                    meta.HttpEquiv = "Refresh";
                    meta.Content = "1;url=signIn.aspx";
                    this.Page.Controls.Add(meta);
                    String myStringVariable = "Successfully Registered";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);

                    connect.Close();
                }
                


                
            }

            catch (Exception ex)
            {
                Response.Write("This mail is already in use. Please Try a different one");
            }
        }

    }
    
}