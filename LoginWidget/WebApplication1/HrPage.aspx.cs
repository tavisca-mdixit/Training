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
namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string _employeeServiceUrl = ConfigurationManager.AppSettings["employeeserviceurl"];
        private string _employeeManagementServiceUrl = ConfigurationManager.AppSettings["employeemanagementserviceurl"];
        private string _success = ConfigurationManager.AppSettings["Success"];
        private string _logout = ConfigurationManager.AppSettings["LogoutPage"];
        private Dictionary<string, string> _empDictionary = new Dictionary<string, string>();
        private string _selectedEmployeeId;
        HttpClient client = new HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
               
                var response = client.GetData<GetAllEmployeeResponse>(_employeeServiceUrl + "employee");
                if (response.ResponseStatus.Code != _success)
                {
                    ErrorMessage.Text = "Unable to process request";
                }
                else
                {
                    foreach (var employee in response.EmpList)
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

        protected void SubmitEmployee(object sender, EventArgs e)
        {

            Employee employee = new Employee();
            employee.FirstName = FirstName.Text;
            employee.LastName = LastName.Text;
            employee.Title = EmpTitle.Text;
            employee.Email = Email.Text;
            employee.Phone = Phone.Text;
            employee.JoiningDate =DateTime.Parse( DOJ.Text);

            var createdEmployee = client.UploadData<Employee,CreatedEmployeeResponse>(_employeeManagementServiceUrl + "employee", employee);
            if (createdEmployee.ResponseStatus.Code != _success)
            {
                ErrorMessageEmployee.Text = "Unable to process Request";
            }
            else
            {
                ErrorMessageEmployee.Text = "Request processed suceesfully";
            }

        }

        protected void SubmitRemark(object sender, EventArgs e)
        {
            _selectedEmployeeId = DropDownListEmp.SelectedValue;
            Remark remark = new Remark();
            string remarkText = EmpRemarkBox.Text;
            remark.Text = remarkText;
            remark.CreateTimeStamp = DateTime.UtcNow;
            var createdRemark = client.UploadData<Remark, CreatedRemarkResponse>(_employeeManagementServiceUrl + "employee/" + _selectedEmployeeId + "/remark", remark);
            if (createdRemark.ResponseStatus.Code != _success)
            {
                ErrorMessage.Text = "Unable to process Request";
            }
            else
            {
                ErrorMessage.Text = "Request processed suceesfully";
            }
        }

        protected void EmpChangePassword(object sender, EventArgs e)
        {
            EmpChangePassword passObj = new EmpChangePassword();

            passObj.OldPassword = OldPass.Text;
            passObj.NewPassword = NewPass.Text;
            passObj.EmployeeId = (string)Session["employeeId"];

            var response = client.UploadData<EmpChangePassword, ChangePasswordResponsecs>(_employeeManagementServiceUrl + "employee/changepassword", passObj);
            if (response.ResponseStatus.Code != _success)
            {
                Message.Text = "Unable to process Request";
            }
            else
            {
                Message.Text = "Request processed suceesfully";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect(_logout);
        }
    }
}