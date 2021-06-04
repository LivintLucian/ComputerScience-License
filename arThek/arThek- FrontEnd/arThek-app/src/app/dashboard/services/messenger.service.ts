import { Injectable, OnInit } from '@angular/core';
import * as signalR from '@microsoft/signalr'; // import signalR
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { MessageBetweenUsersDto } from '../models/messageBetweenUser';
import { LocalStorageService } from '../../core/services/local-storage.service';

@Injectable({
  providedIn: 'root',
})
export class MessengerService {
  private connection: any = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:44366/arThek/live-chat') // mapping to the chathub as in startup.cs
    .configureLogging(signalR.LogLevel.Information)
    .build();
  readonly POST_URL = 'https://localhost:44366/arThek/chatMessage/send-message';

  private receivedMessageObject: MessageBetweenUsersDto = new MessageBetweenUsersDto();
  private sharedObj = new Subject<MessageBetweenUsersDto>();

  constructor(
    private http: HttpClient,
    private localServiceStorage: LocalStorageService
  ) {
    this.connection.onclose(async () => {
      await this.start();
    });
    this.connection.on(
      'ReceiveTwo',
      (user, sender, receiver, message, messageDate) => {
        if (user === localStorage.getItem('user')) {
          this.mapReceivedMessage(user, message, messageDate);
          console.log(message);
        }
        // console.log(localStorage.getItem('user'));
        // console.log(user,message);
        
        // let url = window.location.href.split('?')[1].split('=')[1];
        let userInfo: any = JSON.parse(localStorage.getItem('user'));
        console.log(userInfo);
        console.log(userInfo.emailAddress.split('@')[0]);
        let localUrl = window.location.href;
        let localUrlSplitted = localUrl.split('/');
        let receiverName = localUrl.split('/')[localUrlSplitted.length - 1];
        console.log(receiver, sender);
        if (
          userInfo.id.toLowerCase() === receiver.toLowerCase() &&
          receiverName.toLowerCase() === sender.toLowerCase()
        ) {
          console.log('Received from ' + sender + ' : ' + message);
          this.mapReceivedMessage(user, message, messageDate);
        }
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

  public mapReceivedMessage(
    user: string,
    message: string,
    messageDate: string
  ): void {
    this.receivedMessageObject.user = user;
    this.receivedMessageObject.mentor = 'Mentor';
    this.receivedMessageObject.menteeId = 'MenteId';
    this.receivedMessageObject.content = message;
    this.receivedMessageObject.messageDate = messageDate;
    this.sharedObj.next(this.receivedMessageObject);
  }

  public broadcastMessage(msgDto: any) {
    this.http
      .post(this.POST_URL, msgDto)
      .subscribe((data) => console.log(data));
  }

  public retrieveMappedObject(): Observable<MessageBetweenUsersDto> {
    return this.sharedObj.asObservable();
  }

  public invokeMessageSent(data) {
    console.log(window.location.href);
    let localUrl = window.location.href;
    let localUrlSplitted = localUrl.split('/');
    let receiverName = localUrl.split('/')[localUrlSplitted.length - 1];
    let senderName = JSON.parse(localStorage.getItem('user')).id;
    let messageDate = data.messageDate;
    let tmpData = data;
    console.log('From ', senderName, receiverName);
    console.log(data);
    let msgBody = data.content;
    this.connection
      .invoke(
        'sendmessage2',
        data.user,
        senderName,
        receiverName,
        data.content,
        ''
      )
      .then((data) => {
        console.log('flat');
        console.log(tmpData);
        this.mapReceivedMessage(tmpData.user, msgBody, messageDate);
      });
  }

  //   public getAllMessages(): Observable<MessageBetweenUsersDto> {
  //     return this.http
  //       .get<MessageBetweenUsersDto>(`${environment.baseAPI}/ChatMessage/public-chat`);
  //   }
}
