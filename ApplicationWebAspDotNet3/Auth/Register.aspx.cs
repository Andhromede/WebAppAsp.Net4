using System;
using MySql.Data.MySqlClient;
using System.Web.UI;

namespace ApplicationWebAspDotNet3
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsAjaxRequest())
            {
                CheckLoginOrEmailAvailability();
                Response.End();
            }
        }

        protected void RegisterButton_Click(Object sender, EventArgs e)
        {
            string login = Login.Text;
            string email = Email.Text;
            string password = Password.Text;
            string confirmPassword = ConfirmPassword.Text;

            if (!InputsAreValid(login, email, password, confirmPassword))
            {
                return;
            }

            if (UserExists(login) || UserExists(email))
            {
                Response.Write("Taken");
                return;
            }

            CreateUser(login, email, password);
            Response.Redirect("~/Default.aspx");
        }

        private bool InputsAreValid(string login, string email, string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                Response.Write("Tous les champs doivent être remplis.");
                return false;
            }

            if (password != confirmPassword)
            {
                Response.Write("Les mots de passe ne correspondent pas.");
                return false;
            }

            return true;
        }

        private bool UserExists(string identifier)
        {
            using (var connection = GetConnection())
            {
                string query = "SELECT COUNT(*) FROM users WHERE login = @identifier OR email = @identifier";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@identifier", identifier);
                    int exists = Convert.ToInt32(cmd.ExecuteScalar());
                    return exists > 0;
                }
            }
        }

        private void CreateUser(string login, string email, string password)
        {
            using (var connection = GetConnection())
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                string query = "INSERT INTO users (login, email, password) VALUES (@login, @email, @hashedPassword)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@login", login ?? string.Empty);
                    cmd.Parameters.AddWithValue("@email", email ?? string.Empty);
                    cmd.Parameters.AddWithValue("@hashedPassword", hashedPassword ?? string.Empty);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private MySqlConnection GetConnection()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        private bool IsAjaxRequest()
        {
            return Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

        protected void CheckLoginOrEmailAvailability()
        {
            string loginOrEmail = Request.QueryString["identifier"];

            if (UserExists(loginOrEmail))
            {
                Response.Clear();
                Response.ContentType = "text/plain";
                Response.Write("Taken");
            }
            else
            {
                Response.Clear();
                Response.ContentType = "text/plain";
                Response.Write("NotTaken");
            }
        }

    }
}
