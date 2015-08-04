using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.EnterpriseLibrary;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.ServiceContract;
using Tavisca.EmployeeManagement.Translator;

namespace Tavisca.EmployeeManagement.ServiceImpl
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeService(IEmployeeManager manager)
        {
            _manager = manager;
        }

        IEmployeeManager _manager;

        public DataContract.GetEmployeeResponse Get(string employeeId)
        {
            DataContract.GetEmployeeResponse response = new DataContract.GetEmployeeResponse();
            try
            {
                var result = _manager.Get(employeeId);
                if (result == null) return response;
                response.RequestedEmployee = result.ToDataContract();
                return response;
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex);
                if (rethrow) throw;
                response.ResponseStatus.Code = "500";
                response.ResponseStatus.Message = "Unable to fetch  request employee";
                return response;
            }
        }

        public DataContract.GetAllEmployeeResponse GetAll()
        {
            DataContract.GetAllEmployeeResponse response = new DataContract.GetAllEmployeeResponse();
            try
            {
                var result = _manager.GetAll();
                if (result == null) return response;
                 response.EmpList = result.Select(employee => employee.ToDataContract()).ToList();                
                 return response;
             
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex);
                if (rethrow) throw;
                response.ResponseStatus.Code = "500";
                response.ResponseStatus.Message = "Unable to fetch list of employees";
                return response;
            }

        }
        public DataContract.GetRemarkResponse   GetRemarks(string employeeId,string pageNumber)
        {
            DataContract.GetRemarkResponse response = new DataContract.GetRemarkResponse();
            try
            {            
                var result = _manager.PaginateRemarks(employeeId,pageNumber);
                if (result == null) return response; 
                response.RequestedRemark=result.Select(remark=>remark.ToDataContract()).ToList();
                return response;
            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex);
                if (rethrow) throw;
                response.ResponseStatus.Code = "500";
                response.ResponseStatus.Message = "Unable to fetch employee response";
                return response;
            }        
        
        }
        public DataContract.GetRemarkCountResponse GetRemarkCount(string employeeId)
        {
            DataContract.GetRemarkCountResponse response = new DataContract.GetRemarkCountResponse();
            try
            {
                var result = _manager.GetRemarkCount(employeeId);
                if (result == null) return response;
                response.Count = result;
                return response;

            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex);
                if (rethrow) throw;
                response.ResponseStatus.Code = "500";
                response.ResponseStatus.Message = "Unable to fetch Remark Count";
                return response;
            }        

        }
    }
}
