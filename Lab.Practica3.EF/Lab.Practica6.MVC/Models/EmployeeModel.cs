using System.ComponentModel.DataAnnotations;

namespace Lab.Practica6.MVC.Models
{
    public class EmployeeModel
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "El Nombre de usuario puede contener maximo 10 caracteres")]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "El Apellido puede contener maximo 20 caracteres")]
        public string Apellido { get; set; }
    }
}