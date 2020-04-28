import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TransactionComponent } from './transaction.component';
import { ProcessComponent } from './process/process.component';

const routes: Routes = [
  {
    path: 'trans', component: TransactionComponent,
    children: [
        { path: 'process', component: ProcessComponent }
      ],
  },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})

export class TransactionRoutingModule{}