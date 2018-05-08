using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class PayrollPeriodViewModel
    {
        public int Id { get; set; }
        public int PeriodYear { get; set; }
        public int PreiodMonth { get; set; }
        public string Description
        {
            get
            {
                if (PreiodMonth > 0)
                {
                    return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(PreiodMonth) + " " + PeriodYear.ToString();
                }
                else
                {
                    return "No Selected Period";
                }
            }
        }
        public System.DateTime BeginDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public bool IsCurrentPeriod { get; set; }
        public bool IsActivated { get; set; }
    }
}
