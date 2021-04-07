import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterJoinAsMentorComponent } from './register/register-join-as-mentor/register-join-as-mentor.component';
import { RegisterJoinAsUserComponent } from './register/register-join-as-user/register-join-as-user.component';
import { RegisterUserTypeComponent } from './register/register-user-type/register-user-type.component';

const routes: Routes = [
  {
    path: 'home',
    loadChildren: () => import('./home/home.module').then((m) => m.HomeModule),
  },
  {
    path: 'register/user-type',
    component: RegisterUserTypeComponent,
  },
  {
    path: 'register/join-as-user',
    component: RegisterJoinAsUserComponent,
  },
  {
    path: 'register/join-as-mentor',
    component: RegisterJoinAsMentorComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
