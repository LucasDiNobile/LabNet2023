using System.ComponentModel.DataAnnotations;

namespace Lab.net.Practica7.WebApi.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
      
        public string Nombre { get; set; }
      
        public string Apellido { get; set; }
    }
}