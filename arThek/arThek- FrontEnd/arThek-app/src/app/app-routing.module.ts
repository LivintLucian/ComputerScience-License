import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterJoinAsMentorComponent } from './register/register-join-as-mentor/register-join-as-mentor.component';
import { RegisterJoinAsUserComponent } from './register/register-join-as-user/register-join-as-user.component';
import { RegisterMentorAditionalDataComponent } from './register/register-mentor-aditional-data/register-mentor-aditional-data.component';
import { RegisterMentorVolunteerTypeComponent } from './register/register-mentor-volunteer-type/register-mentor-volunteer-type.component';
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
  {
    path: 'register/mentor/volunteer-type',
    component: RegisterMentorVolunteerTypeComponent,
  },
  {
    path: 'register/mentor/aditional-data',
    component: RegisterMentorAditionalDataComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
