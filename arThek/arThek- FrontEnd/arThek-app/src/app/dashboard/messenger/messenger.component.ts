import { Component, OnInit } from '@angular/core';
import { ChatService } from '../services/live-chat.service';
import { MessageBetweenUsersDto } from '../models/messageBetweenUser';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { User } from 'src/app/core/models/User';
import moment from 'moment';
import { MessengerService } from '../services/messenger.service';
import { HttpClient } from '@angular/common/http';
import { MessengerUserList } from '../models/messengerUserList';
import { IMentor } from 'src/app/register/models/createMentor';
import { Router } from '@angular/router';

@Component({
  selector: 'app-messenger',
  templateUrl: './messenger.component.html',
  styleUrls: ['./messenger.component.scss'],
})
export class MessengerComponent implements OnInit {
  user: User;
  username: string;
  userType: string;
  category: string;
  inputValueAfterSend: string = '';
  messageDate = new Date().toISOString();
  mentor: string;
  menteeId: string;
  content: string;

  constructor(
    private chatService: MessengerService,
    private authService: AuthenticationService,
    private http: HttpClient,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.user = this.authService.getUserFromLocalStorage();
    this.username = this.user.emailAddress.split('@')[0];
    if (this.user.userType == '0') {
      this.userType = 'mentee';
    } else {
      this.userType = 'mentor';
    }
    this.msgDto.user = this.username;

    this.chatService
      .retrieveMappedObject()
      .subscribe((receivedObj: MessageBetweenUsersDto) => {
        this.addToInbox(receivedObj);
        // console.log('ufu');
        // console.log(receivedObj);
      }); // calls the service method to get the new messages sent

    this.loadMessages();
    this.getCurrentlyChatUsers();
    // this.chatService.getAllMessages().subscribe((chatMessages: MessageBetweenUsersDto) => {
    //   for (let message in chatMessages) {
    //     this.addToInbox(chatMessages[message]);
    //   }
    // });
  }

  msgDto: MessageBetweenUsersDto = new MessageBetweenUsersDto();
  msgInboxArray: MessageBetweenUsersDto[] = [];
  userList: MessengerUserList[] = [];

  send(): void {
    if (this.msgDto) {
      if (this.msgDto.content.length == 0) {
        window.alert('Message field is required.');
        return;
      } else {
        if (this.userType === 'mentee') {
          let localUrl = window.location.href;
          let localUrlSplitted = localUrl.split('/');
          this.msgDto.mentor = localUrl.split('/')[localUrlSplitted.length - 1];
          this.msgDto.menteeId = this.user.id;
        } else {
          this.msgDto.mentor = this.user.id;
          let localUrl = window.location.href;
          let localUrlSplitted = localUrl.split('/');
          this.msgDto.menteeId = localUrl.split('/')[
            localUrlSplitted.length - 1
          ];
        }
        // this.msgDto.content = this.content;
        this.msgDto.messageDate = this.messageDate;
        this.chatService.broadcastMessage(this.msgDto);
        this.chatService.invokeMessageSent(this.msgDto);
        // Send the message via a service
      }
    }
    this.msgDto.content = this.inputValueAfterSend;

    // this.chatService.invokeMessageSent(this.msgDto);
  }

  addToInbox(obj: MessageBetweenUsersDto) {
    let newObj = new MessageBetweenUsersDto();
    newObj.user = obj.user;
    newObj.mentor = obj.mentor;
    newObj.menteeId = obj.menteeId;
    newObj.content = obj.content;
    newObj.messageDate = obj.messageDate.slice(0, 10);
    // console.log(newObj);
    this.msgInboxArray.push(newObj);
    // console.log(this.msgInboxArray);
  }

  loadMessages() {
    let userInfo: any = JSON.parse(localStorage.getItem('user'));
    // console.log(userInfo);
    // console.log(userInfo.emailAddress.split('@')[0]);
    let localUrl = window.location.href;
    let localUrlSplitted = localUrl.split('/');
    let receiverName = localUrl.split('/')[localUrlSplitted.length - 1];
    let menteeId = '';
    let mentorId = '';
    if (this.userType === 'mentee') {
      menteeId = userInfo.id.toLowerCase();
      mentorId = receiverName.toLowerCase();
    } else {
      menteeId = receiverName.toLowerCase();
      mentorId = userInfo.id.toLowerCase();
    }
    this.http
      .get(
        `https://localhost:44366/arThek/chatMessage/get-message/all?mentorId=${mentorId}&menteeId=${menteeId}`
      )
      .subscribe((data: Array<any>) => {
        for (let i = 0; i < data.length; i++) {
          this.chatService.mapReceivedMessage(
            data[i].user,
            data[i].content,
            data[i].messageDate
          );
        }
        // this.chatService.mapReceivedMessage(data)
      });
  }

  getCurrentlyChatUsers() {
    // https://localhost:44366/arThek/chatMessage/get-chat-users?userId=F15AFB17-2BBB-4D65-983D-08D8FD7FDC9C&userType=0
    this.http
      .get(
        `https://localhost:44366/arThek/chatMessage/get-chat-users?userId=${this.user.id}&userType=${this.user.userType}`
      )
      .subscribe((data: Array<any>) => {
        for (let index = 0; index < data.length; ++index) {
          this.parseUserList(data[index]);
          console.log(this.userList);
        }
      });
  }

  parseUserList(obj: IMentor) {
    let newObj = new MessengerUserList();
    console.log(obj);
    newObj.id = obj.id;
    newObj.userProfileImage = obj.profileImagePath;
    newObj.userName = obj.userName;
    newObj.userType = obj.userRole;
    this.userList.push(newObj);
  }

  sendMessageToUser(userSelectedId){
    console.log(userSelectedId);
    this.router.navigate([`dashboard/public-chat/messenger/${userSelectedId}`]).then(() => {
      window.location.reload();
    });
  }
}
