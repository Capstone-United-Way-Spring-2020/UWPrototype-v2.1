﻿using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    //process the information/data, statements for sending data to and from sql database
    public class ContributionProcessor
    {
        public static int CreateContribution(string UWType, double UWMonthly, int UWMonths, double ContributionAmount, int UWYear, int CWID, int AgencyID, string CheckNumber, DateTime UWDateCreated, DateTime UWDateLastEdited)
        {
            ContributionModel data = new ContributionModel
            {
           //     ContributionID = contributionID,
                UWType = UWType,
                UWMonthly = UWMonthly,
                UWMonths = UWMonths,
                uwcontributionamount = ContributionAmount,
                UWYear = UWYear,
                CWID = CWID,
                AgencyID = AgencyID,
                CheckNumber = CheckNumber,
                UWDateCreated = UWDateCreated,
                UWDateLastEdited = UWDateLastEdited
            };

            //sql for sending data to the database from the values above
            string sql = @"INSERT INTO Contribution (uwtype, uwmonths, uwyear, cwid, agencyid, checknumber, uwdatecreated, uwdateedited, uwmonthly, uwcontributionamount)
                        VALUES (@UWType, @UWMonths, @UWYear, @CWID, @AgencyID, @CheckNumber, @UWDateCreated, @UWDateLastEdited, @UWMonthly, @uwcontributionamount);";

            return SQLDataAccess.SaveData(sql, data);
        }

        //code for pulling the data from the agency table in the UW database
        public static List<ContributionModel> LoadContributions()
        {
            string sql = @"SELECT contributionid, uwtype, uwmonthly, uwmonths, uwcontributionamount, uwyear, cwid, agencyid,  checknumber, uwdatecreated, uwdateedited
                            FROM Contribution;";

            return SQLDataAccess.LoadData<ContributionModel>(sql);
        }


        public static List<ContributionListModel> LoadContributionList()

        {

            string sql = @"SELECT contributionid, C.cwid, C.uwdatecreated, C.uwdateedited, C.checknumber, e.employeefirstname, e.employeelastname, d.departmentname, d.division,
                            A.agencyname, C.uwtype, C.uwmonthly, C.uwmonths, C.uwcontributionamount, C.uwyear, C.uwdatecreated, C.uwdateedited
                            FROM Contribution (NOLOCK) C
                            INNER JOIN Employee (NOLOCK) E
                                ON C.cwid = E.cwid
                            INNER JOIN Department (NOLOCK) D
                                ON E.orgcode = D.orgcode
                            INNER JOIN Agency (NOLOCK) A
                                ON A.agencyid = C.agencyid;";



            return SQLDataAccess.LoadData<ContributionListModel>(sql);

        }

        public static int EditContribution(int ContributionID, string UWType, double UWMonthly, int UWMonths, double ContributionAmount, int UWYear, int CWID, int AgencyID, 
                                            string CheckNumber, DateTime UWDateCreated, DateTime UWDateLastEdited)
        {
            ContributionModel data = new ContributionModel
            {
                ContributionID = ContributionID,
                UWType = UWType,
                UWMonthly = UWMonthly,
                UWMonths = UWMonths,
                uwcontributionamount = ContributionAmount,
                UWYear = UWYear,
                CWID = CWID,
                AgencyID = AgencyID,
                CheckNumber = CheckNumber,
                UWDateCreated = UWDateCreated,
                UWDateLastEdited = UWDateLastEdited
            };

            string sql = @"UPDATE Contribution
                            SET uwtype = @UWType, uwmonthly = @UWMonthly, uwmonths = @UWMonths, uwyear = @UWYear, 
                            cwid = @CWID, agencyid = @AgencyID, checknumber = @CheckNumber, 
                            uwdateedited = @UWDateLastEdited
                            WHERE contributionid = @ContributionID;";

            return SQLDataAccess.SaveData(sql, data);
        }

        public static int DeleteContribution(int ContributionID, string UWType, double UWMonthly, int UWMonths, double ContributionAmount, int UWYear, int CWID, int AgencyID,
                                            string CheckNumber, DateTime UWDateCreated, DateTime UWDateLastEdited)
        {
            ContributionModel data = new ContributionModel
            {
                ContributionID = ContributionID,
                UWType = UWType,
                UWMonthly = UWMonthly,
                UWMonths = UWMonths,
                uwcontributionamount = ContributionAmount,
                UWYear = UWYear,
                CWID = CWID,
                AgencyID = AgencyID,
                CheckNumber = CheckNumber,
                UWDateCreated = UWDateCreated,
                UWDateLastEdited = UWDateLastEdited
            };

            string sql = @"DELETE FROM Contribution
                           WHERE contributionid = @ContributionID;";

            return SQLDataAccess.SaveData(sql, data);
        }

        public static int UpdateContributionAgency(int ContributionID, string UWType, double UWMonthly, int UWMonths, double ContributionAmount, int UWYear, int CWID, int AgencyID,
                                            string CheckNumber, DateTime UWDateCreated, DateTime UWDateLastEdited)
        {
            ContributionModel data = new ContributionModel
            {
                ContributionID = ContributionID,
                UWType = UWType,
                UWMonthly = UWMonthly,
                UWMonths = UWMonths,
                uwcontributionamount = ContributionAmount,
                UWYear = UWYear,
                CWID = CWID,
                AgencyID = AgencyID,
                CheckNumber = CheckNumber,
                UWDateCreated = UWDateCreated,
                UWDateLastEdited = UWDateLastEdited
            };

            string sql = @"UPDATE Contribution
                            SET agencyid = 0
                            WHERE agencyid = @AgencyID;";

            return SQLDataAccess.SaveData(sql, data);
        }
    }
}
