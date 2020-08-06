import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
      path: 'users',
      children: [
        {
          path: '',
          loadChildren:
            './users/users.module#UsersModule'
        }
      ]
  },
  {
    path: 'weather',
    children: [
      {
        path: '',
        loadChildren:
          './weather/weather.module#WeatherModule'
      }
    ]
  },
  {
    path: '**',
    redirectTo: '/weather/forecast',
    pathMatch: 'full'
  },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule {}
