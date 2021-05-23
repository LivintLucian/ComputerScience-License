import { Injectable } from '@angular/core';
import * as Rx from 'rxjs';
import { Observable, Subject } from 'rxjs';
import { Observer } from 'rxjs/internal/types';

@Injectable({
  providedIn: 'root',
})
export class WebsocketService {
  constructor() {}

  private subject: Rx.Subject<MessageEvent>;

  public connect(url): Rx.Subject<MessageEvent> {
    if (!this.subject) {
      this.subject = this.create(url);
      console.log('U re connected to ' + url);
    }
    return this.subject;
  }

  private create(url): Rx.Subject<MessageEvent> {
    let ws = new WebSocket(url);

    let observable = Rx.Observable.create((observer: Rx.Observer<MessageEvent>) => {
      ws.onmessage = observer.next.bind(observer);
      ws.onerror = observer.error.bind(observer);
      ws.onclose = observer.complete.bind(observer);
      return ws.close.bind(ws);
    });

    let obs = {
      next: (data: MessageEvent) => {
        if (ws.readyState === WebSocket.OPEN) {
          ws.send(JSON.stringify(data));
        }
      },
    };

    return Rx.Subject.create(obs, observable);
  }
}
