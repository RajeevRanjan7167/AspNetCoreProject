import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { AlertifyService } from 'src/app/_Services/alertify.service';
import { AuthService } from '../../_Services/Auth.service';
import { RoleService } from '../../_Services/role.service';
import { Role } from '../../_modeles/role';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.css'],
})
export class RoleComponent implements OnInit {
  public noRowsTemplate;
  public loadingTemplate;
  public rowData: any;
  roles: Role[];
  role: Role;
  roleForm: FormGroup;
  roleId: any;
  btnString: string;
  isDisabled: boolean;
  selectedFlag: any;

  constructor(
    private http: HttpClient,
    private alertify: AlertifyService,
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private roleService: RoleService
  ) {}

  flaglst = [
    {id: 0, name: 'Active'},
    {id: 1, name: 'Inactive'}
  ];

  defaultColDef = [{ sortable: true }, { resizable: true }, { filter: true }];
  columnDefs = [
    { headerName: 'Name', field: 'role_Name', width: 716, sortable: true, filter: true, cellClass: 'editable-grid-cell' },
    { headerName: 'Active', field: 'strContext', sortable: true, filter: true },
    {headerName: '', field: 'icon', width: 50, cellRenderer(params)
    {
        return '<span><i data-action-type ="view" class="fa fa-eye"></i></span>';
    }},
    {headerName: '', field: 'icon', width: 50, cellRenderer(params)
    {
        return '<span><i data-action-type ="edit" class="fa fa-edit"></i></span>';
    }},
    {headerName: '', field: 'icon', width: 50, cellRenderer(params)
    {
        return '<span><i data-action-type ="remove" class="fa fa-trash"></i></span>';
    }}
  ];

  ngOnInit() {
    this.btnString = environment.controlCreate;
    this.roleCreation();
    this.loadRole();
    this.fillDetaultValue();
  }

  roleCRUD() {
      this.role = Object.assign({}, this.roleForm.value);
      if (this.btnString === environment.controlCreate)
      {
        this.createRole();
      }
      else if (this.btnString === environment.controlEdit)
      {
       this.updateRole();
      }
      else if (this.btnString === environment.controlDelete)
      {
       this.deleteRole();
      }
  }

  createRole(){
    this.role = Object.assign({}, this.roleForm.value);
    this.roleService.generateRole(this.role).subscribe(() => {
      this.alertify.success('Role created successfull');
      this.loadRole();
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.roleClear();
    });
  }

  updateRole(){
    this.role = Object.assign({}, this.roleForm.value);
    this.roleService.updateRole(this.roleId , this.role).subscribe(() => {
      this.alertify.success('Role updated successfull');
      this.loadRole();
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.roleClear();
    });
  }

  deleteRole(){
    this.roleService.deleteRole(this.roleId).subscribe(() => {
      this.alertify.success('Role deleted successfull');
      this.loadRole();
    }, error => {
      this.alertify.error(error);
    }, () => {
      this.roleClear();
    });
  }

  roleClear() {
    this.btnString =  environment.controlCreate;
    this.roleForm = this.formBuilder.group({
      role_Name: '',
      is_active: 0
    });
    this.isDisabled = false;
  }

  roleCreation(){
    this.roleForm = this.formBuilder.group({
      role_Name: ['', Validators.required],
      is_active: ['', Validators.required],
    });
  }

  fillDetaultValue() {
    this.roleForm.controls.is_active.setValue(this.flaglst[0], {
      onlySelf: true,
    });
  }

  loadRole() {
    this.roleService.getRoles().subscribe(
      (roleInfor: Role[]) => {
        this.roles = roleInfor;
        this.rowData = this.roles;
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }

  onCellClicked(event: any) {
    if (event.event.target !== undefined) {
      const data = event.data;
      const actionType = event.event.target.getAttribute('data-action-type');
      switch (actionType) {
        case 'view':
          return this.onActionViewClick(data);
        case 'edit':
          return this.onActionEditClick(data);
        case 'remove':
          return this.onActionRemoveClick(data);
      }
    }
  }

  onActionViewClick(data: any) {
    this.roleId = data.id;
    this.btnString = environment.controlView;
    if (this.roleId > 0) {
      this.roleForm = this.formBuilder.group({
        role_Name: data.role_Name,
        is_active: data.is_active
      });
    }
    this.isDisabled = true;
  }

  onActionEditClick(data: any) {
    this.roleId = data.id;
    this.isDisabled = false;
    this.btnString = environment.controlEdit;
    if (this.roleId > 0) {
      this.roleForm = this.formBuilder.group({
        role_Name: data.role_Name,
        is_active: data.is_active
      });
    }
  }

  onActionRemoveClick(data: any) {
    this.roleId = data.id;
    this.isDisabled = false;
    this.btnString = environment.controlDelete;
    if (this.roleId > 0) {
      console.log('Hello Rajeev Remove');
      this.roleForm = this.formBuilder.group({
        role_Name: data.role_Name,
        is_active: data.is_active
      });
    }
  }

  cancel() {
    this.btnString =  environment.controlCreate;
    this.roleForm = this.formBuilder.group({
      role_Name: '',
      is_active: 0
    });
    this.isDisabled = false;
  }
}
