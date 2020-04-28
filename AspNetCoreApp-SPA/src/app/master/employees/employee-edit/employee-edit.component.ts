import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { Resources } from 'src/app/_modeles/Resources';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/_Services/alertify.service';
import { NgForm } from '@angular/forms';
import { AuthService } from '../../../_Services/Auth.service';
import { ResourcesService } from '../../../_Services/resources.service';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.css'],
})
export class EmployeeEditComponent implements OnInit {
  @ViewChild('edidForm') edidForm: NgForm;
  resource: Resources;

  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.edidForm.dirty) {
      $event.returnValue = true;
    }
  }

  constructor(
    private route: ActivatedRoute,
    private alertify: AlertifyService,
    private authService: AuthService,
    private resourceService: ResourcesService
  ) {}

  ngOnInit() {
    this.route.data.subscribe((data) => {
      this.resource = data['resource'];
    });
  }

  updateResource() {
    this.resourceService.updateResource(this.authService.decodedToken.nameid, this.resource).subscribe( next => {
      this.alertify.success('Profile update successfully');
      this.edidForm.reset(this.resource);
    }, error => {
      this.alertify.error(error);
    });
  }
}
