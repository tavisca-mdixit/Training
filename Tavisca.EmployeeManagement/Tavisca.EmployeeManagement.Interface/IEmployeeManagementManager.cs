using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.Interface
{
    public interface IEmployeeManagementManager
    {
        Employee Create(Employee employee);

        Remark AddRemark(string employeeId, Remark remark);

        Employee Authenticate(string userName, string password);

        bool ChangePassword(string emplpoyeeId,string oldPass, string newPass);
    }
}
