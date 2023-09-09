using Lab.Practica6.Entities;
using Lab.Practica6.Logic;
using Lab.Practica6.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.Practica6.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeLogic employeeLogic = new EmployeeLogic();

        // GET: Employee
        public ActionResult Index()
        { 
            List<Employee> employees = employeeLogic.GetAll();

            List<EmployeeModel> employeesModel = employees.Select(e => new EmployeeModel
            {
                Id = e.EmployeeID,
                Nombre = e.FirstName,
                Apellido = e.LastName
            }).ToList();

            return View(employeesModel);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(EmployeeModel employeeModel)
        {
            try
            {
                Employee employeeEntity = new Employee 
                { 
                    EmployeeID = employeeModel.Id,
                    FirstName = employeeModel.Nombre,
                    LastName= employeeModel.Apellido
                };

                employeeLogic.Insert(employeeEntity);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Employee employeDelete = new Employee
                {
                    EmployeeID = id
                };

                employeeLogic.Delete(employeDelete);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");

            }
        }


        public ActionResult Volver()
        {
            return RedirectToAction("Index", "Employee");
        }


        public ActionResult Edit()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Edit(EmployeeModel employeeModel)
        {
            try
            {               
                Employee employeUpdate = new Employee
                {
                    EmployeeID = employeeModel.Id,
                    FirstName = employeeModel.Nombre,
                    LastName = employeeModel.Apellido
                };
                employeeLogic.Update(employeUpdate);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {             
                return RedirectToAction("Index", "Error");
            }
        }
    }
}