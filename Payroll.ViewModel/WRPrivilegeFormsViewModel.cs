﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.ViewModel
{
    class WRPrivilegeFormsViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ACId { get; set; }
        public string[] Right { get; set; }
    }
}
