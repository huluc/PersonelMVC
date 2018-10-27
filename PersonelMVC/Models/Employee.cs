using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonelMVC.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Display(Name="Ad")]
        [Required(ErrorMessage ="Ad alanı zorunludur.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad alanı zorunludur.")]     
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Married { get; set; }
        [Required(ErrorMessage ="Departman Alanı Zorunludur.")]
        public int DepartmantId { get; set; }

        public Departmant Departmant { get; set; }
    }
}