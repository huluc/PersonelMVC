using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonelMVC.Models
{
    public class Departmant
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ad alanı zorunludur.")]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}