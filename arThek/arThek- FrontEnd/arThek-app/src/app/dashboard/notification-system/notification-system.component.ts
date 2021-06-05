import { Component, OnInit } from '@angular/core';
import { PushNotificationService } from '../services/push-notification.service';

@Component({
  selector: 'app-notification-system',
  templateUrl: './notification-system.component.html',
  styleUrls: ['./notification-system.component.scss']
})
export class NotificationSystemComponent implements OnInit {

  constructor(private pushNotificationService: PushNotificationService) { }

  ngOnInit(): void {
  }

  invokeTest(){
    this.pushNotificationService.invokeTest();
  }

  

}
