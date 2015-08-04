using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.DataContract;

namespace Tavisca.EmployeeManagement.ServiceContract
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [WebGet(UriTemplate = "employee/{employeeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        DataContract.GetEmployeeResponse Get(string employeeId);

        [WebGet(UriTemplate = "employee", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        DataContract.GetAllEmployeeResponse GetAll();

        [WebGet(UriTemplate = "employee/remarks/{employeeId}/{pageNumber}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        DataContract.GetRemarkResponse  GetRemarks(string employeeId,string pageNumber);

        [WebGet(UriTemplate = "employee/remarks/count/{employeeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        DataContract.GetRemarkCountResponse GetRemarkCount(string employeeId);
    }
}
