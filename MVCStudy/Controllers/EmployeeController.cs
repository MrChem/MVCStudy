using MVCStudy.Business;
using MVCStudy.Models;
using MVCStudy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCStudy.Controllers
{

    public class Customer {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public override string ToString()
        {
            return this.CustomerName + "|" + this.Address;
        }
    }
    /// <summary>
    /// 1.访问路径 根目录/control名/action名
    /// 2.Control 里面的每个public 方法都会自动成为一个action 可以访问
    /// 3.用 [NonAction] 标记不变为action 的public 方法
    /// </summary>
    public class EmployeeController : Controller
    {
        public string GetString() {
            return "Hello World is old now. It’s time for wassup bro";
        }
        public Customer GetCustomer() {
            Customer c = new Customer();
            c.CustomerName = "Customer 1";
            c.Address = "Address1";
            return c;
        }
        [NonAction]
        public string SimpleMethod()
        {
            return "Hi, I am not a action method";
        }

        public ActionResult index() {
            //Employee emp = new Employee();
            //emp.FirstName = "陈";
            //emp.LastName = "聪";
            //emp.Salary = 20000;
            //ViewBag.Employee = emp;


            //ViewData["Employee"] = emp;
            //return View("MyView");
            //return View("MyView",emp);

            //EmployeeViewModel vmEmp = new EmployeeViewModel();
            //vmEmp.EmployeeName = emp.FirstName + " " + emp.LastName;
            //vmEmp.Salary = emp.Salary.ToString("C");
            //if (emp.Salary > 15000)           
            //    vmEmp.SalaryColor = "yellow";            
            //else           
            //    vmEmp.SalaryColor = "green";           
            //vmEmp.UserName = "Admin";
            //return View("MyView", vmEmp);



            //实验5
            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();

            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString("C");
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empViewModels.Add(empViewModel);
            }
            employeeListViewModel.Employees = empViewModels;
           // employeeListViewModel.UserName = "Admin";

            return View("Index", employeeListViewModel);
       


        }

        public ActionResult AddNew() {
            return View("CreateEmployee");
        }

        public ActionResult SaveEmployee(Employee e,string BtnSubmit) {
          
                switch (BtnSubmit)
            {
                case "Save Employee":
                    return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();

          
        }
    }
    
}