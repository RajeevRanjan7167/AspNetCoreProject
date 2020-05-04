import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { AlertifyService } from 'src/app/_Services/alertify.service';
import { AuthService } from 'src/app/_Services/Auth.service';

@Component({
  selector: 'app-componentList',
  templateUrl: './componentList.component.html',
  styleUrls: ['./componentList.component.css'],
})
export class ComponentListComponent implements OnInit {
  compontentForm: FormGroup;
  public rowData: any;
  public noRowsTemplate;
  public loadingTemplate;
  keyword = 'name';

  constructor(
    private http: HttpClient,
    private alertity: AlertifyService,
    private formBuilder: FormBuilder,
    private authService: AuthService
  ) {}

  flaglst: any[] = ['Yes', 'No'];
  defaultColDef = [{ sortable: true }, { resizable: true }, { filter: true }];
  columnDefs = [
    { headerName: 'Name', field: 'rm_Login_Id', width: 350, sortable: true, filter: true },
    { headerName: 'Compontent Name', field: 'rm_Login_Id', width: 400, sortable: true, filter: true },
    { headerName: 'Group', field: 'rm_Login_Id', width: 400, sortable: true, filter: true },
    { headerName: 'Role', field: 'rm_Login_Id', width: 350, sortable: true, filter: true },
    { headerName: 'Active', field: 'rm_Active', sortable: true, filter: true }
  ];

  ngOnInit() {
    this.compontentCreation();
    this.fillDetaultValue();
  }

  compontentCreation() {
    this.compontentForm = this.formBuilder.group({
      compName: ['', Validators.required],
      componentName: ['', Validators.required],
      groupName: ['', Validators.required],
      roleName: ['', Validators.required],
      flag: ['', Validators.required],
    });
  }

  fillDetaultValue() {
    this.compontentForm.controls['flag'].setValue(this.flaglst[0], {onlySelf: true});
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

  cancel() {}

  data = [
    { id: 1, name: 'Usa' },
    { id: 2, name: 'England' },
    { id: 3, name: 'Rajeev' },
    { id: 4, name: 'Sonu' },
    { id: 5, name: 'Rana' },
    { id: 6, name: 'Rohit' },
    { id: 6, name: '12345' },
    { id: 6, name: '56789' },
    { id: 6, name: '436' },
  ];

  selectEvent(item) {
    // do something with selected item
  }

  onChangeSearch(val: string) {
    // fetch remote data from here
    // And reassign the 'data' which is binded to 'data' property.
  }

  onFocused(e) {
    // do something when input is focused
  }
}
