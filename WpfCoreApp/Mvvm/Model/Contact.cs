using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCoreApp.Mvvm.Model
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [StringLength(50)]
        public string? Email { get; set; }
        
        [StringLength(50)]
        public string? PhoneNumber { get; set; } = string.Empty;
    }
}
