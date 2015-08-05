using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.ServiceContract;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.Translator;
using Tavisca.EmployeeManagement.EnterpriseLibrary;

namespace Tavisca.EmployeeManagement.ServiceImpl
{
    public class EmployeeManagementService : IEmployeeManagementService
    {
        public EmployeeManagementService(IEmployeeManagementManager manager)
        {
            _manager = manager;
        }

        IEmployeeManagementManager _manager;

        public DataContract.CreateEmployeeResponse Create(DataContract.Employee employee)
        {
            DataContract.CreateEmployeeResponse response = new DataContract.CreateEmployeeResponse();
            try
            {
                var result = _manager.Create(employee.ToDomainModel());
                if (result == null)
                {
                    response.ResponseStatus.Code = "500";
                    response.ResponseStatus.Message = "Unable to submit employee";
                    return response;
                }
                response.CreatedEmployee = result.ToDataContract();
                return response;
            }
            catch (Exception ex)
            {
                Exception newEx;
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex, out newEx);
                response.ResponseStatus.Code = "500";
                response.ResponseStatus.Message = ex.Message;
                return response;
            }
        }

        public DataContract.CreatedRemarkResponse AddRemark(string employeeId, DataContract.Remark remark)
        {
            DataContract.CreatedRemarkResponse response = new DataContract.CreatedRemarkResponse();
            try
            {
                var result = _manager.AddRemark(employeeId, remark.ToDomainModel());
                if (result == null)
                {
                    response.ResponseStatus.Code = "500";
                    response.ResponseStatus.Message = "Unable to submit remark";
                    return response;
                }
                response.Remark = result.ToDataContract();
                return response;
            }
            catch (Exception ex)
            {
                Exception newEx;
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex, out newEx);
                response.ResponseStatus.Code = "500";
                response.ResponseStatus.Message = ex.Message;
                return response;
            }
        }

        public DataContract.AuthenticateEmployeeResponse Authenticate(DataContract.Credentials creds)
        {
            DataContract.AuthenticateEmployeeResponse response = new DataContract.AuthenticateEmployeeResponse();
            try
            {
                var result = _manager.Authenticate(creds.UserName, creds.Password);
                if (result == null)
                {
                    response.ResponseStatus.Code = "500";
                    response.ResponseStatus.Message = "Login Failed";
                    return response; 
                }
                response.AuthenticatedEmployee = result.ToDataContract();
                return response;
            }
            catch (Exception ex)
            {
                Exception newEx;
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex, out newEx);
                response.ResponseStatus.Code = "500";
                response.ResponseStatus.Message = ex.Message;
                return response;
            }

        }
        public DataContract.ChangePasswordResponse ChangePassword(DataContract.PasswordChange pass)
        {
            DataContract.ChangePasswordResponse response = new DataContract.ChangePasswordResponse();
            try
            {
                var result = _manager.ChangePassword(pass.EmployeeId, pass.OldPassword, pass.NewPassword);
                DataContract.Employee emp = new DataContract.Employee();

                if (result==false)
                {
                    response.ResponseStatus.Code = "500";
                    response.ResponseStatus.Message = "Failed";
                    return response;
                }
               
                return response;

            }
            catch (Exception ex)
            {
                Exception newEx;
                var rethrow = ExceptionPolicy.HandleException("service.policy", ex, out newEx);
                response.ResponseStatus.Code = "500";
                response.ResponseStatus.Message = ex.Message;
                return response;
            }



        }

    }
}
