import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from '../_Services/Auth.service';
import { ErorrIntercepterProvider } from '../_Services/error.interceptor';
import { TransactionComponent } from './transaction.component';
import { TransactionRoutingModule } from './transaction.module.routing';
import { ProcessComponent } from './process/process.component';

@NgModule({
  declarations: [ProcessComponent],
  imports: [CommonModule, TransactionRoutingModule],
  providers: [AuthService, ErorrIntercepterProvider],
  bootstrap: [TransactionComponent],
})

export class TransactionModule {}
