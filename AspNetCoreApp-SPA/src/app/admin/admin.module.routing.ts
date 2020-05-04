import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin.component';
import { GroupComponent } from './group/group.component';
import { ResourceComponent } from './resource/resource.component';
import { RoleComponent } from './role/role.component';
import { ComponentListComponent } from './componentList/componentList.component';

const routes: Routes = [
  {
    path: 'admin', component: AdminComponent,
    children: [
        { path: 'role', component: RoleComponent },
        { path: 'group', component: GroupComponent },
        { path: 'comp', component: ComponentListComponent },
        { path: 'resource', component: ResourceComponent }
      ],
  },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})

export class AdminRoutingModule{}