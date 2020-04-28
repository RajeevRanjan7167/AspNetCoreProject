import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from '../_Services/Auth.service';
import { ErorrIntercepterProvider } from '../_Services/error.interceptor';
import { ReportsComponent } from './reports.component';
import { ResourcereportComponent } from './resourcereport/resourcereport.component';
import { ReportRoutingModule } from './report.module.routing';

@NgModule({
  declarations: [ResourcereportComponent],
  imports: [CommonModule, ReportRoutingModule],
  providers: [AuthService, ErorrIntercepterProvider],
  bootstrap: [ReportsComponent],
})
export class ReportsModule {}
