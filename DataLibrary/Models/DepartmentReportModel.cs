using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class DepartmentReportModel
    {
        public string Division { get; set; }
        public double CurrTotal { get; set; }
        public double CurrAvg { get; set; }
        public int DonorCount { get; set; }
        public int EmployeeCount { get; set; }
        public double PercentParticipation { get; set; }
    }
}
