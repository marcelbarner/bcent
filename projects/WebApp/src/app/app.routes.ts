import {Routes} from '@angular/router';
import {authGuard} from '@core';
import {AdminLayoutComponent} from '@theme/admin-layout/admin-layout.component';
import {AuthLayoutComponent} from '@theme/auth-layout/auth-layout.component';

export const routes: Routes = [
  {
    path: '',
    component: AdminLayoutComponent,
    canActivate: [authGuard],
    canActivateChild: [authGuard],
    children: [
      {path: '', redirectTo: 'dashboard', pathMatch: 'full'},
      {
        path: 'dashboard',
        loadComponent: () => import('./routes/dashboard/dashboard.component').then(c => c.DashboardComponent)
      },
      {
        path: 'settings',
        loadComponent: () => import('./routes/settings/settings.component').then(c => c.SettingsComponent)
      },
      {
        path: 'transactions',
        loadComponent: () => import('./routes/transactions-overview/transactions-overview.component').then(c => c.TransactionsOverviewComponent)
      },
      {path: '403', loadComponent: () => import('./routes/sessions/403.component').then(c => c.Error403Component)},
      {path: '404', loadComponent: () => import('./routes/sessions/404.component').then(c => c.Error404Component)},
      {path: '500', loadComponent: () => import('./routes/sessions/500.component').then(c => c.Error500Component)},
    ],
  },
  {
    path: 'auth',
    component: AuthLayoutComponent,
    children: [
      {
        path: 'login',
        loadComponent: () => import('./routes/sessions/login/login.component').then(c => c.LoginComponent)
      },
      {
        path: 'register',
        loadComponent: () => import('./routes/sessions/register/register.component').then(c => c.RegisterComponent)
      },
    ],
  },
  {path: '**', redirectTo: 'dashboard'},
];
