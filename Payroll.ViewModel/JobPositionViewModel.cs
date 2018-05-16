using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class JobPositionViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }

        [Display(Name = "Division")]
        public int DivisionId { get; set; }

        public string DivisionCode { get; set; }
        
        [Display(Name = "Division")]
        public string DivisionName { get; set; }

        [Display(Name = "Division")]
        public string DivisionCodeName
        {
            get
            {
                return "[" + DivisionCode + "] " + DivisionName;
            }
        }

        [Display(Name ="Departement")]
        public int DepartementId { get; set; }

        public string DepartementCode { get; set; }

        [Display(Name = "Departement")]
        public string DepartementName { get; set; }

        public string Description { get; set; }

        [Display(Name ="Description")]
        public string Deskripsi
        {
            get
            {
                return "[" + Code + "] " + Description;
            }
        }

        public bool IsActivated { get; set; }
    }
}
