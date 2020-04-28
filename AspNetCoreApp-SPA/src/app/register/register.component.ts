import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_Services/Auth.service';
import { AlertifyService } from '../_Services/alertify.service';
import {
  FormGroup,
  Validators,
  FormBuilder,
  FormControl,
} from '@angular/forms';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker/public_api';
import { Router } from '@angular/router';
import { Resources } from '../_modeles/Resources';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  @Input() valuesFormHome: any;
  @Output() cancelRegister = new EventEmitter();
  resource: Resources;
  registerForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(
    private authService: AuthService,
    private alertify: AlertifyService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {}

  ngOnInit() {
    this.bsConfig = { containerClass: 'theme-blue', isAnimated: true,  dateInputFormat: 'DD-MM-YYYY'},
    this.createRegisterForm();
  }

  passwordMatchValidator(passMatch: FormGroup)
  {
    return passMatch.get('password').value === passMatch.get('confirmPassword').value ? null : {'mismatch': true};
  }

  createRegisterForm(){
    this.registerForm =  this.formBuilder.group({
      rm_Gender: ['male'],
      rm_Login_Id: ['', Validators.required],
      rm_Email: ['', Validators.required],
      rm_DateOfBirth: [null, Validators.required],
      password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(20)]],
      confirmPassword: ['', Validators.required]
    }, {validators: this.passwordMatchValidator});
  }

  register() {
    if (this.registerForm.valid )
    {
      this.resource = Object.assign({}, this.registerForm.value);
      this.authService.register(this.resource).subscribe(() => {
        this.alertify.success('registration successfull');
      }, error => {
        this.alertify.error(error);
      }, () => {
        this.authService.login(this.resource).subscribe(() => {
          this.router.navigate(['/master']);
        });
      });
    }
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
