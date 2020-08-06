import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { WeatherForecastComponent } from './components/weather-forecast/weather-forecast.component';
import { AuthenticatedUserGuard } from '../shared/guards/authenticated-user.guard';

export const routes: Routes = [
    {
        path: 'forecast',
        component: WeatherForecastComponent,
        canActivate: [AuthenticatedUserGuard]
    }
];

export const ROUTES: ModuleWithProviders = RouterModule.forChild(routes);
