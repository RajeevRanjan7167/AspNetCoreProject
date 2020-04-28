import { Component, OnInit } from '@angular/core';
import { AuthService } from './_Services/Auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Resources } from './_modeles/Resources';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'App-SPA';
  jwtHelper = new JwtHelperService();

  constructor(private authService: AuthService) {}

  ngOnInit() {
    const token = localStorage.getItem('token');
    const resource: Resources[] = JSON.parse(localStorage.getItem('resource'));
    if (token) {
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
    }
    if (resource){
      this.authService.currentResource = resource ;
      //this.authService.changeResourcePhoto(resource.photoUrl)
    }
  }
}
