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
        Dictionary<string, string> empDictionary = new Dictionary<string, string>();
        private string _selectedEmployeeId;
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["employeeTitle"]==null || (string.Equals((Session["employeeTitle"].ToString()).Trim() , "Hr", StringComparison.OrdinalIgnoreCase))==false  ) 
            //{
            //Response.Redirect("http://localhost:58084/Account/Login.aspx");
            
            //}

            if (Page.IsPostBack == false)
            {
                var client = new HttpClient();
                var response = client.GetData<GetAllEmployeeResponse>(_employeeServiceUrl + "employee");
                if (response.ResponseStatus.Code != "200")
                {
                    ErrorMessage.Text = response.ResponseStatus.Message;


                }
                else
                {
                    foreach (var employee in response.EmpList)
                    {
                        empDictionary.Add(employee.Id, employee.FirstName + "  " + employee.LastName);
                    }
                    DropDownListEmp.DataTextField = "Value";
                    DropDownListEmp.DataValueField = "Key";
                    DropDownListEmp.DataSource = empDictionary;
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
            HttpClient client = new HttpClient();
            var createdEmployee = client.UploadData<Employee,CreatedEmployeeResponse>(_employeeManagementServiceUrl + "employee", employee);
            ErrorMessage.Text = createdEmployee.ResponseStatus.Message;
           

        }

        protected void SubmitRemark(object sender, EventArgs e)
        {
            _selectedEmployeeId = DropDownListEmp.SelectedValue;
            Remark remark = new Remark();
            string remarkText = EmpRemarkBox.Text;
            remark.Text = remarkText;
            remark.CreateTimeStamp = DateTime.UtcNow;
            HttpClient client = new HttpClient();
            var createdRemark = client.UploadData<Remark, CreatedRemarkResponse>(_employeeManagementServiceUrl + "employee/" + _selectedEmployeeId + "/remark", remark);
            ErrorMessageEmployee.Text = createdRemark.ResponseStatus.Message;


        }

        protected void EmpChangePassword(object sender, EventArgs e)
        {
            EmpChangePassword passObj = new EmpChangePassword();

            passObj.OldPassword = OldPass.Text;
            passObj.NewPassword = NewPass.Text;
            passObj.EmployeeId = (string)Session["employeeId"];

            HttpClient client = new HttpClient();
            var response = client.UploadData<EmpChangePassword, ChangePasswordResponsecs>(_employeeManagementServiceUrl + "employee/changepassword", passObj);
            Message.Text = response.ResponseStatus.Message;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
        }
    }
}