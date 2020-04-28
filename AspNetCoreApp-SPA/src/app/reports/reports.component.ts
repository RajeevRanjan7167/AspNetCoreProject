import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_Services/Auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.css']
})
export class ReportsComponent implements OnInit {
  jwtHelper = new JwtHelperService();
  
  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

}
