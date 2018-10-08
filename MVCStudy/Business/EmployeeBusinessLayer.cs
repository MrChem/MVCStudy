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

        public Employee SaveEmployee(Employee e) {
            SalesERPDAL saleDal = new SalesERPDAL();
            saleDal.Employees.Add(e);
            saleDal.SaveChanges();
            return e;
        }
    }
}