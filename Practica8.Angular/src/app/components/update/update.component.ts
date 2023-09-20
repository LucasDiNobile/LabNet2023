import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { EmployeeModel } from '../employee/models/employeeModel';
import { ServicesService } from '../services/services.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent {
  formUpdate!: FormGroup

  employee!: EmployeeModel;
  loading: boolean = false;
  verTabla: boolean = false;
  ocultarId: boolean = false;
  public listEmployee: Array<EmployeeModel> = [];

  constructor(private formBuild: FormBuilder, private router: Router, private employeeService: ServicesService){}

  ngOnInit(): void{
    this.initForm();
    this.getEmployee();
  }

  initForm(){
     this.formUpdate = this.formBuild.group({
      id: ['', [Validators.required]],
      nombre: ['', [Validators.required, Validators.maxLength(10)]],
      apellido: ['', [Validators.required, Validators.maxLength(20)]],
    });
  }
  
  cancelarForm(){
    this.formUpdate.reset();
  }

  getEmployee(){
    this.employeeService.getAllEmployees().subscribe(res =>{
      this.listEmployee = res;
    });
  }

  goToEmployee(){
    this.loading = true;
    setTimeout(() => {
      this.router.navigate(['Employee']);
      this.loading = false;
    }, 1500)
  }

  get insertId(): AbstractControl {
    return this.formUpdate.get('id')!;
  }
  get insertNombre(): AbstractControl {
    return this.formUpdate.get('nombre')!;
  } 
  get insertApellido(): AbstractControl {
    return this.formUpdate.get('apellido')!;
  }


  editarEmployee(){
    var Id = this.insertId.value;
    var Nombre = this.insertNombre.value;
    var Apellido = this.insertApellido.value;

    this.employee = { Id: Id, Nombre: Nombre, Apellido: Apellido}

    Swal.fire({
      title: 'Desea guardar los cambios?',
      text: "No podrá recuperarlos",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si, seguro!'
    }).then((result) => {
      if (result.isConfirmed) {
        this.employeeService.updateEmployee(this.employee).subscribe(res =>{
          this.formUpdate.reset(res);
          this.goToEmployee() 
        })
      }
    })

  }
  

  llenarInput(item: EmployeeModel){

    this.formUpdate.patchValue({
      id: item.Id,
      nombre: item.Nombre,
      apellido: item.Apellido
    });
    this.verTabla = true;
  }
}
