import { InvalidUserFormatException } from '../exceptions/invalid-user-format.exception';
import { LocalStorageService } from './local-storage.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root',
})
export class RegistrationSystemService {
  constructor(
    private http: HttpClient,
    private localStorageService: LocalStorageService
  ) {}

  isMentee(isMentee: boolean): Observable<User> {
    const authenticateEnpoint = `${environment.baseAPI}/register/UserType?isMentee=${isMentee}`;
    return this.http.post<User>(authenticateEnpoint, {}).pipe(
      tap((user) => {
        this.localStorageService.set('user', user);
        return user;
      })
    );
  }

  getUserFromLocalStorage(): User {
    try {
      return this.localStorageService.get<User>('user');
    } catch (err) {
      if (err instanceof SyntaxError) {
        throw new InvalidUserFormatException(
          'Cannnot parse user from localStorage'
        );
      }
      throw err;
    }
  }

  removeUserFromLocalStorage() {
    this.localStorageService.remove('user');
  }
}
