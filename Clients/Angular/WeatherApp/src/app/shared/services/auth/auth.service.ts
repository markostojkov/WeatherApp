import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import * as jwt_decode from 'jwt-decode';

import { RegisterUser, LoginUser, UserToken } from '../../models';
import { BaseApiService } from '../base-api/base-api.service';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseApiService {

  constructor(
    httpClient: HttpClient,
    private toastr: ToastrService
  ) {
    super(httpClient);
  }

  public registerUser(request: RegisterUser): Observable<void> {
    return new Observable(observer => {
      this.httpClient.post<void>(this.getApiRoute(`authenticate/register`), request).subscribe(
        () => {
          this.toastr.success('Successfully registered user!');
          observer.next();
          observer.complete();
        },
        error => {
          observer.error(error);
        }
      );
    });
  }

  public loginUser(request: LoginUser): Observable<UserToken> {
    return new Observable(observer => {
      this.httpClient.post<UserToken>(this.getApiRoute(`authenticate/login`), request).subscribe(
        response => {
          this.setAuthCredentials(response);
          observer.next(response);
        },
        error => {
          observer.error(error);
        }
      );
    });
  }

  public getToken(): string {
    return localStorage.getItem('token');
  }

  public isAuthenticated(): boolean {
    if (!this.getToken()) {
      return false;
    }

    const expirationDate = new Date(jwt_decode(this.getToken()).exp).getUTCDate();
    return this.getToken() && expirationDate && expirationDate > new Date().getUTCDate();
  }

  public getUsername(): string {
    if (!this.getToken()) {
      return '';
    }
    return jwt_decode(this.getToken()).unique_name ?? 'Guest';
  }

  private setAuthCredentials(credentials: UserToken): void {
    localStorage.setItem('token', credentials.token);
  }
}
