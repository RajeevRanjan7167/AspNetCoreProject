import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NoPageFoundComponent } from './NoPageFound/NoPageFound.component';
import { AuthGuard } from './_guards/auth.guard';
import { MasterComponent } from './master/master.component';

export const appRoutes: Routes = [

  // { path: '', component: HomeComponent },
  // {
  //   path: '',
  //   runGuardsAndResolvers: 'always',
  //   canActivate: [AuthGuard],
  //   children: [
  //     { path: 'members', component: MemberListComponent },
  //     { path: 'resource', component: ResourceComponent },
  //     { path: 'messages', component: MessagesComponent },
  //     { path: 'lists', component: ListsComponent },
  //   ],
  // },
  // { path: '**', redirectTo: '', pathMatch: 'full' },

  // { path: '', component: MasterComponent },
  { path: '', component: HomeComponent },
  { path: '**', component: HomeComponent, pathMatch: 'full'},
];
