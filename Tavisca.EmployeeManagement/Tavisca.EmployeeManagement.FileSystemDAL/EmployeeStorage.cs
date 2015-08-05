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

            using (var con = new SqlConnection("Data Source=TAVWITPD041;Initial Catalog=Employee;User ID=sa;Password=test123!@#"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SaveEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("Title", employee.Title);
                SqlParameter p2 = new SqlParameter("FirstName", employee.FirstName);
                SqlParameter p3 = new SqlParameter("LastName", employee.LastName);
                SqlParameter p4 = new SqlParameter("Email", employee.Email);
                SqlParameter p5 = new SqlParameter("Phone", employee.Phone);
                SqlParameter p6 = new SqlParameter("Doj", employee.JoiningDate);

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);

                cmd.ExecuteNonQuery();
                return employee;

            }
        }

        public Model.Employee SaveRemark(Model.Employee employee)
        {

            using (var con = new SqlConnection("Data Source=TAVWITPD041;Initial Catalog=Employee;User ID=sa;Password=test123!@#"))
            {
                con.Open();
                SqlCommand cmdRemark = new SqlCommand("AddRemark", con);
                cmdRemark.CommandType = CommandType.StoredProcedure;

                foreach (var empRemark in employee.Remarks)
                {
                    SqlParameter p6 = new SqlParameter("EmpId", employee.Id);
                    SqlParameter p7 = new SqlParameter("Text", empRemark.Text);
                    SqlParameter p8 = new SqlParameter("CreateTimeStamp", empRemark.CreateTimeStamp);
                    cmdRemark.Parameters.Add(p6);
                    cmdRemark.Parameters.Add(p7);
                    cmdRemark.Parameters.Add(p8);
                    cmdRemark.ExecuteNonQuery();

                }
                return employee;
            }

        }

        public List<Model.Remark> GetRemark(int employeeId)
        {
            using (var con = new SqlConnection("Data Source=TAVWITPD041;Initial Catalog=Employee;User ID=sa;Password=test123!@#"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GetRemark", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Id", employeeId));
                SqlDataReader remarkReader = cmd.ExecuteReader();
                List<Model.Remark> tempRemark = new List<Model.Remark>();
                while (remarkReader.Read())
                {

                    Model.Remark remark = new Model.Remark();
                    remark.Text = remarkReader[2].ToString();
                    remark.CreateTimeStamp = DateTime.Parse(remarkReader[3].ToString());
                    tempRemark.Add(remark);

                }

                return tempRemark;
            }
        }

        public Model.Employee Get(string employeeId)
        {

            using (var con = new SqlConnection("Data Source=TAVWITPD041;Initial Catalog=Employee;User ID=sa;Password=test123!@#"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GetEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Id", employeeId));
                Model.Employee emp = new Model.Employee();
                List<Model.Remark> tempRemark = new List<Model.Remark>();

                SqlDataReader empReader = cmd.ExecuteReader();
                while (empReader.Read())
                {
                    emp.Id = empReader[0].ToString();
                    emp.Title = empReader[1].ToString();
                    emp.FirstName = empReader[2].ToString();
                    emp.LastName = empReader[3].ToString();
                    emp.Email = empReader[4].ToString();
                    emp.Phone = empReader[5].ToString();
                    emp.JoiningDate = DateTime.Parse(empReader[6].ToString());
                }
                emp.Remarks = GetRemark(Convert.ToInt32(emp.Id));
                return emp;
            }

        }

        public List<Model.Employee> GetAll()
        {

            using (var con = new SqlConnection("Data Source=TAVWITPD041;Initial Catalog=Employee;User ID=sa;Password=test123!@#"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GetAllEmp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Model.Employee> empList = new List<Model.Employee>();

                SqlDataReader empReader = cmd.ExecuteReader();

                while (empReader.Read())
                {
                    Model.Employee emp = new Model.Employee();
                    emp.Id = empReader[0].ToString();
                    emp.Title = empReader[1].ToString();
                    emp.FirstName = empReader[2].ToString();
                    emp.LastName = empReader[3].ToString();
                    emp.Email = empReader[4].ToString();
                    emp.Phone = empReader[5].ToString();
                    emp.JoiningDate = DateTime.Parse(empReader[6].ToString());
                    empList.Add(emp);
                }
                return empList;
            }

        }

        public Model.Employee Authenticate(string userName, string password)
        {

            using (var conEmp = new SqlConnection("Data Source=TAVWITPD041;Initial Catalog=Employee;User ID=sa;Password=test123!@#"))
            {
                conEmp.Open();
                SqlCommand cmd = new SqlCommand("AuthenticateEmp", conEmp);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Email", userName));
                cmd.Parameters.Add(new SqlParameter("@Password", password));
                SqlDataReader empReader = cmd.ExecuteReader();
                Model.Employee emp = new Model.Employee();

                if (empReader.HasRows)
                {
                    while (empReader.Read())
                    {

                        emp.Id = empReader[0].ToString().Trim();
                        emp.Title = empReader[1].ToString().Trim();
                        emp.FirstName = empReader[2].ToString().Trim();
                        emp.LastName = empReader[3].ToString().Trim();
                        emp.Email = empReader[4].ToString().Trim();
                        emp.Phone = empReader[5].ToString().Trim();
                        emp.JoiningDate = DateTime.Parse(empReader[6].ToString().Trim());

                    }
                    return emp;
                }
                emp = null;
                return emp;
            }
        }

        public bool ChangePassword(string employeeId, string oldPass, string newPass)
        {
            using (var con = new SqlConnection("Data Source=TAVWITPD041;Initial Catalog=Employee;User ID=sa;Password=test123!@#"))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("UpdatePassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", employeeId));
                cmd.Parameters.Add(new SqlParameter("@Password", oldPass));
                cmd.Parameters.Add(new SqlParameter("@NewPassword", newPass));
                int queryExecuted = cmd.ExecuteNonQuery();
                if (queryExecuted > 0)
                {
                    con.Close();
                    return true;
                }
                return false;
            }

        }

        public List<Model.Remark> PaginateRemarks(string employeeId, string pageNumber)
        {
            using (var con = new SqlConnection("Data Source=TAVWITPD041;Initial Catalog=Employee;User ID=sa;Password=test123!@#"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("PaginateRemark", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", employeeId));
                cmd.Parameters.Add(new SqlParameter("@page", pageNumber));
                SqlDataReader remarkReader = cmd.ExecuteReader();
                List<Model.Remark> tempRemarkList = new List<Model.Remark>();
                while (remarkReader.Read())
                {
                    Model.Remark tempRemarkObj = new Model.Remark();
                    tempRemarkObj.Text = remarkReader[0].ToString();
                    tempRemarkObj.CreateTimeStamp = DateTime.Parse(remarkReader[1].ToString());
                    tempRemarkList.Add(tempRemarkObj);
                }
                return tempRemarkList;
            }

        }

        public string GetRemarkCount(string employeeId)
        {
            using (var con = new SqlConnection("Data Source=TAVWITPD041;Initial Catalog=Employee;User ID=sa;Password=test123!@#"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("RemarkCount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", employeeId));
                return cmd.ExecuteScalar().ToString();
            }
        }
    }
}
