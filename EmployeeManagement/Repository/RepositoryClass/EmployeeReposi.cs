using EmployeeManagement.Models;
using EmployeeManagement.Repository.Interface;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace EmployeeManagement.Repository.RepositoryClass
{
    public class EmployeeReposi : IEmployeeReposi
    {
        private readonly string _connectionString;
        public EmployeeReposi(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DBConnectStr").ToString();
        }
        public async Task<Employee_Model> GetEmployeeList()
        {
            Employee_Model employee = new Employee_Model();
            employee.EmployeeDtls_MdlList = new List<EmployeeDtls_Mdl>();
            SqlConnection conn = null;
            try
            {
                using (conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("GetEmployeeList", conn))
                    using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                    {
                        while (await rdr.ReadAsync())
                        {
                            employee.EmployeeDtls_MdlList.Add(new EmployeeDtls_Mdl
                            {
                                EmployeeId = rdr.GetInt32(0),
                                EmployeeName = rdr.GetString(1),
                                EmployeeAge = rdr.GetInt32(2),
                                TotalSalary = rdr.GetDecimal(3)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return employee;
        }
        public async Task<string> InsertNewEmpDetails(EmployeeDtls_Mdl model)
        {
            string result = string.Empty;
            SqlConnection conn = null;
            try
            {
                using (conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string procedure = model.EmployeeId == 0 ? "InsertEmployeeWithSalary" : "UpdateEmployeeWithSalaryById";

                    using (SqlCommand cmd = new SqlCommand(procedure, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (model.EmployeeId != 0)
                        {
                            cmd.Parameters.AddWithValue("@EmployeeId", model.EmployeeId);

                        }
                        cmd.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                        cmd.Parameters.AddWithValue("@EmployeeAge", model.EmployeeAge);
                        cmd.Parameters.AddWithValue("@Status", model.Status);
                        cmd.Parameters.AddWithValue("@TotalSalary", model.TotalSalary);
                        cmd.Parameters.AddWithValue("@BasicSalary", model.BasicSalary);
                        cmd.Parameters.AddWithValue("@HRA", model.HRA);
                        cmd.Parameters.AddWithValue("@TA", model.TA);
                        object scalarResult = await cmd.ExecuteScalarAsync();
                        result = scalarResult?.ToString();
                    }


                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn?.Close();
            }
            return result;
        }
        public async Task<EmployeeDtls_Mdl> GetEmployeeDetails(int EmpId)
        {
            EmployeeDtls_Mdl emp = new EmployeeDtls_Mdl();
            SqlConnection conn = null;
            try
            {
                using (conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetEmployeeWithSalaryDetailsById", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeeId", EmpId);
                        using (SqlDataReader rdr = await cmd.ExecuteReaderAsync())
                        {
                            while (await rdr.ReadAsync())
                            {
                                emp = new EmployeeDtls_Mdl
                                {
                                    EmployeeId = rdr.GetInt32(0),
                                    EmployeeName = rdr.GetString(1),
                                    EmployeeAge = rdr.GetInt32(2),
                                    Status = rdr.GetString(3),
                                    BasicSalary = rdr.GetDecimal(4),
                                    HRA = rdr.GetDecimal(5),
                                    TA = rdr.GetDecimal(6),
                                    TotalSalary = rdr.GetDecimal(7)
                                };
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return emp;
        }
        public async Task<string> DeleteEmpDetails(int EmpId)
        {
            string result = string.Empty;
            SqlConnection conn = null;
            try
            {
                using (conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DeleteEmployeeById", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeeId", EmpId);
                        object scalarResult = await cmd.ExecuteScalarAsync();
                        result = scalarResult?.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }
}
