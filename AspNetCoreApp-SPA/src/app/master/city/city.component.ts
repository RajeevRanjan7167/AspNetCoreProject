import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { AlertifyService } from '../../_Services/alertify.service';
import { AuthService } from '../../_Services/Auth.service';

@Component({
  selector: 'app-city',
  templateUrl: './city.component.html',
  styleUrls: ['./city.component.css'],
})
export class CityComponent implements OnInit {
  //city: City[];
  cityForm: FormGroup;
  public rowData: any;
  public noRowsTemplate;
  public loadingTemplate;

  constructor(
    private http: HttpClient,
    private alertity: AlertifyService,
    private formBuilder: FormBuilder,
    private authService: AuthService
  ) {}

  defaultColDef = [{ sortable: true }, { resizable: true }, { filter: true }];
  columnDefs = [
    { headerName: 'Name', field: 'rm_Login_Id', sortable: true, filter: true },
    { headerName: 'District Name', field: 'rm_Email', sortable: true, filter: true},
    { headerName: 'Head quarters', field: 'rm_First_Name', sortable: true, filter: true},
    { headerName: 'State Name', field: 'rm_Middle_Name', sortable: true, filter: true },
    { headerName: 'Country Name', field: 'rM_UserRole', sortable: true, filter: true },
    { headerName: 'Postal Code', field: 'rm_Postalcode',  sortable: true, filter: true},
    { headerName: 'Active', field: 'rm_Active', sortable: true, filter: true },
  ];

  ngOnInit() {
    this.cityCreation();
  }

  cityCreation() {
    this.cityForm = this.formBuilder.group({
      cityname: ['', Validators.required],
      districtname: ['', Validators.required],
      DistrictHeadQuarters: ['', Validators.required],
      statename: ['', Validators.required],
      countryname: ['', Validators.required],
      postalcode: ['', Validators.required],
      flag: ['', Validators.required]
    });
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
}
