using PersonelMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelMVC.ViewModels
{
    public class EmployeeFormViewModel
    {
        public IEnumerable<Departmant> Departmants { get; set; }
        public Employee Employee { get; set; }
    }
}