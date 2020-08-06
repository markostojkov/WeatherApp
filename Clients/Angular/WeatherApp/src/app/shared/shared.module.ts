import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { ApiService } from './services/api/api.service';
import { AuthService } from './services/auth/auth.service';
import { BaseApiService } from './services/base-api/base-api.service';
import { AuthenticatedUserGuard } from './guards/authenticated-user-guard/authenticated-user.guard';
import { TokenInterceptor } from './interceptors/token-interceptor/token-interceptor.service';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [
    BaseApiService,
    ApiService,
    AuthService,
    AuthenticatedUserGuard,
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true }
  ],
  exports: [
    CommonModule,
    RouterModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
  ]
})
export class SharedModule { }
