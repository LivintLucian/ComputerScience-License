import { Component, OnInit } from '@angular/core';
import { LiveStreamingService } from '../services/live-streaming.service';

@Component({
  selector: 'app-live-streaming',
  templateUrl: './live-streaming.component.html',
  styleUrls: ['./live-streaming.component.scss'],
})
export class LiveStreamingComponent {
  constructor(private liveStreamService: LiveStreamingService) {}

  startStream() {
    console.log('pressed');
    this.liveStreamService.startStream().subscribe(data => {
      console.log(data);
    })
  }
}
