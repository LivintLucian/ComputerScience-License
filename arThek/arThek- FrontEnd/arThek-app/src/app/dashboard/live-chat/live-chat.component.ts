import { Component, OnInit } from '@angular/core';
import { ChatService } from '../services/live-chat.service';
import { MessageDto } from '../models/message';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { User } from 'src/app/core/models/User';
import moment from 'moment';

@Component({
  selector: 'app-live-chat',
  templateUrl: './live-chat.component.html',
  styleUrls: ['./live-chat.component.scss'],
})
export class LiveChatComponent implements OnInit {
  user: User;
  username: string;
  userType: string;
  category: string;
  inputValueAfterSend: string = '';
  messageDate = new Date().toISOString();

  constructor(
    private chatService: ChatService,
    private authService: AuthenticationService
  ) {}

  ngOnInit(): void {
    this.user = this.authService.getUserFromLocalStorage();
    this.username = this.user.emailAddress.split('@')[0];
    if (this.user.userType == '0') {
      this.userType = 'mentee';
    } else {
      this.userType = 'mentor';
    }
    this.category = this.user.category;
    this.msgDto.user = this.username;

    this.chatService
      .retrieveMappedObject()
      .subscribe((receivedObj: MessageDto) => {
        this.addToInbox(receivedObj);
      }); // calls the service method to get the new messages sent

    this.chatService.getAllMessages().subscribe((chatMessages: MessageDto) => {
      for (let message in chatMessages) {
        this.addToInbox(chatMessages[message]);
      }
    });
  }

  msgDto: MessageDto = new MessageDto();
  msgInboxArray: MessageDto[] = [];

  send(): void {
    if (this.msgDto) {
      if (this.msgDto.msgText.length == 0) {
        window.alert('Message field is required.');
        return;
      } else {
        this.msgDto.user = this.username;
        this.msgDto.userType = this.userType;
        this.msgDto.category = this.category;
        this.msgDto.messageDate = this.messageDate;
        this.chatService.broadcastMessage(this.msgDto); // Send the message via a service
      }
    }
    this.msgDto.msgText = this.inputValueAfterSend;
  }

  addToInbox(obj: MessageDto) {
    let newObj = new MessageDto();
    newObj.user = obj.user;
    newObj.msgText = obj.msgText;
    newObj.userType = obj.userType;
    newObj.category = obj.category;
    newObj.messageDate = obj.messageDate.slice(0, 10);
    this.msgInboxArray.push(newObj);
  }
}
