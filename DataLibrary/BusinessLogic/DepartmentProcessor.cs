﻿using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class DepartmentProcessor
    {
        //process the information/data, statement for sending that data to sql database
        public static int CreateDepartment(int orgCode, string departmentName, string uwCoordinator3, string uwCoordinator2, string uwCoordinator1, 
            string diVision, bool departmentStatus, DateTime departmentDateCreated, DateTime departmentLastEdited)
        {
            DepartmentModel data = new DepartmentModel
            {
                OrgCode = orgCode,
                departmentname = departmentName,
                UWCoordinator3 = uwCoordinator3,
                UWCoordinator2 = uwCoordinator2,
                UWCoordinator1 = uwCoordinator1,
                Division = diVision,
                DepartmentDateCreated = departmentDateCreated,
                DepartmentLastEdited = departmentLastEdited,
                DepartmentStatus = departmentStatus
            };

            //sending data TO the database, paramterized sql, @ = variable
            string sql = @"INSERT INTO Department (orgcode, departmentname, uwcoordinator3, uwcoordinator2, uwcoordinator1, division, departmentdatecreated, departmentlastedited, departmentstatus)
                            VALUES (@OrgCode, @departmentname, @UWCoordinator3, @UWCoordinator2, @UWCoordinator1, @Division, @DepartmentDateCreated, @DepartmentLastEdited, @DepartmentStatus);";


            return SQLDataAccess.SaveData(sql, data);
        }

        //code for pulling data FROM the database, LOADS all departments m
        public static List<DepartmentModel> LoadDepartments()
        {
            string sql = @"SELECT orgcode, departmentname, division, uwcoordinator3, uwcoordinator2, uwcoordinator1, departmentstatus, departmentdatecreated, departmentlastedited
                            FROM Department;";

            return SQLDataAccess.LoadData<DepartmentModel>(sql);
        }

        // code for storing the edited department instances in SQL
        public static int EditDepartment(int orgCode, string departmentName, string uwCoordinator3, string uwCoordinator2, string uwCoordinator1,
            string diVision, bool departmentStatus, DateTime departmentDateCreated, DateTime departmentLastEdited)
        {
            DepartmentModel data = new DepartmentModel
            {
                OrgCode = orgCode,
                departmentname = departmentName,
                UWCoordinator3 = uwCoordinator3,
                UWCoordinator2 = uwCoordinator2,
                UWCoordinator1 = uwCoordinator1,
                Division = diVision,
                DepartmentDateCreated = departmentDateCreated,
                DepartmentLastEdited = departmentLastEdited,
                DepartmentStatus = departmentStatus
            };

            string sql = @"UPDATE Department 
                            SET orgcode = @OrgCode, departmentname = @departmentName, uwcoordinator3 = @UWCoordinator3, uwcoordinator2 = @UWCoordinator2, 
                            uwcoordinator1 = @UWCoordinator1, division = @Division, departmentdatecreated = @DepartmentDateCreated, departmentlastedited = @DepartmentLastEdited, 
                            departmentstatus = @DepartmentStatus
                            WHERE orgcode = @OrgCode;";

            return SQLDataAccess.SaveData(sql, data);
        }

        public static List<DepartmentReportModel> LoadDepartmentReport()

        {
            string sql = @"SELECT d.division, SUM(c.uwcontributionamount) AS CurrTotal, ((SUM(c.uwcontributionamount)) / (COUNT(DISTINCT(c.cwid)))) AS CurrAvg,
		                            COUNT(DISTINCT(c.cwid)) AS DonorCount, COUNT(e.cwid) AS EmployeeCount, ROUND((COUNT(DISTINCT(c.cwid)) * 100.00 / COUNT(e.cwid)),2) AS PercentParticipation
                            FROM Department as d JOIN Employee as e ON (d.orgcode = e.orgcode)
	                               LEFT JOIN Contribution c ON (e.cwid = c.cwid)
                            WHERE e.employeestatus = 1
                            GROUP BY d.division;";

            return SQLDataAccess.LoadData<DepartmentReportModel>(sql);

        }
    }
}
