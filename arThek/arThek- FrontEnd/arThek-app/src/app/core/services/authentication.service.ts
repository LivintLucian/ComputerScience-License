import { InvalidUserFormatException } from '../exceptions/invalid-user-format.exception';
import { LocalStorageService } from './local-storage.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { Observable, Subject, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  isLoggedInSub: ReplaySubject<boolean> = new ReplaySubject<boolean>();
  constructor(private http: HttpClient, private localStorageService: LocalStorageService) {
    if(this.isLoggedIn()) {
      this.isLoggedInSub.next(true);
    }
  }

  login(emailAddress: string): Observable<User> {
    const authenticateEnpoint = `${environment.baseAPI}/home/login`;
    return this.http
      .post<User>(authenticateEnpoint, { emailAddress })
      .pipe(
        tap(user => {
          this.localStorageService.set('user', user);
          this.isLoggedInSub.next(true);
          return user;
        })
      );
  }

  public isLoggedIn(): boolean {
    let user: User = null;
    try {
      user = this.getUserFromLocalStorage();
    }
    catch (err) {

    }
    return user !== null;
  }

  getUserFromLocalStorage(): User {
    try {
      return this.localStorageService.get<User>('user');
    }
    catch (err) {
      if (err instanceof SyntaxError) {
        throw new InvalidUserFormatException('Cannnot parse user from localStorage');
      }
      throw err;
    }
  }

  removeUserFromLocalStorage() {
    this.isLoggedInSub.next(false);
    this.localStorageService.remove('user');
  }
}
