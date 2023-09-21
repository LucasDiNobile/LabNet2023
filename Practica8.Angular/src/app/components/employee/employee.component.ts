import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { EmployeeModel } from './models/employeeModel';
import { ServicesService } from '../services/services.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent{
  formEmployees!: FormGroup
  employee!: EmployeeModel;
  loading: boolean = false;
  
  public listEmployee: Array<EmployeeModel> = [];

  constructor(private formBuild: FormBuilder, private employeeService: ServicesService, private router: Router) { }

  ngOnInit(): void{
    this.initForm();
    this.getEmployee();
  }

  initForm(){
     this.formEmployees = this.formBuild.group({
      nombre: ['', [Validators.required, Validators.maxLength(10)]],
      apellido: ['', [Validators.required, Validators.maxLength(20)]],
    });
  }

  getEmployee(){
    this.employeeService.getAllEmployees().subscribe(res =>{
      this.listEmployee = res;
    });
  }

  get insertNombre(): AbstractControl {
    return this.formEmployees.get('nombre')!;
  } 
  get insertApellido(): AbstractControl {
    return this.formEmployees.get('apellido')!;
  }

  guardarEmployee(){
    

    Swal.fire({
      title: 'Estas seguro?',
      text: "El empleado se agregara a la tabla",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si, agregar!'
    }).then((result) => {
      if (result.isConfirmed) {
        var Nombre = this.insertNombre.value;
        var Apellido = this.insertApellido.value;
        
        this.employee = {Nombre, Apellido}
        this.employeeService.crearEmployee(this.employee).subscribe(res =>{
          this.formEmployees.reset(res);
        })
        this.refresh();
      }
    })
  } 
  
  cancelarForm(){
    this.formEmployees.reset();
  }

  goToUpdate(){
    this.loading = true;
    setTimeout(() => {
      this.router.navigate(['updateEmployee']);
      this.loading = false;
    }, 1500)
  }

   eliminarEmployee(employee: EmployeeModel){
    Swal.fire({
      title: 'Seguro desea eliminar este empleado?',
      text: "No podrá revertir esta operación",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si, eliminar!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.employeeService.borrarEmployee(employee).subscribe({
          next:(employee) =>{
            this.refresh();
          },
          error:(error) =>{
            Swal.fire({
              icon: 'error',
              title: 'Oops...',
              text: 'El empleado que intento eliminar posee referencias con otras tablas.',
            })
          }
        })
      }
    })
  }

  

  refresh(){
    this.loading = true;
    setTimeout(() => {
      window.location.reload();
      this.loading = false;
    }, 1500)
  }
}