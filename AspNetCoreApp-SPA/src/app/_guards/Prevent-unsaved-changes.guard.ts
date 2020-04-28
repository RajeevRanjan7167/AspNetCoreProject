import { Injectable } from "@angular/core";
import { CanDeactivate } from '@angular/router';
import { EmployeeEditComponent } from '../master/employees/employee-edit/employee-edit.component';

@Injectable()
export class PreventUnsavedChanges implements CanDeactivate<EmployeeEditComponent>{

 canDeactivate(component: EmployeeEditComponent){
     if (component.edidForm.dirty)
     {
        return confirm('Are you sure you want to continue? Any unsaved changes will be lost ');
     }
     return true;
     }
}