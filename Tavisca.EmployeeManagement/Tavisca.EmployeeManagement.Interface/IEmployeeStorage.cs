using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.Interface
{
    public interface IEmployeeStorage
    {
        Employee Save(Employee employee);
        Employee SaveRemark(Employee employee);

        Employee Get(string employeeId);
      
        List<Employee> GetAll();

        Employee Authenticate(string userName, string password);
        
        bool ChangePassword(string employeeId,string oldPass, string newPass);

        List<Remark> PaginateRemarks(string employeeId,string pageNumber);

        string GetRemarkCount(string employeeId);
    }
}
