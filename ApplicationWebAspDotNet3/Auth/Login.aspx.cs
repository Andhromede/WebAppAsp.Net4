using MySql.Data.MySqlClient;
using System;
using System.Web.Security;
/*using System.Web.UI;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;*/


namespace ApplicationWebAspDotNet3.Auth
{
    public partial class Login : System.Web.UI.Page
    {
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string login = TxtLogin.Text;
            string password = TxtPassword.Text;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT password, Id_Role, login FROM users WHERE login = @login AND is_active = 1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@login", login);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader["password"].ToString();
                            bool passwordMatch = BCrypt.Net.BCrypt.Verify(password, storedHash);

                            if (passwordMatch)
                            {
                                // Utilisateur est authentifié
                                FormsAuthentication.SetAuthCookie(login, false);

                                // Stocker des informations dans la session
                                Session["login"] = login;
                                Session["role"] = reader["Id_Role"].ToString();

                                if (Session["login"] != null)
                                {
                                    Response.Write("Session créée avec succès.");
                                }
                                else
                                {
                                    Response.Write("Erreur dans la création de la session.");
                                }

                                Response.Redirect("~/Default.aspx");
                            }
                            else
                            {
                                Response.Write("Mot de passe incorrect.");
                            }
                        }
                        else
                        {
                            Response.Write("Login incorrect.");
                        }
                    }
                }
            }
        }
    }
}