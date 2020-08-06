import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseApiService } from '../base-api/base-api.service';
import { Observable } from 'rxjs';
import { WeatherRootDto } from 'src/app/weather/models';

@Injectable({
  providedIn: 'root'
})
export class ApiService extends BaseApiService {

  constructor(protected httpClient: HttpClient) {
    super(httpClient);
  }

  public getWeatherForCity(city: string): Observable<WeatherRootDto> {
    return new Observable(observer => {
      this.httpClient.get<WeatherRootDto>(this.getApiRoute(`weather/${city}`)).subscribe(
        (res: WeatherRootDto) => {
          observer.next(res);
          observer.complete();
        },
        error => {
          observer.error(error);
        }
      );
    });
  }
}
