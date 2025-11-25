using EmployeeManagement.Models;
using EmployeeManagement.Repository.Interface;
using EmployeeManagement.Service.Interface;

namespace EmployeeManagement.Service.ServiceClass
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeReposi _employeeReposi;
        public EmployeeService(IEmployeeReposi employeeReposi) 
        {
            _employeeReposi = employeeReposi;
        }
        public async Task<Employee_Model> GetEmployeeList()
        {
           return await _employeeReposi.GetEmployeeList();
        }
        public async Task<string> InsertNewEmpDetails(EmployeeDtls_Mdl mdl)
        {
            return await _employeeReposi.InsertNewEmpDetails(mdl);
        }
        public async Task<EmployeeDtls_Mdl> GetEmployeeDetails(int EmpId)
        {
            return await _employeeReposi.GetEmployeeDetails(EmpId);
        }
        public async Task<string> DeleteEmpDetails(int EmpId)
        {
            return await _employeeReposi.DeleteEmpDetails(EmpId);
        }
    }
}
