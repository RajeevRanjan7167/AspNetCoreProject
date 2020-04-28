import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ReportsComponent } from './reports.component';
import { ResourcereportComponent } from './resourcereport/resourcereport.component';

const routes: Routes = [
  {
    path: 'report', component: ReportsComponent,
    children: [
        { path: 'resourcelist', component: ResourcereportComponent }
      ],
  },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})

export class ReportRoutingModule{}