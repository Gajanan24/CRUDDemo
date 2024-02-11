using CRUDDemo.DAL;
using CRUDDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDDemo.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult EmpList()
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();
            List<Employee> employees = employeeDAL.GetEmpList();
            return View(employees);
        }
        [HttpGet]
        public IActionResult AddEmp() { 
        return View();
        }
        [HttpPost]
        public IActionResult AddEmp(Employee emp) {

            EmployeeDAL employeeDAL=new EmployeeDAL();
            int res=employeeDAL.Insert(emp);
            if(res > 0)
            {
                return RedirectToAction("EmpList");
            }
            else
            {
                return Content("Could not Save ! Pls try again");
            }
         
        }
        [HttpGet]
        public IActionResult DeleteEmp(int id)
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();
            int res = employeeDAL.DeleteEmp(id);

            if(res > 0 )
            {
                return RedirectToAction("EmpList");
            }
            else
            {
                return Content("Couldnt Delete the record!!");

            }
        }
        public IActionResult UpdateEmp(int id)
        {
            EmployeeDAL employeeDAL= new EmployeeDAL();
            Employee e=employeeDAL.GetEmp(id);
            return View(e);
        }
        [HttpPost]
        public IActionResult UpdateEmp(Employee emp) 
        {
            EmployeeDAL employeeDAL = new EmployeeDAL();
           int res= employeeDAL.UpdateEmp(emp);
            if(res > 0)
            {
                return RedirectToAction("EmpList");
            }                                               
            else
            {
                return Content("Sorry  Could not update the record!!!");
            }
          //  return View(emp);
        }


    }
}
