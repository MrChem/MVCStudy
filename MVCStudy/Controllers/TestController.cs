using MVCStudy.Models;
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
    public class TestController : Controller
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

        public ActionResult GetView() {
            Employee emp = new Employee();
            emp.FirstName = "陈";
            emp.LastName = "聪";
            emp.Salary = 20000;
            ViewBag.Employee = emp;
            //ViewData["Employee"] = emp;
            //return View("MyView");
            return View("MyView",emp);
        } 
    }
    
}