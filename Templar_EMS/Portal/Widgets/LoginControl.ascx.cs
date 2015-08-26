using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Templar.Contract;

namespace EmployeeManagementWidget
{
    public partial class LoginControl : System.Web.UI.UserControl,IWidget
    {
        private string _success = ConfigurationManager.AppSettings["Success"];
        private string _employeePage = ConfigurationManager.AppSettings["EmployeePage"];
        private string _remPage = ConfigurationManager.AppSettings["AddRemark"];
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Rememberpassword_CheckedChanged(object sender, EventArgs e)
        {

        }
        protected void Login(object sender, EventArgs e)
        {

            Credentials credentials = new Credentials();
            credentials.UserName = TextBox1.Text;
            credentials.Password = TextBox2.Text;

            var response = credentials.CheckCreds(credentials);


            if (response.ResponseStatus.Code != "200")
            {
                Message.Text = "Login Failed";
            }
            else
            {
                FormsAuthentication.SetAuthCookie(response.AuthenticatedEmployee.Email, false);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, response.AuthenticatedEmployee.Email, DateTime.UtcNow, DateTime.UtcNow.AddMinutes(10), false, response.AuthenticatedEmployee.Title.ToLower());
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                Response.Cookies.Add(cookie);

                Session["employeeId"] = response.AuthenticatedEmployee.Id;
                Session["employeeTitle"] = response.AuthenticatedEmployee.Title;

                if (string.Equals(Session["employeeTitle"].ToString(), "Hr", StringComparison.OrdinalIgnoreCase))
                {

                    Response.Redirect("AddRemark");
                }

                Response.Redirect("ShowRemarks");
            }
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