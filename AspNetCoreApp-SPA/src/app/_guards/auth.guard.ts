import { Injectable } from '@angular/core';
import { CanActivate, Router, Routes } from '@angular/router';
import { AuthService } from '../_Services/Auth.service';
import { AlertifyService } from '../_Services/alertify.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(
    private authServer: AuthService,
    private router: Router,
    private alertify: AlertifyService
  ) {}

  canActivate(): boolean {
    if (this.authServer.loggedIn()) {
      return true;
    }

    this.alertify.error('You shall not pass');
    this.router.navigate(['/home']);
    return false;
  }
}
