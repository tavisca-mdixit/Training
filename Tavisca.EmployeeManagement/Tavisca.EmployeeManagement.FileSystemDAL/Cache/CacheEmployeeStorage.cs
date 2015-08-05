using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Interface;
using Newtonsoft.Json;
using Tavisca.EmployeeManagement.ErrorSpace;

namespace Tavisca.EmployeeManagement.FileStorage
{
    public class CacheEmployeeStorage : IEmployeeStorage
    {
        public CacheEmployeeStorage(ICacheManager manager)
        {
            _innerStorage = new EmployeeStorage();
            _cacheManager = manager;
        }

        IEmployeeStorage _innerStorage;
        ICacheManager _cacheManager;

        readonly string KEYFORMAT = "emp.{0}";
        readonly string CACHEMANAGER = "employee";

        public Model.Employee SaveRemark(Model.Employee employee)
        {
            var result = _innerStorage.SaveRemark(employee);

            return result;
        }
        public Model.Employee Save(Model.Employee employee)
        {
            var result = _innerStorage.Save(employee);

            return result;
        }

        public Model.Employee Get(string employeeId)
        {
            Model.Employee result = null;

            result = _innerStorage.Get(employeeId);


            return result;
        }

        public List<Model.Employee> GetAll()
        {
            return _innerStorage.GetAll();
        }

        public Model.Employee Authenticate(string userName, string password)
        {
            var result = _innerStorage.Authenticate(userName, password);

            return result;
        }

        public bool ChangePassword(string employeeId, string oldPass, string newPass)
        {
            var result = _innerStorage.ChangePassword(employeeId, oldPass, newPass);

            return result;
        }
        public List<Model.Remark> PaginateRemarks(string employeeId, string pageNumber)
        {
            return _innerStorage.PaginateRemarks(employeeId, pageNumber);
        }
        public string GetRemarkCount(string employeeId)
        {
            return _innerStorage.GetRemarkCount(employeeId);
        }
    }
}
