using Model;
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
    public partial class AddEmployee : System.Web.UI.UserControl , IWidget
    {
        private string _success = ConfigurationManager.AppSettings["Success"];
      
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SubmitEmployee(object sender, EventArgs e)
        {

            Employee employee = new Employee();
            employee.FirstName = FirstName.Text;
            employee.LastName = LastName.Text;
            employee.Title = EmpTitle.Text;
            employee.Email = Email.Text;
            employee.Phone = Phone.Text;
            employee.JoiningDate = DateTime.Parse(DOJ.Text);

            var createdEmployee = employee.createEmployee();
            if (createdEmployee.ResponseStatus.Code != "200")
            {
                ErrorMessageEmployee.Text = "Unable to process Request";
            }
            else
            {
                ErrorMessageEmployee.Text = "Request processed suceesfully";
            }

        }
        public void RedirectToAddRemark(object sender, EventArgs e)
        {
            Response.Redirect("AddRemark");
        
        }
        public void RedirectToChangePassword(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword");

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logout");
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