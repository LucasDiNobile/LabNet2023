import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeComponent } from './components/employee/employee.component';

const routes: Routes = [
  {path:'', pathMatch: 'full', redirectTo:'Employees'},
  {path:'Employees', component: EmployeeComponent},
  {
    path:'updateEmployee',
    loadChildren:() => import('./components/dashboard/dashboard.module')
      .then(x=>x.DashboardModule),
  },
  {path:'**', pathMatch: 'full', redirectTo:'Employees'},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
