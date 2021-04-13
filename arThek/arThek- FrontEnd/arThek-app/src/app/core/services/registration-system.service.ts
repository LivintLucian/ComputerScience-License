import { LocalStorageService } from './local-storage.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IMentee } from 'src/app/register/models/createMentee';

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
    return this.http.get<IMentee>(`${environment.baseAPI}/register/mentee/${id}`);
  }

  createMentor(mentee: FormData) {
    return this.http.post(`${environment.baseAPI}/mentor`, mentee);
  }

  getMentorById(id: string): Observable<IMentee> {
    return this.http.get<IMentee>(`${environment.baseAPI}/mentor/profile/${id}`);
  }

  isMentorVolunteer(isVolunteer: boolean){
    return this.http.put(`${environment.baseAPI}/register/mentor/mentorType?isVolunteer=${isVolunteer}`, {});
  }

}
