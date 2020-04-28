import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TfsComponent } from './tfs.component';
import { CheckInMailComponent } from './check-in-mail/check-in-mail.component';
import { DataMinerComponent } from './data-miner/data-miner.component';

const routes: Routes = [
  {
    path: 'tfs', component: TfsComponent,
    children: [
        { path: 'chkemail', component: CheckInMailComponent },
        { path: 'dataminer', component: DataMinerComponent}
      ],
  },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})

export class TfsRoutingModule{}