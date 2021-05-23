import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { WebsocketService } from './websocket-service.service';
import { map } from 'rxjs/operators'

const STREAM_URL = 'ws://localhost:9010';

export interface LiveData{
  audio: any;
  video: any;
}

@Injectable({
  providedIn: 'root',
})
export class LiveStreamingService {
  // public frames: Subject<LiveData>;
  public videoFrames: Subject<MessageEvent>;
  
  constructor(private http: HttpClient, private wsService: WebsocketService) {
    // this.frames = <Subject<LiveData>>wsService.connect(STREAM_URL).pipe(map(
    //   (response: any): LiveData => {
    //     let data = JSON.parse(response.data);
    //     return{
    //       audio: data.audio,
    //       video: data.video
    //     };
    //   }));
      this.videoFrames = <Subject<MessageEvent>>wsService.connect(STREAM_URL).pipe(map(
        (response: any): MessageEvent => {
          return JSON.parse(response.data);
        }
      ));
  }

  startStream() {
    return this.http.post(
      `${environment.baseAPI}/LiveStreaming`, {}
    );
  }
}
