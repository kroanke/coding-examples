using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace gym
{
    public partial class signIn : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_register_Click(object sender, EventArgs e)
        {
            /*            Button login = (Button)FindControl("btn_login");
            */
            Response.Redirect("signUp.aspx", false);
            
        }
        protected void btn_login_Click(object sender, EventArgs e)
        {
            string constring = "Data Source = (local); Initial Catalog = user_DB; Integrated Security = True";

            SqlConnection connect = new SqlConnection(constring);

            TextBox txtMail = (TextBox)FindControl("txt_mail");
  
            TextBox txtPassword = (TextBox)FindControl("txt_password");

            try
            {
                if (connect.State == System.Data.ConnectionState.Closed)
                {
                    connect.Open();

                    string check_user_name = "SELECT userMail, userPassword FROM userTable WHERE ([userMail] = @userMail) AND ([userPassword] = @userPassword)";
                    SqlCommand check_username = new SqlCommand(check_user_name, connect);

                    check_username.Parameters.AddWithValue("@userMail", txtMail.Text);
                    check_username.Parameters.AddWithValue("@userPassword", txtPassword.Text);
                    
                    /*object UserExistObject = check_username.ExecuteScalar();
                    int UserExist = (int)(decimal)check_username.ExecuteScalar();*/
                    if (check_username.ExecuteScalar() != null)
                    {
                        HtmlMeta meta = new HtmlMeta();
                        meta.HttpEquiv = "Refresh";
                        meta.Content = "1;url=Homepage.aspx";
                        this.Page.Controls.Add(meta);
                        String myStringVariable = "Login Successful";
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);

         
                    }
                    else
                    {
                        Response.Write("<script>alert('Username or Password is wrong')</script>");

                    }





                    connect.Close();
                }




            }

            catch (Exception ex)
            {
                Response.Write("error: " + ex.ToString());
            }
        }
    }
}