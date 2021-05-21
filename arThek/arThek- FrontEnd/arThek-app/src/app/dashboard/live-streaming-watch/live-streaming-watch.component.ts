import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-live-streaming-watch',
  templateUrl: './live-streaming-watch.component.html',
  styleUrls: ['./live-streaming-watch.component.scss']
})
export class LiveStreamingWatchComponent implements OnInit {
  socket: any;
  constructor() { }

  ngOnInit(): void {
  }

  watchStream() {
    this.socket = new WebSocket("ws://localhost:9010");
  
    this.socket.addEventListener("open", (event) => {
      // var reader = new FileReader();
      // reader.readAsDataURL(event.srcElement);
      // reader.onloadend = function() {
      //     var base64data = reader.result;                
      //     console.log(base64data);
      // }
      console.log("opened");
      console.log(JSON.parse(event.data));
      window.requestAnimationFrame(() => {
        document.getElementById("live").setAttribute("src", event.data);
      });
    });
    this.socket.addEventListener("message", (event) => {
      window.requestAnimationFrame(() => {
        document.getElementById("live").setAttribute("src", event.data);
      });
    });
  }
}
