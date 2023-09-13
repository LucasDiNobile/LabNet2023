using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Lab.Practica6.Logic;
using System.Data.Entity;
using Lab.Practica6.Entities;
using Lab.net.Practica7.WebApi.Models;
using System.Net;

namespace Lab.net.Practica7.WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeLogic empLogic = new EmployeeLogic();

        // GET: Employee
        public IHttpActionResult GetEmployee()
        {
            try
            {
                List<Employee> employees = empLogic.GetAll();
                List<EmployeeDto> employeesModel = employees.Select(e => new EmployeeDto
                {
                    Id = e.EmployeeID,
                    Nombre = e.FirstName,
                    Apellido = e.LastName
                }).ToList();

                return Ok(employeesModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        public IHttpActionResult AddEmployee([FromBody] EmployeeModel request) 
        {
            try
            {
                Employee employee = new Employee()
                {
                    FirstName = request.Nombre,
                    LastName = request.Apellido
                };

                this.empLogic.Insert(employee);
                return Content(HttpStatusCode.Created, employee);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult DeleteEmployee([FromBody] EmployeeModel request)
        {
            try
            {
                Employee employeeDelete = new Employee()
                {
                    EmployeeID = request.Id
                };

                this.empLogic.Delete(employeeDelete);
                return Ok(employeeDelete);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateEmployee([FromBody] EmployeeModel request)
        {
            try
            {
                Employee employeeDelete = new Employee()
                {
                    EmployeeID = request.Id,
                    FirstName = request.Nombre,
                    LastName = request.Apellido
                };
                this.empLogic.Update(employeeDelete);
                return Ok(employeeDelete);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}