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
using Tavisca.EmployeeManagement.EnterpriseLibrary;
using System.Data;
using System.Data.SqlClient;

namespace Tavisca.EmployeeManagement.FileStorage
{
    public class EmployeeStorage : IEmployeeStorage
    {

        public Model.Employee Save(Model.Employee employee)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=TRAINING12;Initial Catalog=Employee;User ID=sa;Password=test123!@#");
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into EmployeeDetails values(@EmpId,@FirstName,@LastName,@title,@Email,@phno,@Doj)", con);
                SqlParameter p1 = new SqlParameter("EmpId", employee.Id);
                SqlParameter p2 = new SqlParameter("FirstName", employee.FirstName);
                SqlParameter p3 = new SqlParameter("LastName", employee.LastName);
                SqlParameter p4 = new SqlParameter("title", employee.Title);
                SqlParameter p5 = new SqlParameter("Email", employee.Email);
                SqlParameter p6 = new SqlParameter("phno", employee.Phone);
                SqlParameter p7 = new SqlParameter("Doj", employee.JoiningDate.ToString());
                SqlCommand cmdRemark = new SqlCommand("Insert into EmployeeRemarks values(@EmpId,@Remark,@RemarkTime)", con);
                if (employee.Remarks != null)
                {
                    foreach (var empRemark in employee.Remarks)
                    {
                        SqlParameter p8 = new SqlParameter("EmpId", employee.Id);
                        SqlParameter p9 = new SqlParameter("Remark", empRemark.Text);
                        SqlParameter p10 = new SqlParameter("RemarkTime", empRemark.CreateTimeStamp.ToString());
                        cmdRemark.Parameters.Add(p8);
                        cmdRemark.Parameters.Add(p9);
                        cmdRemark.Parameters.Add(p10);
                        cmdRemark.ExecuteNonQuery();
                        return employee;
                    }
                }
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);

                cmd.ExecuteNonQuery();
                con.Close();
                return employee;


            }
            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
        }

        public Model.Employee Get(string employeeId)
        {
            try
            {
                Model.Employee emp = new Model.Employee();
                List<Model.Remark> tempRemark = new List<Model.Remark>();
                SqlConnection conEmp = new SqlConnection("Data Source=TRAINING12;Initial Catalog=Employee;User ID=sa;Password=test123!@#");
                conEmp.Open();
                SqlCommand cmd = new SqlCommand("select * from EmployeeDetails where EmpId='" + employeeId + "'", conEmp);
                SqlDataReader empployeeReader = cmd.ExecuteReader();
                while (empployeeReader.Read())
                {
                    emp.Id = empployeeReader[0].ToString();
                    emp.FirstName = empployeeReader[1].ToString();
                    emp.LastName = empployeeReader[2].ToString();
                    emp.Title = empployeeReader[3].ToString();
                    emp.Email = empployeeReader[4].ToString();
                    emp.Phone = empployeeReader[5].ToString();
                    emp.JoiningDate = DateTime.Parse(empployeeReader[6].ToString());
                }
                conEmp.Close();
                SqlConnection conRemark = new SqlConnection("Data Source=TRAINING12;Initial Catalog=Employee;User ID=sa;Password=test123!@#");
                conRemark.Open();
                SqlCommand cmdRemarks = new SqlCommand("select * from EmployeeRemarks where EmpId='" + employeeId + "'", conRemark);
                SqlDataReader remarkReader = cmdRemarks.ExecuteReader();
             
                while (remarkReader.Read())
                {
                    Model.Remark remark = new Model.Remark();
                    remark.Text = remarkReader[2].ToString();
                    remark.CreateTimeStamp = Convert.ToDateTime(remarkReader[3]);
                    tempRemark.Add(remark);

                }
                emp.Remarks = tempRemark;

                conRemark.Close();
                return emp;
            }


            catch (Exception ex)
            {
                var rethrow = ExceptionPolicy.HandleException("data.policy", ex);
                if (rethrow) throw;
                return null;
            }
        }

        public List<Model.Employee> GetAll()
        {
            List<Model.Employee> employeeList = new List<Model.Employee>();
            Model.Employee employee = new Model.Employee();


            SqlConnection con = new SqlConnection("Data Source=TRAINING12;Initial Catalog=Employee;User ID=sa;Password=test123!@#");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from EmployeeDetails ", con);
            SqlDataReader empReader = cmd.ExecuteReader();

            while (empReader.Read())
            {
                employee.Id = empReader[0].ToString();
                employee.FirstName = empReader[1].ToString();
                employee.LastName = empReader[2].ToString();
                employee.Title = empReader[3].ToString();
                employee.Email = empReader[4].ToString();
                employee.Phone = empReader[5].ToString();
                employee.JoiningDate = DateTime.Parse(empReader[6].ToString());
                employeeList.Add(employee);
            }
            con.Close();
            return employeeList;

        }

        private string GetFileName(string employeeId)
        {
            return string.Format(@"{0}\{1}.emp", Configurations.StoragePath, employeeId);
        }
    }
}
