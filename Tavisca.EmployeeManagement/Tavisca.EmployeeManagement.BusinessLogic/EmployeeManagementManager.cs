using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.BusinessLogic
{
    public class EmployeeManagementManager : IEmployeeManagementManager
    {
        public EmployeeManagementManager(IEmployeeStorage storage)
        {
            _storage = storage;
        }

        IEmployeeStorage _storage;

        public Employee Create(Employee employee)
        {
            employee.Validate();
           
            return _storage.Save(employee);
        }

        public Remark AddRemark(string employeeId, Remark remark)
        {
            remark.Validate();
            var employee = _storage.Get(employeeId);
            if (employee.Remarks == null) employee.Remarks = new List<Remark>();
            else employee.Remarks.Clear();
            remark.CreateTimeStamp = DateTime.UtcNow;
            employee.Remarks.Add(remark);
            _storage.SaveRemark(employee);
            return remark;
        }
        public Employee Authenticate(string userName,string password)
        {
            
            return _storage.Authenticate(userName,password);
        }

        public bool ChangePassword(string employeeId,string oldPass, string newPass)
        {
            return _storage.ChangePassword(employeeId,oldPass,newPass);        
        
        }
       
    }
}
