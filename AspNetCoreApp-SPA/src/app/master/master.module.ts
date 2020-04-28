import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from '../_Services/Auth.service';
import { ResourcesService } from '../_Services/resources.service';
import { ErorrIntercepterProvider } from '../_Services/error.interceptor';
import { MasterComponent } from './master.component';
import { CityComponent } from './city/city.component';
import { CountryComponent } from './country/country.component';
import { FieldComponent } from './field/field.component';
import { MasterRoutingModule } from './master-module.routing';
import { JwtModule } from '@auth0/angular-jwt';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { EmployeeListComponent } from './employees/employee-list/employee-list.component';
import { EmployeeCardComponent } from './employees/employee-card/employee-card.component';
import { EmployeeDetailComponent } from './employees/employee-detail/employee-detail.component';
import { EmployeeEditComponent } from './employees/employee-edit/employee-edit.component';
import { EmployeeDetailResolver } from './_resolvers/employee-details.resolver';
import { EmployeeListResolver } from './_resolvers/employee-list.resolver';
import { EmployeeEditResolver } from './_resolvers/employee-edit.resolver';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { PreventUnsavedChanges } from '../_guards/Prevent-unsaved-changes.guard';
import { AgGridModule } from 'ag-grid-angular';

// import { NgxGalleryModule } from 'ngx-gallery';

export function tokenGetter() {
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    CityComponent,
    CountryComponent,
    FieldComponent,
    EmployeeListComponent,
    EmployeeCardComponent,
    EmployeeDetailComponent,
    EmployeeEditComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MasterRoutingModule,
    TabsModule.forRoot(),
    AgGridModule.withComponents([]),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ['localhost:5000'],
        blacklistedRoutes: ['localhost:5000/api/auth'],
      },
    }),
  ],
  providers: [
    AuthService,
    ResourcesService,
    ErorrIntercepterProvider,
    EmployeeDetailResolver,
    EmployeeListResolver,
    EmployeeEditResolver,
    PreventUnsavedChanges
  ],
  bootstrap: [MasterComponent],
})
export class MasterModule {}
