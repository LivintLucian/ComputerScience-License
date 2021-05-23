import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { LiveStreamingService } from '../services/live-streaming.service';

@Component({
  selector: 'app-live-streaming',
  templateUrl: './live-streaming.component.html',
  styleUrls: ['./live-streaming.component.scss'],
})
export class LiveStreamingComponent {
  socket: any;
  isStarted: boolean = false;
  isLiveServerOn: boolean = false;
  isCanvasVisible: boolean = false;

  @ViewChild('video')
  public video: ElementRef;

  @ViewChild('canvas')
  public canvas: ElementRef;

  constructor(private liveStreamService: LiveStreamingService) {
  }

  startStreamingServer() {
    console.log('pressed');
    this.liveStreamService.startStream().subscribe((data) => {
      console.log(data);
    });
  }

  async startStream() {
    this.isStarted = true;

    if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
      navigator.mediaDevices
        .getUserMedia({ video: true })
        .then((stream) => {
          this.video.nativeElement.srcObject = stream;
          this.video.nativeElement.play();

          this.socket = new WebSocket('ws://localhost:9010');
          this.socket.addEventListener('open', () => {
            window.requestAnimationFrame(() =>
              this.capture(this.video.nativeElement)
            );
          });
          this.socket.addEventListener('message', (event) => {
            window.requestAnimationFrame(() => {
              document.getElementById('live').setAttribute('src', event.data);
            });
          });
        })
        .catch(function (err) {
          console.log(err.name + ': ' + err.message);
        });
    }
  }

  public capture(receivedVideo: HTMLVideoElement) {
    this.canvas.nativeElement
      .getContext('2d')
      .drawImage(receivedVideo, 0, 0, 250, 250);

    let captureFromVideo = this.canvas.nativeElement.toDataURL('image/png');
    this.liveStreamService.videoFrames.next(captureFromVideo);

    window.requestAnimationFrame(() => this.capture(receivedVideo));
  }
}
