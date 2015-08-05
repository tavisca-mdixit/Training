using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Net;
using Newtonsoft.Json;
using System.Configuration;
using System.Web.Security;

namespace WebApplication1
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        private string _employeeManagementServiceUrl = ConfigurationManager.AppSettings["employeemanagementserviceurl"];
        private string _success = ConfigurationManager.AppSettings["Success"];
         private string _employeePage = ConfigurationManager.AppSettings["EmployeePage"];
         private string _hrPage = ConfigurationManager.AppSettings["HrPage"];
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
            HttpClient client = new HttpClient();
            var response = client.UploadData<Credentials, AuthenticatedEmployeeResponse>(_employeeManagementServiceUrl + "employee/credentials", credentials);
            if ( response.ResponseStatus.Code != _success)
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

                    Response.Redirect(_hrPage);
                }

                Response.Redirect(_employeePage);
            }
        }





    }
}