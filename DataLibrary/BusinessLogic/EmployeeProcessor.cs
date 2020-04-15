using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class EmployeeProcessor
    {
        public static int CreateEmployee(int empCWID, string firstName, string lastName, string empMI, 
            string streetAddress, string empCity, string empState, string empZip, string payroll, int salary, 
            int empPoBox, string empPoBoxCity, string empPoBoxState, int empOrgCode, string empDepartment, 
            bool empStatus, DateTime empDateCreated, DateTime empDateEdited)
        {
            EmployeeModel data = new EmployeeModel
            {
                CWID = empCWID,
                EmployeeFirstName = firstName,
                EmployeeLastName = lastName,
                EmployeeMI = empMI,
                StreetAddress = streetAddress,
                EmployeeCity = empCity,
                EmployeeState = empState,
                EmployeeZip = empZip,
                Payroll = payroll,
                Salary = salary,
                POBox = empPoBox,
                POBoxCity = empPoBoxCity,
                POBoxState = empPoBoxState,
                OrgCode = empOrgCode,
                EmployeeDepartment = empDepartment,
                EmployeeStatus = empStatus,
                EmployeeDateCreated = empDateCreated,
                EmployeeLastEdited = empDateEdited
            };

            string sql = @"INSERT INTO Employee (cwid, employeefirstname, employeelastname, employeemi, streetaddress, employeecity, employeestate, employeezip, payroll, salary, pobox, poboxstate, poboxcity, employeestatus, orgcode, employeedatecreated, employeelastedited)
                            VALUES       (@CWID, @EmployeeFirstName, @EmployeeLastName, @EmployeeMI, @StreetAddress, @EmployeeCity, @EmployeeState, @EmployeeZip, @Payroll, @Salary, @POBox, @POBoxState, @POBoxCity, @EmployeeStatus, @OrgCode, @EmployeeDateCreated, @EmployeeLastEdited)";

            return SQLDataAccess.SaveData(sql, data);

        }

        public static List<EmployeeModel> LoadEmployees()
        {
            string sql = @"SELECT cwid, employeefirstname, employeelastname, employeemi, streetaddress, employeecity, employeestate, employeezip, payroll, salary, pobox, poboxstate, poboxcity, employeestatus, orgcode, employeedatecreated, employeelastedited
                            from dbo.Employee;";

            return SQLDataAccess.LoadData<EmployeeModel>(sql);
        }

        public static int EditEmployee(int empCWID, string firstName, string lastName, string empMI,
            string streetAddress, string empCity, string empState, string empZip, string payroll, int salary,
            int empPoBox, string empPoBoxCity, string empPoBoxState, int empOrgCode, string empDepartment,
            bool empStatus, DateTime empDateCreated, DateTime empDateEdited)
        {
            EmployeeModel data = new EmployeeModel
            {
                CWID = empCWID,
                EmployeeFirstName = firstName,
                EmployeeLastName = lastName,
                EmployeeMI = empMI,
                StreetAddress = streetAddress,
                EmployeeCity = empCity,
                EmployeeState = empState,
                EmployeeZip = empZip,
                Payroll = payroll,
                Salary = salary,
                POBox = empPoBox,
                POBoxCity = empPoBoxCity,
                POBoxState = empPoBoxState,
                OrgCode = empOrgCode,
                EmployeeDepartment = empDepartment,
                EmployeeStatus = empStatus,
                EmployeeDateCreated = empDateCreated,
                EmployeeLastEdited = empDateEdited
            };

            string sql = @"UPDATE Employee 
                            SET cwid = @CWID, employeefirstname = @EmployeeFirstName, employeelastname = @EmployeeLastName, employeemi = @EmployeeMI, 
                            streetaddress = @StreetAddress, employeecity = @EmployeeCity, employeestate = @EmployeeState, employeezip = @EmployeeZip, 
                            payroll = @Payroll, salary = @Salary, pobox = @POBox, poboxcity = @POBoxCity, poboxstate = @POBoxState, employeestatus = @EmployeeStatus,
                            employeedatecreated = @EmployeeDateCreated, employeelastedited = @EmployeeLastEdited, orgcode = @OrgCode
                            WHERE cwid = @CWID;";

            return SQLDataAccess.SaveData(sql, data);
        }
    }
}
