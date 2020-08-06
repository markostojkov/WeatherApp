import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

import { LoginUser } from 'src/app/shared/models';
import { AuthService } from 'src/app/shared/services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  username = new FormControl('', Validators.required);
  password = new FormControl('', Validators.required);

  constructor(private formBuilder: FormBuilder, private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({username: this.username, password: this.password});
  }

  public onSubmit(): void {
    const loginForm = new LoginUser(this.loginForm.value.username, this.loginForm.value.password);

    this.authService.loginUser(loginForm)
      .subscribe(
      () => {
        this.loginForm.reset();
        this.router.navigateByUrl('/weather/forecast');
      }
    );
  }
}
