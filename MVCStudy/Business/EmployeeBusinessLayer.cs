using MVCStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCStudy.DataAccessLayer;

namespace MVCStudy.Business
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            SalesERPDAL saleDal = new SalesERPDAL();
            return saleDal.Employees.ToList();
        }
    }
}