import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from '../_Services/Auth.service';
import { ErorrIntercepterProvider } from '../_Services/error.interceptor';
import { TfsComponent } from './tfs.component';
import { CheckInMailComponent } from './check-in-mail/check-in-mail.component';
import { TfsRoutingModule } from './tfs.module.routing';
import { DataMinerComponent } from './data-miner/data-miner.component';
import { AgGridModule } from 'ag-grid-angular';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

@NgModule({
  declarations: [CheckInMailComponent, DataMinerComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    TfsRoutingModule,
    BsDatepickerModule.forRoot(),
    AgGridModule.withComponents([]),
  ],
  providers: [AuthService, ErorrIntercepterProvider],
  bootstrap: [TfsComponent],
})
export class TfsModule {}
