import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class LiveStreamingService {
  constructor(private http: HttpClient) {}

  startStream() {
    return this.http.post(
      `${environment.baseAPI}/LiveStreaming`, {}
    );
  }
}
