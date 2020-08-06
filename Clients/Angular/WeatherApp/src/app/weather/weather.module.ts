import { NgModule } from '@angular/core';
import { WeatherForecastComponent } from './components/weather-forecast/weather-forecast.component';
import { SharedModule } from '../shared/shared.module';
import { ROUTES } from './weather.routes';

@NgModule({
  declarations: [WeatherForecastComponent],
  imports: [
    SharedModule,
    ROUTES
  ]
})
export class WeatherModule { }
