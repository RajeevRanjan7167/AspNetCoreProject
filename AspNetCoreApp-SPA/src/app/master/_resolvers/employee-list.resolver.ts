import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Resources } from '../../_modeles/Resources';
import { ResourcesService } from '../../_Services/resources.service';
import { AlertifyService } from '../../_Services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class EmployeeListResolver implements Resolve<Resources[]> {
  constructor(
    private resourceService: ResourcesService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Resources[]> {
    return this.resourceService.getResources().pipe(
      catchError( error => {
        this.alertify.error('Problem retrieving your data');
        this.router.navigate(['/master']);
        return of(null);
      })
    );
  }
}
