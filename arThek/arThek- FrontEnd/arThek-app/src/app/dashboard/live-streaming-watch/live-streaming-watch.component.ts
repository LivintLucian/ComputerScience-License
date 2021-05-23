import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { LiveStreamingService } from '../services/live-streaming.service';

@Component({
  selector: 'app-live-streaming-watch',
  templateUrl: './live-streaming-watch.component.html',
  styleUrls: ['./live-streaming-watch.component.scss'],
})
export class LiveStreamingWatchComponent implements OnInit {
  socket: any;
  frames: any;

  @ViewChild('live')
  public live: ElementRef;

  constructor(private liveStreamService: LiveStreamingService) {}

  ngOnInit(): void {}

  watchStream() {
    this.liveStreamService.videoFrames.subscribe((frame) => {
      window.requestAnimationFrame(() => {
        this.live.nativeElement.setAttribute('src', frame);
      });
    });
  }
}
