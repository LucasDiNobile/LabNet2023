import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { EmployeeModel } from '../employee/models/employeeModel';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {
  
  endpoint: string = 'Employee';
  constructor(private http: HttpClient ) { }

  public getAllEmployees(): Observable<Array<EmployeeModel>> {
    let url = environment.apiEmployee + this.endpoint;
    return this.http.get<Array<EmployeeModel>>(url);
  }

  public crearEmployee(employeeRequest: EmployeeModel): Observable<any> {
    let url = environment.apiEmployee + this.endpoint;
    return this.http.post(url, employeeRequest);
  }

  public updateEmployee(employeeRequest: EmployeeModel): Observable<any> {
    let url = environment.apiEmployee + this.endpoint;
    return this.http.put(url, employeeRequest);
  }

  public borrarEmployee(employeeRequest: EmployeeModel): Observable<any> {
    let url = environment.apiEmployee + this.endpoint;
    const options = {
      headers: { 'Content-Type': 'application/json' },
      body: employeeRequest 
    };
    
    return this.http.delete(url, options);
  }
}
