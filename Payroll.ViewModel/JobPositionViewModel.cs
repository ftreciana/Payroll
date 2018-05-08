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

        [Display(Name ="Departement")]
        public int DepartementId { get; set; }

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
