import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';;

@Injectable({
  providedIn: 'root',
})
export class PushNotificationService {
  private connection: any = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:44366/arThek/live-chat') // mapping to the chathub as in startup.cs
    .configureLogging(signalR.LogLevel.Information)
    .build();
  readonly POST_URL = 'https://localhost:44366/arThek/chatMessage/public-chat';

  constructor() {
    this.connection.on(
      'ReceiveNotification',
      (mentorId, content) => {
        console.log(mentorId, content);

        let localUrl = window.location.href;
        let localUrlSplitted = localUrl.split('/');
        let receiverName = localUrl.split('/')[localUrlSplitted.length - 1];
      }
    );
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

  public invokeTest(){
    this.connection
    .invoke(
      'SendNotification',
      'CAF14388-E0CF-4ED6-ECA3-08D91907E84B',
      'Mentor published article'
    )
    .then((data) => {
      console.log(data);
      
    });
  }
}
