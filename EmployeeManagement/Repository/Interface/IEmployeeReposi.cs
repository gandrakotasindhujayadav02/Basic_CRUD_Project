using EmployeeManagement.Models;

namespace EmployeeManagement.Repository.Interface
{
    public interface IEmployeeReposi
    {
        public Task<Employee_Model> GetEmployeeList();
        public Task<string> InsertNewEmpDetails(EmployeeDtls_Mdl mdl);
        public Task<EmployeeDtls_Mdl> GetEmployeeDetails(int EmpId);
        public Task<string> DeleteEmpDetails(int EmpId);
    }
}
