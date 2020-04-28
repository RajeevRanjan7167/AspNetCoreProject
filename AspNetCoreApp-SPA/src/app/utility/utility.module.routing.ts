import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UtilityComponent } from './utility.component';
import { FeildCalculationComponent } from './feild-calculation/feild-calculation.component';

const routes: Routes = [
  {
    path: 'utility', component: UtilityComponent,
    children: [
        { path: 'feildcal', component: FeildCalculationComponent }
      ],
  },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})

export class UtilityRoutingModule{}