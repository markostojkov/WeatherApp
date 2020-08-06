import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

import { MustMatch } from 'src/app/shared/validators/form-validators';
import { AuthService } from 'src/app/shared/services/auth/auth.service';
import { RegisterUser } from 'src/app/shared/models';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;

  username = new FormControl('', Validators.required);
  email = new FormControl('', [Validators.required, Validators.email]);
  password = new FormControl('', [Validators.required, Validators.minLength(8)]);
  confirmPassword = new FormControl('', Validators.required);

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      username: this.username,
      email: this.email,
      password: this.password,
      confirmPassword: this.confirmPassword
    }, {validator: MustMatch('password', 'confirmPassword')});
  }

  public onSubmit(): void {
    const registerForm = new RegisterUser(
      this.registerForm.value.username,
      this.registerForm.value.email,
      this.registerForm.value.password);

    this.authService.registerUser(registerForm)
      .subscribe(
      () => {
        this.registerForm.reset();
        this.router.navigateByUrl('/users/login');
      }
    );
  }
}
