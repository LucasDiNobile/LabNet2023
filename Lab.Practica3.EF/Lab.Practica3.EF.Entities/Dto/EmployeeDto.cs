using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Practica6.Entities
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(20)]
        public string Apellido { get; set; }
    }
}
