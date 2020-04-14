using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace UnitedWayPrototypeApplication.Models
{
    public class DepartmentReportModel
    {
        [Display(Name = "Division")]
        public string Division { get; set; }
        [Display(Name = "Curr Total")]
        [DataType(DataType.Currency)]
        public double CurrTotal { get; set; }
        [Display(Name = "Curr Avg")]
        [DataType(DataType.Currency)]
        public double CurrAvg { get; set; }
        [Display(Name = "Donor Count")]
        public double DonorCount { get; set; }
        [Display(Name = "Emp Count")]
        public double EmployeeCount { get; set; }
        [Display(Name = "% Participation")]
        [DisplayFormat(DataFormatString = @"{0:0.00}%")]
        public double PercentParticipation { get; set; }

    }
}