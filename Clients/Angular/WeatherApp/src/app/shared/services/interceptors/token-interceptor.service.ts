import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../auth/auth.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ErrorCodeMessage } from '../../errors/error.codes';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(
    private auth: AuthService,
    private router: Router,
    private toastr: ToastrService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    request = request.clone({
      setHeaders: {
        Authorization: `Bearer ${this.auth.getToken()}`
      }
    });

    return next.handle(request).pipe(catchError(err => {
      if (err.status === 401) {
        this.router.navigateByUrl('/users/login');
      }
      if (Array.isArray(err.error)) {
        err.error.forEach(e => this.toastr.error(e.description));
      } else {
        const errorMessage = new ErrorCodeMessage().getErrorMessage(err.error);
        this.toastr.error(errorMessage);
      }
      return throwError(err);
    }));
  }
}
