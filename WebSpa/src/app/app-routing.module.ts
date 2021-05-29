import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthLayoutComponent } from './layout/auth-layout/auth-layout.component';
import { AdminLayoutComponent } from './layout/admin-layout/admin-layout.component';
import { NoAuthGuard } from './core/guard/no-auth.guard';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/auth/login',
    pathMatch: 'full'
  },
  {
    path: '',
    component: AdminLayoutComponent,
    canActivate: [NoAuthGuard],
    children: [{
      path: 'person',
      loadChildren: './modules/person/person.module#PersonModule'
    }]
  },
  {
    path: 'auth',
    component: AuthLayoutComponent,
    children: [{
      path: '',
      loadChildren: './modules/auth/auth.module#AuthModule'
    }]
  },
  { path: '**', redirectTo: '/auth/login', pathMatch: 'full' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      useHash: true,
      relativeLinkResolution: 'legacy'
    })
  ],
  exports: [RouterModule],
  providers: []
})
export class AppRoutingModule {}
