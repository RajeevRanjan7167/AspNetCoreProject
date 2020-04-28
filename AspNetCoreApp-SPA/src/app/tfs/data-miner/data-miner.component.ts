import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { AlertifyService } from '../../_Services/alertify.service';
import { AuthService } from '../../_Services/Auth.service';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker/public_api';


@Component({
  selector: 'app-data-miner',
  templateUrl: './data-miner.component.html',
  styleUrls: ['./data-miner.component.css'],
})
export class DataMinerComponent implements OnInit {
  dataMinerForm: FormGroup;
  public rowData: any;
  public noRowsTemplate;
  public loadingTemplate;
  bsConfig: Partial<BsDatepickerConfig>;

  currentDate = new Date();

  constructor(
    private http: HttpClient,
    private alertity: AlertifyService,
    private formBuilder: FormBuilder,
    private authService: AuthService
  ) {
  }

  genderlst: any[] = ['Male', 'Female'];
  flaglst: any[] = ['Yes', 'No'];

  City: any = ['Florida', 'South Dakota', 'Tennessee', 'Michigan'];

  defaultColDef = [{ sortable: true }, { resizable: true }, { filter: true }];
  columnDefs = [
    { headerName: 'PBI Number', field: 'ID', sortable: true, filter: true },
    { headerName: 'Team', field: 'Team', sortable: true, filter: true},
    { headerName: 'Release', field: 'Target Release', sortable: true, filter: true},
    { headerName: 'Assigned To', field: 'Assigned To', sortable: true, filter: true },
    { headerName: 'Effort', field: 'Effort', sortable: true, filter: true },
    { headerName: 'Completed Work', field: 'Completed Work',  sortable: true, filter: true},
    { headerName: 'Iteration Id', field: 'Iteration Id', sortable: true, filter: true },
    { headerName: 'Iteration Path', field: 'Iteration Path', sortable: true, filter: true },
    { headerName: 'Free Text Flex', field: 'Free Text Flex', sortable: true, filter: true },
    { headerName: 'Blocked', field: 'Blocked', sortable: true, filter: true },
    { headerName: 'Backlog Priority', field: 'Backlog Priority', sortable: true, filter: true },
    { headerName: 'Activity', field: 'Activity', sortable: true, filter: true },
    { headerName: 'Remaining Work', field: 'Remaining Work', sortable: true, filter: true },
    { headerName: 'Closed Date', field: 'Closed Date', sortable: true, filter: true },
    { headerName: 'State Change Date', field: 'State Change Date', sortable: true, filter: true },
    { headerName: 'Tags', field: 'Tags', sortable: true, filter: true },
    { headerName: 'Created By', field: 'Created By', sortable: true, filter: true },
    { headerName: 'Created Date', field: 'Created Date', sortable: true, filter: true },
    { headerName: 'Work Item Type', field: 'Work Item Type', sortable: true, filter: true },
    { headerName: 'Reason', field: 'Reason', sortable: true, filter: true },
    { headerName: 'Changed By', field: 'Changed By', sortable: true, filter: true },
    { headerName: 'State', field: 'State', sortable: true, filter: true },
    { headerName: 'Title', field: 'Title', sortable: true, filter: true },
    { headerName: 'Changed Date', field: 'Changed Date', sortable: true, filter: true },
    { headerName: 'Area Path', field: 'Area Path', sortable: true, filter: true },
    { headerName: 'Team Project', field: 'Team Project', sortable: true, filter: true },
  ];

  ngOnInit() {
    this.bsConfig = { containerClass: 'theme-blue', isAnimated: true,  dateInputFormat: 'DD-MM-YYYY'},
    this.dataMinerCreation();
    this.fillDetaultValue();
  }

  dataMinerCreation(){
    this.dataMinerForm =  this.formBuilder.group({
      project: ['', [Validators.required]],
      team: ['', [Validators.required]],
      member: ['', [Validators.required]],
      release: ['', [Validators.required]],
      worktype: ['' , [Validators.required]],
      state: ['', [Validators.required]],
      datefrom: [new Date(this.currentDate.setDate(this.currentDate.getDate() - 90)), Validators.required],
      dateto: [new Date(), Validators.required],
    });
  }

  fillDetaultValue(){
    this.dataMinerForm.controls['project'].setValue(this.City[0] , {onlySelf: true});
    this.dataMinerForm.controls['team'].setValue(this.flaglst[0] , {onlySelf: true});
    this.dataMinerForm.controls['member'].setValue(this.flaglst[0] , {onlySelf: true});
    this.dataMinerForm.controls['release'].setValue(this.flaglst[0] , {onlySelf: true});
    this.dataMinerForm.controls['worktype'].setValue(this.flaglst[0] , {onlySelf: true});
    this.dataMinerForm.controls['state'].setValue(this.flaglst[0] , {onlySelf: true});
  }

  projectChange(e) {}
  teamChange(e) {}
  menmberChange(e) {}
  releaseChange(e) {}
  stateChange(e){}

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
