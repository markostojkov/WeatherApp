import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { ApiService } from 'src/app/shared/services/api/api.service';
import { WeatherRootDto } from '../../models';

@Component({
  selector: 'app-weather-forecast',
  templateUrl: './weather-forecast.component.html',
  styleUrls: ['./weather-forecast.component.css']
})
export class WeatherForecastComponent implements OnInit {

  city = new FormControl('', Validators.required);
  cityData: WeatherRootDto;
  weatherImageSrc: string;

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
  }

  public search(): void {
    this.apiService.getWeatherForCity(this.city.value).subscribe((res: WeatherRootDto) => {
      this.city.reset();
      this.cityData = res;
      this.weatherImageSrc = `http://openweathermap.org/img/w/${res.weather[0].icon}.png`;
    });
  }
}
