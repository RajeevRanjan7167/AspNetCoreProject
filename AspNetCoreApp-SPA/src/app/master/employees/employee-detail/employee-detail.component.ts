import { Component, OnInit } from '@angular/core';
import { Resources } from 'src/app/_modeles/Resources';
import { AlertifyService } from 'src/app/_Services/alertify.service';
import { ResourcesService } from '../../../_Services/resources.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css'],
})
export class EmployeeDetailComponent implements OnInit {
  resource: Resources;

  constructor(
    private resourceService: ResourcesService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {

    this.route.data.subscribe( data => {
      this.resource = data['resource'];
    });

    // this.loadResource();
    
  }

  // loadResource()
  // {
  //   this.resourceService.getResource(+this.route.snapshot.params['id']).subscribe((resource: Resources) => {
  //     console.log(resource);
  //     this.resource = resource;
  //   }, error => {
  //     this.alertify.error(error);
  //   });
  // }
}
