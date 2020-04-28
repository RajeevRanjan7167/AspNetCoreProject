import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MasterComponent } from './master.component';
import { CityComponent } from './city/city.component';
import { CountryComponent } from './country/country.component';
import { FieldComponent } from './field/field.component';
import { EmployeeListComponent } from './employees/employee-list/employee-list.component';
import { EmployeeDetailComponent } from './employees/employee-detail/employee-detail.component';
import { AuthGuard } from '../_guards/auth.guard';
import { EmployeeEditComponent } from './employees/employee-edit/employee-edit.component';
import { EmployeeDetailResolver } from './_resolvers/employee-details.resolver';
import { EmployeeListResolver } from './_resolvers/employee-list.resolver';
import { EmployeeEditResolver } from './_resolvers/employee-edit.resolver';
//import { PreventUnsavedChanges } from '../_guards/Prevent-unsaved-changes.guard';

const routes: Routes = [
  {
    path: 'master', component: MasterComponent,
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
        { path: 'city', component: CityComponent },
        { path: 'country', component: CountryComponent },
        { path: 'emp', component: EmployeeListComponent, resolve: {resources: EmployeeListResolver}  },
        { path: 'emp/:id', component: EmployeeDetailComponent, resolve: {resource: EmployeeDetailResolver} },
        { path: 'employees/edit', component: EmployeeEditComponent,
                                resolve: {resource: EmployeeEditResolver}},
        { path: 'filed', component: FieldComponent }
      ],
  },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})

export class MasterRoutingModule{}


// { path: 'employees/edit', component: EmployeeEditComponent,
// resolve: {resource: EmployeeEditResolver},
// canDeactivate: [PreventUnsavedChanges]},