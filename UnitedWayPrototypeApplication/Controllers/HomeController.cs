using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitedWayPrototypeApplication.Models;
using DataLibrary;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
//use comments on code

namespace UnitedWayPrototypeApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //employee overview, the list of all employees in the system
        public ActionResult Employee(string searchBy, string search)
        {
            ViewBag.Message = "Employee Overview";

            //using the SQL SELECT statements in EmployeeProcessor to LOAD the employees to a list
            var data = DataLibrary.BusinessLogic.EmployeeProcessor.LoadEmployees();
            List<EmployeeModel> employees = new List<EmployeeModel>();

            // creating new row for each record
            foreach (var row in data)
            {
                employees.Add(new EmployeeModel
                {
                    CWID = row.CWID,
                    EmployeeFirstName = row.EmployeeFirstName,
                    EmployeeLastName = row.EmployeeLastName,
                    EmployeeMI = row.EmployeeMI,
                    StreetAddress = row.StreetAddress,
                    EmployeeCity = row.EmployeeCity,
                    EmployeeState = row.EmployeeState,
                    EmployeeZip = row.EmployeeZip,
                    EmployeeDepartment = row.EmployeeDepartment,
                    OrgCode = row.OrgCode,
                    EmployeeStatus = row.EmployeeStatus,
                    EmployeeDateCreated = row.EmployeeDateCreated,
                    EmployeeLastEdited = row.EmployeeLastEdited,
                    Payroll = row.Payroll,
                    Salary = row.Salary,
                    POBox = row.POBox,
                    POBoxCity = row.POBoxCity,
                    POBoxState = row.POBoxState
                }); ;
            }
            if (searchBy == "EmployeeFirstName")
            {
                return View(employees.Where(x => x.EmployeeFirstName.ToLower().StartsWith(search.ToLower()) || search == null).ToList());
            }
            else if (searchBy == "EmployeeLastName")
            {
                return View(employees.Where(x => x.EmployeeLastName.ToLower().StartsWith(search.ToLower()) || search == null).ToList());
            }
            else
            {
                return View(employees);
            }
        }

        public ActionResult SortEmployeeList(string name)
        {
            ViewBag.Message = "Sort Employee List";
            //utilizing the SQL SELECT statements in ContributionProcessor to LOAD the contributions
            var data = DataLibrary.BusinessLogic.EmployeeProcessor.LoadEmployees();
            //using the SQL SELECT statements in ContributionProcessor to LOAD the contributions to a list
            List<EmployeeModel> employees = new List<EmployeeModel>();
            //create new row for each record
            foreach (var row in data)
            {
                employees.Add(new EmployeeModel
                {
                    CWID = row.CWID,
                    EmployeeFirstName = row.EmployeeFirstName,
                    EmployeeLastName = row.EmployeeLastName,
                    EmployeeMI = row.EmployeeMI,
                    StreetAddress = row.StreetAddress,
                    EmployeeCity = row.EmployeeCity,
                    EmployeeState = row.EmployeeState,
                    EmployeeZip = row.EmployeeZip,
                    EmployeeDepartment = row.EmployeeDepartment,
                    OrgCode = row.OrgCode,
                    EmployeeStatus = row.EmployeeStatus,
                    EmployeeDateCreated = row.EmployeeDateCreated,
                    EmployeeLastEdited = row.EmployeeLastEdited,
                    Payroll = row.Payroll,
                    Salary = row.Salary,
                    POBox = row.POBox,
                    POBoxCity = row.POBoxCity,
                    POBoxState = row.POBoxState
                });
            }
            switch (name)
            {
                case "CWID":
                    employees = employees.OrderBy(x => x.CWID).ToList();
                    break;
                case "EmployeeFirstName":
                    employees = employees.OrderBy(x => x.EmployeeFirstName).ToList();
                    break;
                case "EmployeeLastName":
                    employees = employees.OrderBy(x => x.EmployeeLastName).ToList();
                    break;
                case "EmployeeMI":
                    employees = employees.OrderBy(x => x.EmployeeMI).ToList();
                    break;
                case "StreetAddress":
                    employees = employees.OrderBy(x => x.StreetAddress).ToList();
                    break;
                case "EmployeeCity":
                    employees = employees.OrderBy(x => x.EmployeeCity).ToList();
                    break;
                case "EmployeeState":
                    employees = employees.OrderBy(x => x.EmployeeState).ToList();
                    break;
                case "EmployeeZip":
                    employees = employees.OrderBy(x => x.EmployeeZip).ToList();
                    break;
                case "Payroll":
                    employees = employees.OrderBy(x => x.Payroll).ToList();
                    break;
                case "Salary":
                    employees = employees.OrderBy(x => x.Salary).ToList();
                    break;
                case "POBox":
                    employees = employees.OrderBy(x => x.POBox).ToList();
                    break;
                case "POBoxCity":
                    employees = employees.OrderBy(x => x.POBoxCity).ToList();
                    break;
                case "POBoxState":
                    employees = employees.OrderBy(x => x.POBoxState).ToList();
                    break;
                case "OrgCode":
                    employees = employees.OrderBy(x => x.OrgCode).ToList();
                    break;
            }


            return View(employees);
        }

        public ActionResult SortDescendingEmployeeList(string name)
        {
            ViewBag.Message = "Sort Descending Employee List";
            //utilizing the SQL SELECT statements in ContributionProcessor to LOAD the contributions
            var data = DataLibrary.BusinessLogic.EmployeeProcessor.LoadEmployees();
            //using the SQL SELECT statements in ContributionProcessor to LOAD the contributions to a list
            List<EmployeeModel> employees = new List<EmployeeModel>();
            //create new row for each record
            foreach (var row in data)
            {
                employees.Add(new EmployeeModel
                {
                    CWID = row.CWID,
                    EmployeeFirstName = row.EmployeeFirstName,
                    EmployeeLastName = row.EmployeeLastName,
                    EmployeeMI = row.EmployeeMI,
                    StreetAddress = row.StreetAddress,
                    EmployeeCity = row.EmployeeCity,
                    EmployeeState = row.EmployeeState,
                    EmployeeZip = row.EmployeeZip,
                    EmployeeDepartment = row.EmployeeDepartment,
                    OrgCode = row.OrgCode,
                    EmployeeStatus = row.EmployeeStatus,
                    EmployeeDateCreated = row.EmployeeDateCreated,
                    EmployeeLastEdited = row.EmployeeLastEdited,
                    Payroll = row.Payroll,
                    Salary = row.Salary,
                    POBox = row.POBox,
                    POBoxCity = row.POBoxCity,
                    POBoxState = row.POBoxState
                });
            }
            switch (name)
            {
                case "CWID":
                    employees = employees.OrderByDescending(x => x.CWID).ToList();
                    break;
                case "EmployeeFirstName":
                    employees = employees.OrderByDescending(x => x.EmployeeFirstName).ToList();
                    break;
                case "EmployeeLastName":
                    employees = employees.OrderByDescending(x => x.EmployeeLastName).ToList();
                    break;
                case "EmployeeMI":
                    employees = employees.OrderByDescending(x => x.EmployeeMI).ToList();
                    break;
                case "StreetAddress":
                    employees = employees.OrderByDescending(x => x.StreetAddress).ToList();
                    break;
                case "EmployeeCity":
                    employees = employees.OrderByDescending(x => x.EmployeeCity).ToList();
                    break;
                case "EmployeeState":
                    employees = employees.OrderByDescending(x => x.EmployeeState).ToList();
                    break;
                case "EmployeeZip":
                    employees = employees.OrderByDescending(x => x.EmployeeZip).ToList();
                    break;
                case "Payroll":
                    employees = employees.OrderByDescending(x => x.Payroll).ToList();
                    break;
                case "Salary":
                    employees = employees.OrderByDescending(x => x.Salary).ToList();
                    break;
                case "POBox":
                    employees = employees.OrderByDescending(x => x.POBox).ToList();
                    break;
                case "POBoxCity":
                    employees = employees.OrderByDescending(x => x.POBoxCity).ToList();
                    break;
                case "POBoxState":
                    employees = employees.OrderByDescending(x => x.POBoxState).ToList();
                    break;
                case "OrgCode":
                    employees = employees.OrderByDescending(x => x.OrgCode).ToList();
                    break;
            }


            return View(employees);
        }
        //form for creating an employee
        public ActionResult EmployeeCreate()
        {
            ViewBag.Message = "Create new Employee";

            return View();
        }
        //catching the information entered in the employee create form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeeCreate(EmployeeModel model)
        {
            //if the model (data) is valid, create the employee in the database using these parameters
            if (ModelState.IsValid)
            {
                DataLibrary.BusinessLogic.EmployeeProcessor.CreateEmployee(model.CWID, model.EmployeeFirstName, model.EmployeeLastName, model.EmployeeMI, model.StreetAddress, model.EmployeeCity, model.EmployeeState, model.EmployeeZip,
                    model.Payroll, model.Salary, model.POBox, model.POBoxCity, model.POBoxState, model.OrgCode, model.EmployeeDepartment, model.EmployeeStatus, model.EmployeeDateCreated, model.EmployeeLastEdited);
                return RedirectToAction("Employee");
            }

            ViewBag.Message = "Create new Employee";

            ModelState.Clear();
            return View();
        }

        public ActionResult EditEmployee(string cwid)
        {
            ViewBag.Message = "Edit Employee";

            EmployeeModel emp = new UnitedWayPrototypeApplication.Models.EmployeeModel();

            int Cwid = Int32.Parse(cwid);

            var data = DataLibrary.BusinessLogic.EmployeeProcessor.LoadEmployees();

            List<EmployeeModel> employees = new List<EmployeeModel>();
            //create new row for each record
            foreach (var row in data)
            {
                employees.Add(new EmployeeModel
                {
                    CWID = row.CWID,
                    EmployeeFirstName = row.EmployeeFirstName,
                    EmployeeLastName = row.EmployeeLastName,
                    EmployeeMI = row.EmployeeMI,
                    StreetAddress = row.StreetAddress,
                    EmployeeCity = row.EmployeeCity,
                    EmployeeState = row.EmployeeState,
                    EmployeeZip = row.EmployeeZip,
                    EmployeeDepartment = row.EmployeeDepartment,
                    OrgCode = row.OrgCode,
                    EmployeeStatus = row.EmployeeStatus,
                    EmployeeDateCreated = row.EmployeeDateCreated,
                    EmployeeLastEdited = row.EmployeeLastEdited,
                    Payroll = row.Payroll,
                    Salary = row.Salary,
                    POBox = row.POBox,
                    POBoxCity = row.POBoxCity,
                    POBoxState = row.POBoxState
                });
            }
            //using the SQL SELECT statements in ContributionProcessor to LOAD the contributions to a list
            //create new row for each record
            foreach (var row in employees)
            {
                if (row.CWID == Cwid)
                {
                    emp = row;
                }
            }

            ViewData["Employee"] = emp;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployee(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                model.EmployeeLastEdited = DateTime.Now;
                DataLibrary.BusinessLogic.EmployeeProcessor.EditEmployee(model.CWID, model.EmployeeFirstName, model.EmployeeLastName, model.EmployeeMI, model.StreetAddress, model.EmployeeCity, model.EmployeeState, model.EmployeeZip,
                    model.Payroll, model.Salary, model.POBox, model.POBoxCity, model.POBoxState, model.OrgCode, model.EmployeeDepartment, model.EmployeeStatus, model.EmployeeDateCreated, model.EmployeeLastEdited);
                return RedirectToAction("Employee");
            }
            return View();
        }

        public ActionResult Agency()
        {
            ViewBag.Message = "Agency Overview";
            //utilizing the SQL SELECT statements in AgencyProcessor to LOAD the agencies
            var data = DataLibrary.BusinessLogic.AgencyProcessor.LoadAgencies();

            //using the SQL SELECT statements in AgencyProcessor to LOAD the agencies to a list
            List<AgencyModel> agencies = new List<AgencyModel>();
            //create new row for each record
            foreach (var row in data)
            {
                agencies.Add(new AgencyModel
                {
                    AgencyID = row.AgencyID,
                    AgencyName = row.AgencyName,
                    AgencyStatus = row.AgencyStatus,
                    AgencyDateCreated = row.AgencyDateCreated,
                    AgencyDateLastEdited = row.AgencyDateLastEdited
                });
            }

            return View(agencies);
        }

        public ActionResult SortAgencyList(string name)
        {
            ViewBag.Message = "Sort Agency List";
            //utilizing the SQL SELECT statements in ContributionProcessor to LOAD the contributions
            var data = DataLibrary.BusinessLogic.AgencyProcessor.LoadAgencies();
            //using the SQL SELECT statements in ContributionProcessor to LOAD the contributions to a list
            List<AgencyModel> agencies = new List<AgencyModel>();
            //create new row for each record
            foreach (var row in data)
            {
                agencies.Add(new AgencyModel
                {
                    AgencyID = row.AgencyID,
                    AgencyName = row.AgencyName,
                    AgencyStatus = row.AgencyStatus,
                    AgencyDateCreated = row.AgencyDateCreated,
                    AgencyDateLastEdited = row.AgencyDateLastEdited
                });
            }
            switch (name)
            {
                case "AgencyID":
                    agencies = agencies.OrderBy(x => x.AgencyID).ToList();
                    break;
                case "AgencyName":
                    agencies = agencies.OrderBy(x => x.AgencyName).ToList();
                    break;
            }
            return View(agencies);
        }

        public ActionResult SortDescendingAgencyList(string name)
        {
            ViewBag.Message = "Sort Descending Agency List";
            //utilizing the SQL SELECT statements in ContributionProcessor to LOAD the contributions
            var data = DataLibrary.BusinessLogic.AgencyProcessor.LoadAgencies();
            //using the SQL SELECT statements in ContributionProcessor to LOAD the contributions to a list
            List<AgencyModel> agencies = new List<AgencyModel>();
            //create new row for each record
            foreach (var row in data)
            {
                agencies.Add(new AgencyModel
                {
                    AgencyID = row.AgencyID,
                    AgencyName = row.AgencyName,
                    AgencyStatus = row.AgencyStatus,
                    AgencyDateCreated = row.AgencyDateCreated,
                    AgencyDateLastEdited = row.AgencyDateLastEdited
                });
            }
            switch (name)
            {
                case "AgencyID":
                    agencies = agencies.OrderByDescending(x => x.AgencyID).ToList();
                    break;
                case "AgencyName":
                    agencies = agencies.OrderByDescending(x => x.AgencyName).ToList();
                    break;
            }
            return View(agencies);
        }
        public ActionResult CreateAgency()
        {
            ViewBag.Message = "Create new Agency";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAgency(AgencyModel model)
        {
            ViewBag.Message = "Create new Agency";

            if (ModelState.IsValid)
            {
                DataLibrary.BusinessLogic.AgencyProcessor.CreateAgency(model.AgencyID, model.AgencyName, model.AgencyStatus, model.AgencyDateCreated, model.AgencyDateLastEdited);
                return RedirectToAction("Agency");
            }

            ModelState.Clear();
            return View();
        }


        public ActionResult EditAgency(string id, string name)
        {
            ViewBag.Message = "Edit Agency";
            AgencyModel agency = new UnitedWayPrototypeApplication.Models.AgencyModel();
            agency.AgencyID = Int32.Parse(id);
            agency.AgencyName = name;
            ViewData["Agency"] = agency;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAgency(AgencyModel model)

        {
            if (ModelState.IsValid)

            {
                model.AgencyDateLastEdited = DateTime.Now;
                DataLibrary.BusinessLogic.AgencyProcessor.EditAgency(model.AgencyID, model.AgencyName, model.AgencyStatus, model.AgencyDateCreated, model.AgencyDateLastEdited);
                return RedirectToAction("Agency");
            }
            return View();
        }


        public ActionResult Contribution()
        {
            ViewBag.Message = "Contribution Overview";
            //utilizing the SQL SELECT statements in ContributionProcessor to LOAD the contributions
            var data = DataLibrary.BusinessLogic.ContributionProcessor.LoadContributions();

            //using the SQL SELECT statements in ContributionProcessor to LOAD the contributions to a list
            List<ContributionModel> contributions = new List<ContributionModel>();
            //create new row for each record
            foreach (var row in data)
            {
                contributions.Add(new ContributionModel
                {
                    ContributionID = row.ContributionID,
                    UWType = row.UWType,
                    UWMonthly = row.UWMonthly,
                    UWMonths = row.UWMonths,
                    uwcontributionamount = row.uwcontributionamount,
                    UWYear = row.UWYear,
                    CWID = row.CWID,
                    AgencyID = row.AgencyID,
                    CheckNumber = row.CheckNumber,
                    UWDateCreated = row.UWDateCreated,
                    UWDateLastEdited = row.UWDateLastEdited
                });
            }

            return View(contributions);
        }

        public ActionResult ContributionList(string searchBy, string search)
        {
            ViewBag.Message = "Contribution List Overview";

            //utilizing the SQL SELECT statements in ContributionProcessor to LOAD the contributions
            var data = DataLibrary.BusinessLogic.ContributionProcessor.LoadContributionList();

            //using the SQL SELECT statements in ContributionProcessor to LOAD the contributions to a list
            List<ContributionListModel> contributionlist = new List<ContributionListModel>();
            //create new row for each record
            foreach (var row in data)
            {
                contributionlist.Add(new ContributionListModel
                {
                    ContributionID = row.ContributionID,
                    CWID = row.CWID,
                    EmployeeFirstName = row.EmployeeFirstName,
                    EmployeeLastName = row.EmployeeLastName,
                    Division = row.Division,
                    DepartmentName = row.DepartmentName,
                    AgencyName = row.AgencyName,
                    UWType = row.UWType,
                    UWMonthly = row.UWMonthly,
                    UWMonths = row.UWMonths,
                    uwcontributionamount = row.uwcontributionamount,
                    UWYear = row.UWYear
                });
            }

            if (searchBy == "EmployeeFirstName")
            {
                return View(contributionlist.Where(x => x.EmployeeFirstName.ToLower().StartsWith(search.ToLower()) || search == null).ToList());
            }
            else if (searchBy == "EmployeeLastName")
            {
                return View(contributionlist.Where(x => x.EmployeeLastName.ToLower().StartsWith(search.ToLower()) || search == null).ToList());
            }
            else
            {
                return View(contributionlist);
            }


            // View(contributionlist);
        }


        public ActionResult CreateContribution()
        {
            ViewBag.Message = "Enter new Contribution";


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateContribution(ContributionModel model)
        {
            // Try-Catch in case a non-existing cwid (not matching any on the db) is entered. Should throw the ExistingCwidError page and prompt for resubmission - MD
            // May need to be adjusted. Currently, it could be throwing the ExistingCwidError page regardless of the error that is thrown on the create contribution page -MD

            try
            {
                ViewBag.Message = "Create new Contribution";

                if (ModelState.IsValid)
                {
                    DataLibrary.BusinessLogic.ContributionProcessor.CreateContribution(model.UWType, model.UWMonthly, model.UWMonths, model.UWYear,
                        model.CWID, model.AgencyID, model.CheckNumber, model.UWDateCreated, model.UWDateLastEdited);
                    return RedirectToAction("ContributionList");
                }

                ModelState.Clear();
                return View();

            }
            catch (Exception CWID)
            {
                return View("ExistingCwidError", new HandleErrorInfo(CWID, "ContributionModel", "CreateContribution"));
            }
        }

        public ActionResult SortContributionList(string name)
        {
            ViewBag.Message = "Sort Contribution List";
            //utilizing the SQL SELECT statements in ContributionProcessor to LOAD the contributions
            var data = DataLibrary.BusinessLogic.ContributionProcessor.LoadContributionList();
            //using the SQL SELECT statements in ContributionProcessor to LOAD the contributions to a list
            List<ContributionListModel> contributiondisplay = new List<ContributionListModel>();
            //create new row for each record
            foreach (var row in data)
            {
                contributiondisplay.Add(new ContributionListModel
                {
                    ContributionID = row.ContributionID,
                    CWID = row.CWID,
                    EmployeeFirstName = row.EmployeeFirstName,
                    EmployeeLastName = row.EmployeeLastName,
                    Division = row.Division,
                    DepartmentName = row.DepartmentName,
                    AgencyName = row.AgencyName,
                    UWType = row.UWType,
                    UWMonthly = row.UWMonthly,
                    UWMonths = row.UWMonths,
                    uwcontributionamount = row.uwcontributionamount,
                    UWYear = row.UWYear
                });
            }
            switch (name)
            {
                case "ContributionID":
                    contributiondisplay = contributiondisplay.OrderBy(x => x.ContributionID).ToList();
                    break;
                case "CWID":
                    contributiondisplay = contributiondisplay.OrderBy(x => x.CWID).ToList();
                    break;
                case "EmployeeFirstName":
                    contributiondisplay = contributiondisplay.OrderBy(x => x.EmployeeFirstName).ToList();
                    break;
                case "EmployeeLastName":
                    contributiondisplay = contributiondisplay.OrderBy(x => x.EmployeeLastName).ToList();
                    break;
                case "Division":
                    contributiondisplay = contributiondisplay.OrderBy(x => x.Division).ToList();
                    break;
                case "Department":
                    contributiondisplay = contributiondisplay.OrderBy(x => x.DepartmentName).ToList();
                    break;
                case "UWType":
                    contributiondisplay = contributiondisplay.OrderBy(x => x.UWType).ToList();
                    break;
                case "UWMonthly":
                    contributiondisplay = contributiondisplay.OrderBy(x => x.UWMonthly).ToList();
                    break;
                case "UWMonths":
                    contributiondisplay = contributiondisplay.OrderBy(x => x.UWMonths).ToList();
                    break;
                case "uwcontributionamount":
                    contributiondisplay = contributiondisplay.OrderBy(x => x.uwcontributionamount).ToList();
                    break;
                case "AgencyName":
                    contributiondisplay = contributiondisplay.OrderBy(x => x.AgencyName).ToList();
                    break;
                case "UWyear":
                    contributiondisplay = contributiondisplay.OrderBy(x => x.UWYear).ToList();
                    break;
            }


            return View(contributiondisplay);
        }

        public ActionResult SortDescendingContributionList(string name)
        {
            ViewBag.Message = "Sort Descending Contribution List";
            //utilizing the SQL SELECT statements in ContributionProcessor to LOAD the contributions
            var data = DataLibrary.BusinessLogic.ContributionProcessor.LoadContributionList();
            //using the SQL SELECT statements in ContributionProcessor to LOAD the contributions to a list
            List<ContributionListModel> contributiondisplay = new List<ContributionListModel>();
            //create new row for each record
            foreach (var row in data)
            {
                contributiondisplay.Add(new ContributionListModel
                {
                    ContributionID = row.ContributionID,
                    CWID = row.CWID,
                    EmployeeFirstName = row.EmployeeFirstName,
                    EmployeeLastName = row.EmployeeLastName,
                    Division = row.Division,
                    DepartmentName = row.DepartmentName,
                    AgencyName = row.AgencyName,
                    UWType = row.UWType,
                    UWMonthly = row.UWMonthly,
                    UWMonths = row.UWMonths,
                    uwcontributionamount = row.uwcontributionamount,
                    UWYear = row.UWYear
                });
            }

            switch (name)
            {
                case "ContributionID":
                    contributiondisplay = contributiondisplay.OrderByDescending(x => x.ContributionID).ToList();
                    break;
                case "CWID":
                    contributiondisplay = contributiondisplay.OrderByDescending(x => x.CWID).ToList();
                    break;
                case "EmployeeFirstName":
                    contributiondisplay = contributiondisplay.OrderByDescending(x => x.EmployeeFirstName).ToList();
                    break;
                case "EmployeeLastName":
                    contributiondisplay = contributiondisplay.OrderByDescending(x => x.EmployeeLastName).ToList();
                    break;
                case "Division":
                    contributiondisplay = contributiondisplay.OrderByDescending(x => x.Division).ToList();
                    break;
                case "Department":
                    contributiondisplay = contributiondisplay.OrderByDescending(x => x.DepartmentName).ToList();
                    break;
                case "UWType":
                    contributiondisplay = contributiondisplay.OrderByDescending(x => x.UWType).ToList();
                    break;
                case "UWMonthly":
                    contributiondisplay = contributiondisplay.OrderByDescending(x => x.UWMonthly).ToList();
                    break;
                case "UWMonths":
                    contributiondisplay = contributiondisplay.OrderByDescending(x => x.UWMonths).ToList();
                    break;
                case "uwcontributionamount":
                    contributiondisplay = contributiondisplay.OrderByDescending(x => x.uwcontributionamount).ToList();
                    break;
                case "AgencyName":
                    contributiondisplay = contributiondisplay.OrderByDescending(x => x.AgencyName).ToList();
                    break;
                case "UWyear":
                    contributiondisplay = contributiondisplay.OrderByDescending(x => x.UWYear).ToList();
                    break;
            }
            return View(contributiondisplay);
        }

        public ActionResult EditContribution(string contributionid)
        {
            ViewBag.Message = "Edit Contribution";

            ContributionModel contr = new UnitedWayPrototypeApplication.Models.ContributionModel();

            int cid = Int32.Parse(contributionid);

            var data = DataLibrary.BusinessLogic.ContributionProcessor.LoadContributions();

            List<ContributionModel> contributions = new List<ContributionModel>();
            //create new row for each record
            foreach (var row in data)
            {
                contributions.Add(new ContributionModel
                {
                    ContributionID = row.ContributionID,
                    UWType = row.UWType,
                    UWMonthly = row.UWMonthly,
                    UWMonths = row.UWMonths,
                    uwcontributionamount = row.uwcontributionamount,
                    UWYear = row.UWYear,
                    CWID = row.CWID,
                    AgencyID = row.AgencyID,
                    CheckNumber = row.CheckNumber,
                    UWDateCreated = row.UWDateCreated,
                    UWDateLastEdited = row.UWDateLastEdited
                });
            }
            //using the SQL SELECT statements in ContributionProcessor to LOAD the contributions to a list
            //create new row for each record
            foreach (var row in contributions)
            {
                if (row.ContributionID == cid)
                {
                    contr = row;
                }
            }

            ViewData["Contribution"] = contr;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditContribution(ContributionModel model)
        {
            if (ModelState.IsValid)
            {
                model.UWDateLastEdited = DateTime.Now;
                DataLibrary.BusinessLogic.ContributionProcessor.EditContribution(model.ContributionID, model.UWType, model.UWMonthly, model.UWMonths, model.UWYear,
                        model.CWID, model.AgencyID, model.CheckNumber, model.UWDateCreated, model.UWDateLastEdited);
                return RedirectToAction("ContributionList");
            }
            return View();
        }

        public ActionResult DeleteContribution(string contributionid)
        {
            ViewBag.Message = "Delete Contribution";

            ContributionModel contr = new UnitedWayPrototypeApplication.Models.ContributionModel();

            int cid = Int32.Parse(contributionid);

            var data = DataLibrary.BusinessLogic.ContributionProcessor.LoadContributions();

            List<ContributionModel> contributions = new List<ContributionModel>();
            //create new row for each record
            foreach (var row in data)
            {
                contributions.Add(new ContributionModel
                {
                    ContributionID = row.ContributionID,
                    UWType = row.UWType,
                    UWMonthly = row.UWMonthly,
                    UWMonths = row.UWMonths,
                    uwcontributionamount = row.uwcontributionamount,
                    UWYear = row.UWYear,
                    CWID = row.CWID,
                    AgencyID = row.AgencyID,
                    CheckNumber = row.CheckNumber,
                    UWDateCreated = row.UWDateCreated,
                    UWDateLastEdited = row.UWDateLastEdited
                });
            }
            //using the SQL SELECT statements in ContributionProcessor to LOAD the contributions to a list
            //create new row for each record
            foreach (var row in contributions)
            {
                if (row.ContributionID == cid)
                {
                    contr = row;
                }
            }

            ViewData["Contribution"] = contr;

            return View();
        }
 
        //department overview, shows all departments in a list
        public ActionResult Department()
        {
            ViewBag.Message = "Department Overview";

            //able to use that SQL SELECT statement from DepartmentProcessor, use for each to loop through all data
            var data = DataLibrary.BusinessLogic.DepartmentProcessor.LoadDepartments();
            List<DepartmentModel> departments = new List<DepartmentModel>();


            foreach (var row in data)
            {
                departments.Add(new DepartmentModel
                {
                    OrgCode = row.OrgCode,
                    departmentname = row.departmentname,
                    UWCoordinator3 = row.UWCoordinator3,
                    UWCoordinator2 = row.UWCoordinator2,
                    UWCoordinator1 = row.UWCoordinator1,
                    Division = row.Division,
                    DepartmentStatus = row.DepartmentStatus,
                    DepartmentDateCreated = row.DepartmentDateCreated,
                    DepartmentLastEdited = row.DepartmentLastEdited
                });
            }


            return View(departments);
        }

        public ActionResult SortDepartmentList(string name)
        {
            ViewBag.Message = "Sort Department List";
            //utilizing the SQL SELECT statements in ContributionProcessor to LOAD the contributions
            var data = DataLibrary.BusinessLogic.DepartmentProcessor.LoadDepartments();
            //using the SQL SELECT statements in ContributionProcessor to LOAD the contributions to a list
            List<DepartmentModel> departments = new List<DepartmentModel>();
            //create new row for each record
            foreach (var row in data)
            {
                departments.Add(new DepartmentModel
                {
                    OrgCode = row.OrgCode,
                    departmentname = row.departmentname,
                    UWCoordinator3 = row.UWCoordinator3,
                    UWCoordinator2 = row.UWCoordinator2,
                    UWCoordinator1 = row.UWCoordinator1,
                    Division = row.Division,
                    DepartmentStatus = row.DepartmentStatus,
                    DepartmentDateCreated = row.DepartmentDateCreated,
                    DepartmentLastEdited = row.DepartmentLastEdited
                });
            }
            switch (name)
            {
                case "OrgCode":
                    departments = departments.OrderBy(x => x.OrgCode).ToList();
                    break;
                case "Division":
                    departments = departments.OrderBy(x => x.Division).ToList();
                    break;
                case "Department":
                    departments = departments.OrderBy(x => x.departmentname).ToList();
                    break;
                case "UW3":
                    departments = departments.OrderBy(x => x.UWCoordinator3).ToList();
                    break;
                case "UW2":
                    departments = departments.OrderBy(x => x.UWCoordinator2).ToList();
                    break;
                case "UW1":
                    departments = departments.OrderBy(x => x.UWCoordinator1).ToList();
                    break;
            }
            return View(departments);
        }

        public ActionResult SortDescendingDepartmentList(string name)
        {
            ViewBag.Message = "Sort Descending Department List";
            //utilizing the SQL SELECT statements in ContributionProcessor to LOAD the contributions
            var data = DataLibrary.BusinessLogic.DepartmentProcessor.LoadDepartments();
            //using the SQL SELECT statements in ContributionProcessor to LOAD the contributions to a list
            List<DepartmentModel> departments = new List<DepartmentModel>();
            //create new row for each record
            foreach (var row in data)
            {
                departments.Add(new DepartmentModel
                {
                    OrgCode = row.OrgCode,
                    departmentname = row.departmentname,
                    UWCoordinator3 = row.UWCoordinator3,
                    UWCoordinator2 = row.UWCoordinator2,
                    UWCoordinator1 = row.UWCoordinator1,
                    Division = row.Division,
                    DepartmentStatus = row.DepartmentStatus,
                    DepartmentDateCreated = row.DepartmentDateCreated,
                    DepartmentLastEdited = row.DepartmentLastEdited
                });
            }
            switch (name)
            {
                case "OrgCode":
                    departments = departments.OrderByDescending(x => x.OrgCode).ToList();
                    break;
                case "Division":
                    departments = departments.OrderByDescending(x => x.Division).ToList();
                    break;
                case "Department":
                    departments = departments.OrderByDescending(x => x.departmentname).ToList();
                    break;
                case "UW3":
                    departments = departments.OrderByDescending(x => x.UWCoordinator3).ToList();
                    break;
                case "UW2":
                    departments = departments.OrderByDescending(x => x.UWCoordinator2).ToList();
                    break;
                case "UW1":
                    departments = departments.OrderByDescending(x => x.UWCoordinator1).ToList();
                    break;
            }
            return View(departments);
        }
        //form for creating a new department
        public ActionResult CreateDepartment()
        {
            ViewBag.Message = "Create new Department";

            return View();
        }

        //catching the information from the create department form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDepartment(DepartmentModel model)
        {
            //checking if the data sent from the form is valid 
            if (ModelState.IsValid)
            {
                DataLibrary.BusinessLogic.DepartmentProcessor.CreateDepartment(model.OrgCode, model.departmentname, model.UWCoordinator3, model.UWCoordinator2, model.UWCoordinator1, model.Division,
                    model.DepartmentStatus, model.DepartmentDateCreated, model.DepartmentLastEdited);
                return RedirectToAction("Department");
            }

            ModelState.Clear();
            return View();
        }

        // Creates forms for editing department
        public ActionResult EditDepartment(string orgcode)
        {
            ViewBag.Message = "Edit Department";

            DepartmentModel dept = new UnitedWayPrototypeApplication.Models.DepartmentModel();

            int OrgCode = Int32.Parse(orgcode);

            var data = DataLibrary.BusinessLogic.DepartmentProcessor.LoadDepartments();

            List<DepartmentModel> departments = new List<DepartmentModel>();
            //create new row for each record
            foreach (var row in data)
            {
                departments.Add(new DepartmentModel
                {
                    OrgCode = row.OrgCode,
                    departmentname = row.departmentname,
                    UWCoordinator3 = row.UWCoordinator3,
                    UWCoordinator2 = row.UWCoordinator2,
                    UWCoordinator1 = row.UWCoordinator1,
                    Division = row.Division,
                    DepartmentStatus = row.DepartmentStatus,
                    DepartmentDateCreated = row.DepartmentDateCreated,
                    DepartmentLastEdited = row.DepartmentLastEdited
                });
            }
            //using the SQL SELECT statements in ContributionProcessor to LOAD the contributions to a list
            //create new row for each record
            foreach (var row in departments)
            {
                if (row.OrgCode == OrgCode)
                {
                    dept = row;
                }
            }

            ViewData["Department"] = dept;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDepartment(DepartmentModel model)
        {
            if (ModelState.IsValid)
            {
                model.DepartmentLastEdited = DateTime.Now;
                DataLibrary.BusinessLogic.DepartmentProcessor.EditDepartment(model.OrgCode, model.departmentname, model.UWCoordinator3, model.UWCoordinator2, model.UWCoordinator1, model.Division,
                    model.DepartmentStatus, model.DepartmentDateCreated, model.DepartmentLastEdited);
                return RedirectToAction("Department");
            }
            return View();
        }


        //controller for importing excel files
        [HttpPost]
        public ActionResult ExcelImport(ImportExcel importExcel)
        {
            if (ModelState.IsValid)
            {
                string filePath = Server.MapPath("~/Content/Upload/" + importExcel.file.FileName);
                importExcel.file.SaveAs(filePath);

                //connection string for file
                string excelConnectionString = @"Provider='Microsoft.ACE.OLEDB.12.0';Data Source='" + filePath + "';Extended Properties='Excel 12.0 Xml;IMEX=1'";
                OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);

                //Open connection, retrieve sheet name, close when done
                excelConnection.Open();
                string tableName = excelConnection.GetSchema("Tables").Rows[0]["TABLE_NAME"].ToString();
                excelConnection.Close();

                //Selecting headers needed, setting status to active, setting date of import as date created
                OleDbCommand cmd = new OleDbCommand("SELECT CWID, LastName, FirstName, MI, StreetAddress1, City, State, Zip, Payroll, Salary, POBox, POBoxCity, POBoxState, Org, 1 as status, DATE() as empdatecreated  FROM [" + tableName + "]", excelConnection);

                //opening connection
                excelConnection.Open();

                //reading data
                OleDbDataReader dReader;
                dReader = cmd.ExecuteReader();
                SqlBulkCopy sqlBulk = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["UnitedWay"].ConnectionString);

                //where data should be stored
                sqlBulk.DestinationTableName = "Employee";

                //mappings
                sqlBulk.ColumnMappings.Add("CWID", "cwid");
                sqlBulk.ColumnMappings.Add("LastName", "employeelastname");
                sqlBulk.ColumnMappings.Add("FirstName", "employeefirstname");
                sqlBulk.ColumnMappings.Add("MI", "employeemi");
                sqlBulk.ColumnMappings.Add("StreetAddress1", "streetaddress");
                sqlBulk.ColumnMappings.Add("City", "employeecity");
                sqlBulk.ColumnMappings.Add("State", "employeestate");
                sqlBulk.ColumnMappings.Add("Zip", "employeezip");
                sqlBulk.ColumnMappings.Add("Payroll", "payroll");
                sqlBulk.ColumnMappings.Add("Salary", "salary");
                sqlBulk.ColumnMappings.Add("POBox", "pobox");
                sqlBulk.ColumnMappings.Add("POBoxCity", "poboxcity");
                sqlBulk.ColumnMappings.Add("status", "employeestatus");
                sqlBulk.ColumnMappings.Add("empdatecreated", "employeedatecreated");
                sqlBulk.ColumnMappings.Add("Org", "orgcode");
                sqlBulk.ColumnMappings.Add("POBoxState", "poboxstate");

                //write to and close connection
                sqlBulk.WriteToServer(dReader);
                excelConnection.Close();

                ViewBag.Result = "Successfully Imported";

            }

            return View();
        }

        [HttpPost]
        public ActionResult DepartmentImport(ImportDepartment importDepartment)
        {
            if (ModelState.IsValid)
            {
                string path = Server.MapPath("~/Content/Upload/" + importDepartment.file.FileName);
                importDepartment.file.SaveAs(path);

                //connection string for file
                string excelConnectionString = @"Provider='Microsoft.ACE.OLEDB.12.0';Data Source='" + path + "';Extended Properties='Excel 12.0 Xml;IMEX=1'";
                OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);

                //Open connection, retrieve sheet name, close when done
                excelConnection.Open();
                string tableName = excelConnection.GetSchema("Tables").Rows[0]["TABLE_NAME"].ToString();
                excelConnection.Close();

                //Selecting headers needed, setting status to active, setting date of import as date created
                OleDbCommand cmd = new OleDbCommand("SELECT Org, Division, Department, UWCoordinator3, UWCoordinator2, UWCoordinator1, 1 as status, DATE() as deptdatecreated  FROM [" + tableName + "]", excelConnection);

                //opening connection
                excelConnection.Open();

                //reading data
                OleDbDataReader dReader;
                dReader = cmd.ExecuteReader();
                SqlBulkCopy sqlBulk = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["UnitedWay"].ConnectionString);

                //where data should be stored
                sqlBulk.DestinationTableName = "Department";

                //mappings
                sqlBulk.ColumnMappings.Add("Org", "orgcode");
                sqlBulk.ColumnMappings.Add("UWCoordinator3", "uwcoordinator3");
                sqlBulk.ColumnMappings.Add("UWCoordinator2", "uwcoordinator2");
                sqlBulk.ColumnMappings.Add("UWCoordinator1", "uwcoordinator1");
                sqlBulk.ColumnMappings.Add("Division", "division");
                sqlBulk.ColumnMappings.Add("Department", "departmentname");
                sqlBulk.ColumnMappings.Add("status", "departmentstatus");
                sqlBulk.ColumnMappings.Add("deptdatecreated", "departmentdatecreated");

                //write to and close connection
                sqlBulk.WriteToServer(dReader);
                excelConnection.Close();

                ViewBag.Result = "Successfully Imported";

            }

            return View();
        }



    }
}