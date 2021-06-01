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
  isLiveOff: boolean = true;
  isUserWatchingStream: boolean = false;

  @ViewChild('live')
  public live: ElementRef;

  @ViewChild('thumbnail')
  public thumbnail: ElementRef;

  constructor(private liveStreamService: LiveStreamingService) {}

  ngOnInit(): void {
    let isExecutedOnce = false;
    this.liveStreamService.videoFrames.subscribe((frame) => {
      if (!isExecutedOnce) {
        window.requestAnimationFrame(() => {
          this.thumbnail.nativeElement.setAttribute('src', frame);
        });
        isExecutedOnce = true;
      }
      this.isLiveOff = false;
    });
  }

  watchStream() {
    this.isUserWatchingStream = true;
    this.liveStreamService.videoFrames.subscribe((frame) => {
      window.requestAnimationFrame(() => {
        this.live.nativeElement.setAttribute('src', frame);
      });
    });
  }
}
