using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Templar.Contract;

namespace EmployeeManagementWidget.EmployeeManagementWidgets
{
    public partial class Logout : System.Web.UI.UserControl , IWidget
    {
        private string _login = ConfigurationManager.AppSettings["LoginPage"];
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["userId"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect(_login);
        }
        public void Init(IWidgetHost host)
        {

        }

        //This method called when a user clicks on settings icon in Templar designer
        //Here we simply hide the literal and show the settings
        public void ShowSettings()
        {

        }

        //This method is called when a user clicks on open settings in Templar designer
        //Here we hide the settings panel and show the literal 
        public void HideSettings()
        {

        }
    }
}