namespace EmployeeManagement.Models
{
    public class Employee_Model
    {
        public EmployeeDtls_Mdl EmployeeDtls_Mdl { get;set; }
        public List<EmployeeDtls_Mdl> EmployeeDtls_MdlList { get;set; }
        public EmployeeSalaryDtls_Mdl EmployeeSalaryDtls_Mdl { get;set; }
        public List<EmployeeSalaryDtls_Mdl> EmployeeSalaryDtls_MdlList { get;set; }
    }
    public class EmployeeDtls_Mdl
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
        public string Status { get; set; }
        public decimal TotalSalary { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal HRA { get; set; }
        public decimal TA { get; set; }
    }
    public class EmployeeSalaryDtls_Mdl
    {
        public int SalaryId { get; set; }
        public int EmployeeId { get; set; }
        public string SalaryType { get; set; }
        public decimal Amount { get; set; }
    }
}
