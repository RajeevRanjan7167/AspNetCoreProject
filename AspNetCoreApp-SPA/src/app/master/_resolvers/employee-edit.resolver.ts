import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Resources } from '../../_modeles/Resources';
import { ResourcesService } from '../../_Services/resources.service';
import { AlertifyService } from '../../_Services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from 'src/app/_Services/Auth.service';

@Injectable()
export class EmployeeEditResolver implements Resolve<Resources> {
  constructor(
    private resourceService: ResourcesService,
    private router: Router,
    private alertify: AlertifyService,
    private authService: AuthService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Resources> {
    return this.resourceService.getResource(this.authService.decodedToken.nameid).pipe(
      catchError( error => {
        this.alertify.error('Problem retrieving your data');
        this.router.navigate(['/emp']);
        return of(null);
      })
    );
  }
}
