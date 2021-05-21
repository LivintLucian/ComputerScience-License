import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { HeaderComponent } from './header/header.component';
import { RouterModule } from '@angular/router';
import { MentorFilterComponent } from './mentor-filter/mentor-filter.component';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from '../app-routing.module';
import { FilterComponent } from './filter/filter.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { MentorProfileComponent } from './mentor-profile/mentor-profile.component';
import { NewsComponent } from './news/news.component';
import { NewsPublishArticleComponent } from './news-publish-article/news-publish-article.component';
import { NewsReadArticleComponent } from './news-read-article/news-read-article.component';
import { LiveChatComponent } from './live-chat/live-chat.component';
import { LiveStreamingComponent } from './live-streaming/live-streaming.component';
import { LiveStreamingWatchComponent } from './live-streaming-watch/live-streaming-watch.component';

@NgModule({
  declarations: [HeaderComponent, MentorFilterComponent, FilterComponent, MentorProfileComponent, NewsComponent, NewsPublishArticleComponent, NewsReadArticleComponent, LiveChatComponent, LiveStreamingComponent, LiveStreamingWatchComponent],
  imports: [
    RouterModule,
    CommonModule,
    RouterModule,
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MatAutocompleteModule,
    MatSelectModule,
    MatInputModule,
    MatFormFieldModule,
    MatRadioModule,
    AppRoutingModule,
    DashboardRoutingModule,
  ],
  exports: [HeaderComponent, MentorFilterComponent, LiveChatComponent, LiveStreamingComponent],
})
export class DashboardModule {}
