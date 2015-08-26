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
    public partial class ShowRemarksControl : System.Web.UI.UserControl, IWidget
    {
        private string _loginPage = ConfigurationManager.AppSettings["LoginPage"];
        private string _changePasswordPage = ConfigurationManager.AppSettings["ChangePassword"];
        private string _addEmpPage = ConfigurationManager.AppSettings["AddEmployee"];

        private string _success = ConfigurationManager.AppSettings["Success"];
        private string _logout = ConfigurationManager.AppSettings["LogoutPage"];
        HttpClient client = new HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                var countResponse = GetRemarkCountResponse.getCount(Session["employeeId"].ToString());
                int count;
                Int32.TryParse(countResponse.Count, out count);
                EmpGridView.VirtualItemCount = count;
                var remarkResponse = GetRemarkResponse.getRemark(Session["employeeId"].ToString(), EmpGridView.PageIndex + 1);
                if (remarkResponse.ResponseStatus.Code != _success)
                {
                    NoRemarkLabel.Text = "Unable to process request";
                }
                else
                {
                    EmpGridView.DataSource = remarkResponse.RequestedRemark;
                    EmpGridView.DataBind();
                }
                EmpGridView.DataBind();

            }
        }

        protected void EmpGridView_SelectedIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EmpGridView.PageIndex = e.NewPageIndex;
            var response = GetRemarkResponse.getRemark(Session["employeeId"].ToString(), EmpGridView.PageIndex + 1);
            if (response.ResponseStatus.Code != _success)
            {
                NoRemarkLabel.Text = "Unable to process request";

            }
            else
            {
                EmpGridView.DataSource = response.RequestedRemark;
                EmpGridView.DataBind();
            }
        }



        protected void RedirectToChangePassword(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword");
        }
       
        protected void RedirectToLogout(object sender, EventArgs e)
        {
            Response.Redirect("Logout");
        }
        public void Init(IWidgetHost host)
        {

        }


        public void ShowSettings()
        {

        }


        public void HideSettings()
        {

        }

    }
}