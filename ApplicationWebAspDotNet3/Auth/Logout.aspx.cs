using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApplicationWebAspDotNet3.Auth
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Efface toutes les informations de session
            Session.Clear();
            Session.Abandon();

            // Supprime le cookie d'authentification
            FormsAuthentication.SignOut();

            // Redirige l'utilisateur vers la page de connexion ou la page d'accueil
            Response.Redirect("~/Default.aspx");
        }

    }
}