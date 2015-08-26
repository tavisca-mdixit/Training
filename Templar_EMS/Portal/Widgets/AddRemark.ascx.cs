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
    public partial class AddRemark : System.Web.UI.UserControl ,IWidget
    {
        private string _success = ConfigurationManager.AppSettings["Success"];
        private string _logout = ConfigurationManager.AppSettings["LogoutPage"];
        private Dictionary<string, string> _empDictionary = new Dictionary<string, string>();
        private string _selectedEmployeeId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {

                var response = GetAllEmployeeResponse.getEmpList();
                if (response.ResponseStatus.Code != "200")
                {
                    ErrorMessage.Text = "Unable to process request";
                }
                else
                {
                    foreach (var employee in response.EmpList.OrderBy(sortedEmp => sortedEmp.FirstName))
                    {
                        _empDictionary.Add(employee.Id, employee.FirstName + "  " + employee.LastName);
                    }
                    DropDownListEmp.DataTextField = "Value";
                    DropDownListEmp.DataValueField = "Key";
                    DropDownListEmp.DataSource = _empDictionary;
                    DropDownListEmp.DataBind();
                }
            }
        }
        protected void SubmitRemark(object sender, EventArgs e)
        {
            _selectedEmployeeId = DropDownListEmp.SelectedValue;
            Remark remark = new Remark();
            string remarkText = EmpRemarkBox.Text;
            remark.Text = remarkText;
            remark.CreateTimeStamp = DateTime.UtcNow;
            var createdRemark = remark.createRemark(Session["employeeId"].ToString(), remark);
            if (createdRemark.ResponseStatus.Code != "200")
            {
                ErrorMessage.Text = "Unable to process Request";
            }
            else
            {
                ErrorMessage.Text = "Request processed suceesfully";
            }
        }
        public void RedirectToAddEmployee(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployee");

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