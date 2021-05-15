import { EventEmitter, Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { environment } from 'src/environments/environment';
import { ChatMessage } from '../models/live-chat';

@Injectable({
  providedIn: 'root',
})
export class ChatService {
  messageReceived = new EventEmitter<ChatMessage>();
  connectionEstablished = new EventEmitter<Boolean>();

  private connectionIsEstablished = false;
  private _hubConnection: HubConnection;

  constructor() {
    this.createConnection();
    this.registerOnServerEvents();
    this.startConnection();
  }

  sendMessage(message: ChatMessage) {
    this._hubConnection.invoke('NewMessage', message);
  }

  private createConnection() {
    this._hubConnection = new HubConnectionBuilder()
      .withUrl(`${environment.baseAPI}/` + 'live-chat')
      .build();
  }

  private startConnection(): void {
    this._hubConnection
      .start()
      .then(() => {
        this.connectionIsEstablished = true;
        console.log('Hub connection started');
        this.connectionEstablished.emit(true);
      })
      .catch((err) => {
        console.log('Error while establishing connection, retrying...');
        setTimeout(function () {
          this.startConnection();
        }, 5000);
      });
  }

  private registerOnServerEvents(): void {
    this._hubConnection.on('MessageReceived', (data: any) => {
      this.messageReceived.emit(data);
    });
  }
}
