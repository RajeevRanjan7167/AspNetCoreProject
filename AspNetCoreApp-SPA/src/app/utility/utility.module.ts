import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthService } from '../_Services/Auth.service';
import { ErorrIntercepterProvider } from '../_Services/error.interceptor';
import { UtilityComponent } from './utility.component';
import { FeildCalculationComponent } from './feild-calculation/feild-calculation.component';
import { UtilityRoutingModule } from './utility.module.routing';

@NgModule({
  declarations: [
    FeildCalculationComponent
  ],
  imports: [CommonModule, UtilityRoutingModule],
  providers: [AuthService, ErorrIntercepterProvider],
  bootstrap: [UtilityComponent],
})

export class UtilityModule {}
