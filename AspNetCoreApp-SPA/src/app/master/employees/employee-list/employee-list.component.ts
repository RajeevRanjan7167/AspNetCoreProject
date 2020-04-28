import { Component, OnInit } from '@angular/core';
import { ResourcesService } from '../../../_Services/resources.service';
import { AlertifyService } from '../../../_Services/alertify.service';
import { Resources } from '../../../_modeles/Resources';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css'],
})
export class EmployeeListComponent implements OnInit {
  resources: Resources[];
  constructor(
    private resourceService: ResourcesService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe( data => {
      this.resources = data['resources'];
    });

    // this.loadResource();
  }

  // loadResource() {
  //   this.resourceService.getResources().subscribe(
  //     (resources: Resources[]) => {
  //       this.resources = resources;
  //     },
  //     (error) => {
  //       this.alertify.error(error);
  //     }
  //   );
  // }
  
}
