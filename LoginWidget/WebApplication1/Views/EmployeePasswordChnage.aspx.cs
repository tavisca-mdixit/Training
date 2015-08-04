using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Configuration;

namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private string _employeeManagementServiceUrl = ConfigurationManager.AppSettings["employeemanagementserviceurl"];
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EmpChangePassword(object sender, EventArgs e)
        {
            EmpChangePassword passObj = new EmpChangePassword();
            
            passObj.OldPassword = OldPass.Text;
            passObj.NewPassword = NewPass.Text;
            passObj.EmployeeId = (string)Session["employeeId"];
            
            HttpClient client = new HttpClient();
            var response = client.UploadData<EmpChangePassword, ChangePasswordResponsecs>(_employeeManagementServiceUrl + "employee/changepassword",passObj );
            Message.Text = response.ResponseStatus.Message;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
        }
    }
}