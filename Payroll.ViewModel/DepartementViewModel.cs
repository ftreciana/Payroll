using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    public class DepartementViewModel
    {
        public int Id { get; set; }

        [MaxLength(10), Required]
        public string Code { get; set; }

        //Tampilan di modal form Create & Edit
        [Display(Name ="Division")]
        public int DivisionId { get; set; }

        public string DivisionCode { get; set; }

        //Tampilan di list
        [Display(Name = "Division")]
        public string DivisionName { get; set; }

        [Display(Name ="Division")]
        public string DivisionCodeName
        {
            get
            {
                return "[" + DivisionCode + "] " + DivisionName;
            }
        }
        public string DepartementCode { get; set; }
        
        [Display(Name = "Departement")]
        public string DepartementName { get; set; }

        [MaxLength(50), Required]
        public string Description { get; set; }

        public bool IsActivated { get; set; }
    }
}
