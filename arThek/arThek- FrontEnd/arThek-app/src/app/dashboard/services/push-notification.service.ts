import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { NotificationDto } from '../models/notification';

@Injectable({
  providedIn: 'root',
})
export class PushNotificationService {
  private connection: any = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:44366/arThek/live-chat') // mapping to the chathub as in startup.cs
    .configureLogging(signalR.LogLevel.Information)
    .build();
  readonly POST_URL = 'https://localhost:44366/arThek/chatMessage/public-chat';

  constructor(private http: HttpClient) {
    this.start();
  }

  public listenNotifications(notifyDivToAdd: any, length: number = 0){
    this.connection.on('ReceiveNotification', (mentorId, content) => {
        this.getMenteesNotifications(mentorId)
        .subscribe((notifications) => {
          for (let notify in notifications) {
            length++;
            console.log('notify here');
            console.log(notifications[notify]);
            let itemNotify = document.createElement('span');
            itemNotify.innerHTML = notifications[notify].content;
            notifyDivToAdd += `<span class="notify-style"><p class="user-name">${content}</p></span>`;
            notifyDivToAdd += `<span class="notify-style"><p class="user-name">${notifications[notify].content}</p></span>`;
            notifyDivToAdd += `<div class="delimitator"></div>`;
          }
        });
    });
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

  public pushNotification(
    notificationDto: NotificationDto
  ): Observable<NotificationDto> {
    let formData = new FormData();
    formData.append('MentorId', notificationDto.mentorId);
    formData.append('Content', notificationDto.content);
    console.log(formData);
    return this.http.post<any>(
      `${environment.baseAPI}/notification/notifications`,
      formData
    );
  }

  public getMenteesNotifications(
    menteeId: string
  ): Observable<NotificationDto> {
    return this.http.get<NotificationDto>(
      `${environment.baseAPI}/notification/notifications?menteeId=${menteeId}`
    );
  }

  public invokeNotification(mentorId: string, content: string) {
    this.connection
      .invoke(
        'SendNotification',
        mentorId,
        content
      )
      .then((data) => {
        console.log(data);
      });
  }
}
