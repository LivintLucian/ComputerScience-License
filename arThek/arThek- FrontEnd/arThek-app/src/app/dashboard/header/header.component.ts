import {
  Component,
  ElementRef,
  OnInit,
  ViewChild,
  ViewEncapsulation,
} from '@angular/core';
import { Router } from '@angular/router';
import * as signalR from '@microsoft/signalr';
import { User } from 'src/app/core/models/User';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { PushNotificationService } from '../services/push-notification.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class HeaderComponent implements OnInit {
  user: User;
  userName: string;
  isDivNotificationToggled: boolean = false;
  @ViewChild('notifyDivId')
  public notifyDiv: ElementRef;
  notifyDivToAdd: any;
  length: number = 0;

  private connection: any = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:44366/arThek/live-chat') // mapping to the chathub as in startup.cs
    .configureLogging(signalR.LogLevel.Information)
    .build();
  readonly POST_URL = 'https://localhost:44366/arThek/chatMessage/public-chat';

  constructor(
    private authService: AuthenticationService,
    private router: Router,
    private pushNotificationService: PushNotificationService
  ) {
    this.start();
  }

  public async start() {
    try {
      await this.connection.start();
      console.log('connected');
    } catch (err) {
      console.log(err);
      setTimeout(() => this.start(), 5000);
    }
  }

  ngOnInit(): void {
    this.user = this.authService.getUserFromLocalStorage();
    this.userName = this.user.emailAddress.split('@')[0].toLowerCase();

    if (this.user.userType == '0') {
      this.notifyDivToAdd = ``;
      // this.pushNotificationService.listenNotifications(this.notifyDivToAdd);
      this.pushNotificationService
        .getMenteesNotifications(this.user.id)
        .subscribe((notifications) => {
          for (let notify in notifications) {
            this.length++;
            console.log('notify here');
            console.log(notifications[notify]);
            let itemNotify = document.createElement('span');
            itemNotify.innerHTML = notifications[notify].content;
            this.notifyDivToAdd += `<span class="notify-style"><p class="user-name">${notifications[notify].content}</p></span>`;
            this.notifyDivToAdd += `<div class="delimitator"></div>`;
          }
        });
      this.connection.on('ReceiveNotification', (menteeId, content) => {
        if (menteeId == this.user.id) {
          this.length++;
          this.notifyDivToAdd += `<span class="notify-style"><p class="user-name">${content}</p></span>`;
          this.notifyDivToAdd += `<div class="delimitator"></div>`;
        }
      });
    }
  }
  navigateToNews() {
    this.router.navigate(['dashboard/news']);
  }
  navigateToMentors() {
    this.router.navigate(['dashboard/mentors']);
  }
  logout() {
    this.authService.removeUserFromLocalStorage();
    this.router.navigate(['home']);
  }
  navigateToLiveChat() {
    this.router.navigate(['dashboard/public-chat/messenger']);
  }
  navigateToLiveStreaming() {
    this.router.navigate(['dashboard/live-streaming']);
  }

  toggleNotificationDiv() {
    this.isDivNotificationToggled = !this.isDivNotificationToggled;
  }
}
