import { Component, NgZone, OnInit } from '@angular/core';
import { ChatMessage } from '../models/live-chat';
import { ChatService } from '../services/live-chat.service';

@Component({
  selector: 'app-live-chat',
  templateUrl: './live-chat.component.html',
  styleUrls: ['./live-chat.component.scss'],
})
export class LiveChatComponent {
  title = 'LiveChat-App';
  txtMessage = '';
  uniqueID: string = new Date().getTime().toString();
  messages = new Array<ChatMessage>();
  messageForm = {} as ChatMessage;

  constructor(private chatService: ChatService, private _ngZone: NgZone) {
    this.subscribeToEvents();
  }

  sendMessage(): void {
    if (this.txtMessage) {
      this.txtMessage = '';
      this.messageForm.content = this?.txtMessage;
      this.messages.push(this.messageForm);
      this.chatService.sendMessage(this.messageForm);
    }
  }

  private subscribeToEvents(): void {
    this.chatService.messageReceived.subscribe((ChatMessage: ChatMessage) => {
      this._ngZone.run(() => {
        this.messages.push(ChatMessage);
      });
    });
  }
}
