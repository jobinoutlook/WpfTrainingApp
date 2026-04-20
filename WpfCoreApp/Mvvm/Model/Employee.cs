using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCoreApp.Mvvm.Model
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity) ]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Department {  get; set; }
        public int? Age {  get; set; }
        public bool? IsActive {  get; set; }
    }
}
