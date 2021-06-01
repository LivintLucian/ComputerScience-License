import { LocalStorageService } from './local-storage.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IMentee } from 'src/app/register/models/createMentee';
import { IMentor, IMentorProfile } from 'src/app/register/models/createMentor';
import { tap } from 'rxjs/operators';
import { User } from '../models/User';

@Injectable({
  providedIn: 'root',
})
export class RegistrationSystemService {
  constructor(
    private http: HttpClient,
    private localStorageService: LocalStorageService
  ) {}

  createMentee(mentee: FormData) {
    return this.http.post(`${environment.baseAPI}/register/mentee`, mentee);
  }

  getMenteeById(id: string): Observable<IMentee> {
    return this.http.get<IMentee>(
      `${environment.baseAPI}/register/mentee/${id}`
    );
  }

  createMentor(mentor: FormData) {
    return this.http.post(`${environment.baseAPI}/mentor`, mentor);
  }

  getMentorById(id: string): Observable<IMentor> {
    return this.http.get<IMentor>(
      `${environment.baseAPI}/mentor/profile/${id}`
    );
  }

  getLastMentor() {
    return this.http.get<IMentorProfile>(
      `${environment.baseAPI}/mentor/profile/lastMentor`,
      {}
    );
  }

  isMentorVolunteer(isVolunteer: boolean) {
    return this.http.put(
      `${environment.baseAPI}/register/mentor/mentorType?isVolunteer=${isVolunteer}`,
      {}
    );
  }

  mentorAdditionalData(mentorAdditionalData: FormData) {
    return this.http.put(
      `${environment.baseAPI}/register/mentor/additional-data`,
      mentorAdditionalData
    );
  }

  mentorProfile(mentorProfile: FormData) : Observable<any> {
    return this.http.put(
      `${environment.baseAPI}/register/mentor/mentor-profile`,
      mentorProfile
    ).pipe(
      tap(user => {
        this.localStorageService.set('user', user);
        return user;
      })
    );
  }
}
