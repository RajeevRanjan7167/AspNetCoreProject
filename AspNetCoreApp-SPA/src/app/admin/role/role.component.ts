import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { AlertifyService } from 'src/app/_Services/alertify.service';
import { AuthService } from 'src/app/_Services/Auth.service';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.css']
})
export class RoleComponent implements OnInit {
  roleForm: FormGroup;
  public rowData: any;
  public noRowsTemplate;
  public loadingTemplate;

  constructor(
    private http: HttpClient,
    private alertity: AlertifyService,
    private formBuilder: FormBuilder,
    private authService: AuthService
  ) { }

  flaglst: any[] = [ 'Yes', 'No' ];

  defaultColDef = [{ sortable: true }, { resizable: true }, { filter: true }];
  columnDefs = [
    { headerName: 'Name', field: 'rm_Login_Id', width: 800, sortable: true, filter: true },
    { headerName: 'Active', field: 'rm_Active', sortable: true, filter: true }
  ];

  ngOnInit() {
    this.roleCreation();
    this.fillDetaultValue();
  }

  roleCreation(){
    this.roleForm = this.formBuilder.group({
      role_Name: ['', Validators.required],
      flag: ['', Validators.required],
    });
  }

  fillDetaultValue(){
    this.roleForm.controls['flag'].setValue(this.flaglst[0] , {onlySelf: true});
  }

  onRowClicked(event: any) {
    console.log('row', event);
  }

  onCellClicked(event: any) {
    console.log('cell', event);
  }

  onSelectionChanged(event: any) {
    console.log('selection', event);
  }

  cancel(){}
}
