import { NgModule } from '@angular/core';

import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { SharedModule } from '../shared/shared.module';
import { ROUTES } from './users.routes';


@NgModule({
  declarations: [LoginComponent, RegisterComponent],
  imports: [
    SharedModule,
    ROUTES
  ]
})
export class UsersModule { }
