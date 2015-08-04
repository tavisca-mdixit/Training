using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.DataContract;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Tavisca.EmployeeManagement.ServiceContract
{
    [ServiceContract]
    public interface IEmployeeManagementService
    {
        [WebInvoke(Method="POST", UriTemplate="/employee", RequestFormat= WebMessageFormat.Json, ResponseFormat= WebMessageFormat.Json)]
        DataContract.CreateEmployeeResponse Create(Employee employee);

        [WebInvoke(Method = "POST", UriTemplate = "/employee/{employeeId}/remark", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        DataContract.CreatedRemarkResponse AddRemark(string employeeId, Remark remark);

        [WebInvoke(Method = "POST", UriTemplate = "/employee/credentials", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        DataContract.AuthenticateEmployeeResponse Authenticate(Credentials creds);
      
        [WebInvoke(Method = "POST", UriTemplate = "/employee/changepassword", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        DataContract.ChangePasswordResponse ChangePassword(PasswordChange pass);
        

       
    }
}

            //var client = new WebClient();
            //client.Headers.Add("Content-Type", contentType);
            //var dataToBeUploaded = Serializer.Serialize<T1>(data);
            //var response = client.UploadString(url, method, dataToBeUploaded);
            //return Serializer.Deserialize<T2>(response);