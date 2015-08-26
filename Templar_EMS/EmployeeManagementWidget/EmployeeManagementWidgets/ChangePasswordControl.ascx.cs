using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Templar.Contract;

namespace EmployeeManagementWidget
{
    public partial class ChangePasswordControl : System.Web.UI.UserControl , IWidget
    {

       
        private string _logout = ConfigurationManager.AppSettings["LogoutPage"];
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EmpChangePassword(object sender, EventArgs e)
        {
            EmpChangePassword passObj = new EmpChangePassword();

            passObj.OldPassword = OldPass.Text;
            passObj.NewPassword = NewPass.Text;
            passObj.EmployeeId = (string)Session["employeeId"];

            var response = passObj.changePassword();
            Message.Text = response.ResponseStatus.Message;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logout");
        }
        public void RedirectToAddRemark(object sender, EventArgs e)
        {
            Response.Redirect("AddRemark");

        }
        public void RedirectToAddEmployee(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployee");

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