import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BaseApiService {

  apiRoute = `http://localhost:57700/api/`;

  constructor(
    protected httpClient: HttpClient
  ) { }

  protected getApiRoute(route: string): string {
    return `${this.apiRoute}${route}`;
  }
}
