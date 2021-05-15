import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HeaderComponent } from './dashboard/header/header.component';
import { LiveChatComponent } from './dashboard/live-chat/live-chat.component';
import { MentorFilterComponent } from './dashboard/mentor-filter/mentor-filter.component';
import { MentorProfileComponent } from './dashboard/mentor-profile/mentor-profile.component';
import { NewsReadArticleComponent } from './dashboard/news-read-article/news-read-article.component';
import { NewsComponent } from './dashboard/news/news.component';
import { RegisterJoinAsMentorComponent } from './register/register-join-as-mentor/register-join-as-mentor.component';
import { RegisterJoinAsUserComponent } from './register/register-join-as-user/register-join-as-user.component';
import { RegisterMentorAditionalDataComponent } from './register/register-mentor-aditional-data/register-mentor-aditional-data.component';
import { RegisterMentorProfileComponent } from './register/register-mentor-profile/register-mentor-profile.component';
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
  {
    path: 'register/mentor/profile-preview',
    component: RegisterMentorProfileComponent,
  },
  {
    path: 'dashboard',
    component: NewsComponent,
  },
  {
    path: 'dashboard/read-article/:id',
    component: NewsReadArticleComponent
  },
  {
    path: 'dashboard/mentors',
    component: MentorFilterComponent
  },
  {
    path: 'dashboard/mentors/mentor-profile/:id',
    component: MentorProfileComponent
  },
  {
    path: '',
    component: LiveChatComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
