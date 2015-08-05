﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.BusinessLogic
{
    public class EmployeeManager : IEmployeeManager
    {
        public EmployeeManager(IEmployeeStorage storage)
        {
            _storage = storage;
        }

        IEmployeeStorage _storage;

        public Employee Get(string employeeId)
        {
            return _storage.Get(employeeId);
        }

        public List<Employee> GetAll()
        {
            return _storage.GetAll();
        }
        public List<Remark> PaginateRemarks(string employeeId,string pageNumber)
        {
            return _storage.PaginateRemarks(employeeId,pageNumber);
        }
        public string GetRemarkCount(string employeeId)
        {
            return _storage.GetRemarkCount(employeeId);
        }
    }
}
