using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        public string BadgeId { get; set; }

        public int JobPositionId { get; set; }

        [Display(Name ="Job Position")]
        public string JobPositionName { get; set; }

        [Display(Name = "Job Position")]
        public string JobPositionCode { get; set; }

        [Display(Name = "Job Position")]
        public string JobCodeName
        {
            get
            {
                return "[" + JobPositionCode + "] " + JobPositionName;
            }
        }

        [Display(Name = "Department")]
        public int DepartementId { get; set; }

        [Display(Name = "Department")]
        public string DepartementName { get; set; }

        [Display(Name = "Department")]
        public string DepartementCode { get; set; }

        [Display(Name = "Department")]
        public string DepCodeName
        {
            get
            {
                return "[" + DepartementCode + "] " + DepartementName;
            }
        }

        [Display(Name = "Division")]
        public int DivisionId { get; set; }

        [Display(Name = "Division")]
        public string DivisionName { get; set; }

        [Display(Name = "Division")]
        public string DivisionCode { get; set; }

        [Display(Name = "Division")]
        public string DivCodeName
        {
            get
            {
                return "[" + DivisionCode + "] " + DivisionName;
            }
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return FirstName + (string.IsNullOrEmpty(MiddleName)?"": " " + MiddleName) +  (string.IsNullOrEmpty(LastName)? "" : " " + LastName);
            }
        }

        public string Address { get; set; }

        [Display(Name ="Date of Hire"), DisplayFormat(DataFormatString ="{0:dd MMM yyyy}"), Required]
        public DateTime DateOfHire { get; set; }

        [Display(Name = "Date of Resign"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime? DateOfResign { get; set; }

        public string PlaceOfBirth { get; set; }

        [Display(Name = "Date of Birth"), DisplayFormat(DataFormatString = "{0:dd MMM yyyy}"), Required]
        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public bool IsActivated { get; set; }
    }
}
