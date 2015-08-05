using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm4 : System.Web.UI.Page
    {

        private string _login = ConfigurationManager.AppSettings["LoginPage"];
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["userId"].Expires = DateTime.Now.AddDays(-1); 
            Response.Redirect(_login);
        }
    }
}