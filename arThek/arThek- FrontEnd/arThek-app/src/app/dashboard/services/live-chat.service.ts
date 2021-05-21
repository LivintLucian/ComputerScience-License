import { Injectable, OnInit } from '@angular/core';
import * as signalR from '@microsoft/signalr'; // import signalR
import { HttpClient } from '@angular/common/http';
import { MessageDto } from '../models/message';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class ChatService {
  private connection: any = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:44366/arThek/live-chat') // mapping to the chathub as in startup.cs
    .configureLogging(signalR.LogLevel.Information)
    .build();
  readonly POST_URL = 'https://localhost:44366/arThek/chatMessage/public-chat';

  private receivedMessageObject: MessageDto = new MessageDto();
  private sharedObj = new Subject<MessageDto>();

  constructor(private http: HttpClient) {
    this.connection.onclose(async () => {
      await this.start();
    });
    this.connection.on('ReceiveOne', (user, message, category, userType, messageDate) => {
      this.mapReceivedMessage(user, message, category, userType, messageDate);
    });
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

  private mapReceivedMessage(user: string, message: string, category: string, userType: string, messageDate: string): void {
    this.receivedMessageObject.user = user;
    this.receivedMessageObject.msgText = message;
    this.receivedMessageObject.category = category;
    this.receivedMessageObject.userType = userType;
    this.receivedMessageObject.messageDate = messageDate;
    this.sharedObj.next(this.receivedMessageObject);
  }

  public broadcastMessage(msgDto: any) {
    this.http
      .post(this.POST_URL, msgDto)
      .subscribe((data) => console.log(data));
  }

  public retrieveMappedObject(): Observable<MessageDto> {
    return this.sharedObj.asObservable();
  }

  public getAllMessages(): Observable<MessageDto> {
    return this.http
      .get<MessageDto>(`${environment.baseAPI}/ChatMessage/public-chat`);
  }
}
