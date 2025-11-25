using EmployeeManagement.Models;

namespace EmployeeManagement.Service.Interface
{
    public interface IEmployeeService
    {
        public Task<Employee_Model> GetEmployeeList();
        public Task<string> InsertNewEmpDetails(EmployeeDtls_Mdl mdl);
        public Task<EmployeeDtls_Mdl> GetEmployeeDetails(int EmpId);
        public Task<string> DeleteEmpDetails(int EmpId);
    }
}
