import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Resources } from '../../_modeles/Resources';
import { ResourcesService } from '../../_Services/resources.service';
import { AlertifyService } from '../../_Services/alertify.service';
import { AuthService } from '../../_Services/Auth.service';

@Component({
  selector: 'app-resource',
  templateUrl: './resource.component.html',
  styleUrls: ['./resource.component.css']
})
export class ResourceComponent implements OnInit {
  resources: Resources[];
  resourceForm: FormGroup;
  public data: any[];
  public rowData: any;
  resourceId: number;

  genderlst: any[] = ['Male', 'Female' ];
  flaglst: any[] = [ 'Yes', 'No' ];

  constructor(
    private resourceService: ResourcesService,
    private http: HttpClient,
    private alertity: AlertifyService,
    private formBuilder: FormBuilder,
    private authService: AuthService
  ) {}

  columnDefs = [
    { headerName: 'Login Id', field: 'rm_Login_Id', sortable: true, filter: true},
    { headerName: 'E-mail', field: 'rm_Email', sortable: true, filter: true},
    { headerName: 'First Name', field: 'rm_First_Name', sortable: true, filter: true},
    { headerName: 'Middle Name', field: 'rm_Middle_Name', sortable: true, filter: true},
    { headerName: 'Last Name', field: 'rm_Last_Name', sortable: true, filter: true},
    { headerName: 'Role', field: 'rM_UserRole', sortable: true, filter: true },
    { headerName: 'Gender', field: 'rm_Gender', sortable: true, filter: true},
    { headerName: 'Age', field: 'age', sortable: true, filter: true },
    { headerName: 'Address', field: 'rm_address', sortable: true, filter: true },
    { headerName: 'City', field: 'rm_City', sortable: true, filter: true},
    { headerName: 'Country', field: 'rm_Country', sortable: true, filter: true},
    { headerName: 'Postal Code', field: 'rm_Postalcode', sortable: true, filter: true},
    { headerName: 'Contact No', field: 'rm_Contactno', sortable: true, filter: true},
    { headerName: 'Active', field: 'rm_Active', sortable: true, filter: true}
  ];

  ngOnInit() {
    this.loadResource();
    this.createResourceForm();
    this.fillDetaultValue();
  }

  createResourceForm(){
    this.resourceForm = this.formBuilder.group({
      firstname: ['', Validators.required],
      middlename: ['', Validators.required],
      lastname: ['', Validators.required],
      loginid: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
      roleid: ['', Validators.required],
      gender: ['', Validators.required],
      age: ['', Validators.required],
      address: ['', Validators.required],
      contactno: ['', Validators.required],
      city: ['', Validators.required],
      country: ['', Validators.required],
      flag: ['', Validators.required],
      postalcode: ['', Validators.required]
    });
  }

  loadResource() {
    this.resourceService.getResources().subscribe(
      (resourcesInfor: Resources[]) => {
        this.resources = resourcesInfor;
        this.rowData = this.resources;
      },
      (error) => {
        this.alertity.error(error);
      }
    );
  }

  fillDetaultValue(){
    this.resourceForm.controls['gender'].setValue(this.genderlst[0] , {onlySelf: true});
    this.resourceForm.controls['flag'].setValue(this.flaglst[0] , {onlySelf: true});
  }

  onRowClicked(event: any) {
    console.log('row', event);
    this.resourceId = event.data.id;
    if (this.resourceId > 0 )
    {
      this.resourceForm = this.formBuilder.group({
        firstname: event.data.rm_First_Name,
        middlename: event.data.rm_Middle_Name,
        lastname: event.data.rm_Last_Name,
        loginid: event.data.rm_Login_Id,
        email: event.data.rm_Email,
        password: 'No Password',
        roleid: event.data.rM_UserRole,
        gender: event.data.rm_Gender,
        age: event.data.age,
        address: event.data.rm_address,
        contactno: event.data.rm_Contactno,
        city: event.data.rm_City,
        country: event.data.rm_Country,
        flag: event.data.rm_Active,
        postalcode: event.data.rm_Postalcode
      });
    }
  }

  updateResourceInfo() {
    if (this.resourceForm.valid )
    {
      this.resources = Object.assign({}, this.resourceForm.value);
    }
  }

  onCellClicked(event: any) {
    console.log('cell', event);
  }

  onSelectionChanged(event: any) {
    console.log("selection", event);
  }

  resourceCreation() {}

  cancel() {
  }
  
}
