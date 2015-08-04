using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Model;
using System.Configuration;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private string _employeeServiceUrl = null;
        HttpClient client = null;
        public WebForm2()
        {
            client = new HttpClient();
            _employeeServiceUrl = ConfigurationManager.AppSettings["employeeserviceurl"];
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["employeeId"] == null )
            {
                Response.Redirect("http://localhost:58084/Account/Login.aspx");

            }
            if (Page.IsPostBack == false)
            {
               var countResponse = client.GetData<GetRemarkCountResponse>(_employeeServiceUrl + "employee/remarks/count/" + Session["employeeId"]);
               if(countResponse.ResponseStatus.Code!="200")
               {
               
               }
                else
               {
                    int count;
                   Int32.TryParse(countResponse.Count, out count);
                   EmpGridView.VirtualItemCount =count;
                var remarkResponse = client.GetData<GetRemarkResponse>(_employeeServiceUrl + "employee/remarks/" + Session["employeeId"] + "/" + (EmpGridView.PageIndex + 1));
                if (remarkResponse.ResponseStatus.Code != "200")
                {
                    NoRemarkLabel.Text = remarkResponse.ResponseStatus.Message;

                }
                else
                {
                    EmpGridView.DataSource = remarkResponse.RequestedRemark;
                    EmpGridView.DataBind();
                }
                EmpGridView.DataBind();
               }
            }
        }

        protected void EmpGridView_SelectedIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EmpGridView.PageIndex = e.NewPageIndex;
            var response = client.GetData<GetRemarkResponse>(_employeeServiceUrl + "employee/remarks/" + Session["employeeId"] + "/" + (EmpGridView.PageIndex + 1));
            if (response.ResponseStatus.Code != "200")
            {
                NoRemarkLabel.Text = "Not able to process request";

            }
            else
            {
                EmpGridView.DataSource = response.RequestedRemark;
                EmpGridView.DataBind();
            }
        }



        protected void ChangePasswordClicked(object sender, EventArgs e)
        {
            Response.Redirect("EmployeePasswordChnage.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
        }


    }
}