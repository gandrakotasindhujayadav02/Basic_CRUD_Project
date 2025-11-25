using EmployeeManagement.Models;
using EmployeeManagement.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }
        public async Task<IActionResult> EmployeeList()
        {
            Employee_Model mdl = new Employee_Model();
            try
            {
                mdl = await _employeeService.GetEmployeeList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return View(mdl);
        }
        public async Task<IActionResult> CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeDtls_Mdl mdl)
        {
            string result = string.Empty;
            try
            {
                mdl.Status = "INSERTED";
                result = await _employeeService.InsertNewEmpDetails(mdl);
                if (result == "S")
                {
                    TempData["Status"] = "New Employee Details added Successfully";
                }
                else
                {
                    TempData["Status"] = "New Employee Details addition Failed, Please try again";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            //return View(mdl);
            //return View("EmployeeList");
            return RedirectToAction("EmployeeList", "Employee");
        }
        [HttpGet]
        public async Task<IActionResult> EditEmployee(int EmpId)
        {
            EmployeeDtls_Mdl mdl = new EmployeeDtls_Mdl();
            try
            {
                mdl = await _employeeService.GetEmployeeDetails(EmpId);
            }
            catch (Exception ex)
            {
                throw;
            }
            return View(mdl);
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(EmployeeDtls_Mdl mdl)
        {
            string result = string.Empty;
            try
            {
                mdl.Status = "UPDATED";
                result = await _employeeService.InsertNewEmpDetails(mdl);
                if (result == "S")
                {
                    TempData["Status"] = "Employee Details Updated Successfully";
                }
                else
                {
                    TempData["Status"] = "Employee Details updation Failed, Please try again";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction("EmployeeList", "Employee");
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> DeleteEmpDetails(int empId)
        {
            string result = string.Empty;
            try
            {
                result = await _employeeService.DeleteEmpDetails(empId);
            }
            catch
            {
                throw;
            }
            return new JsonResult(result);
        }

       
    }
}
