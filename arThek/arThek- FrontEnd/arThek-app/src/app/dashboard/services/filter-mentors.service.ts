import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IMentor } from 'src/app/register/models/createMentor';
import { MentorParameter } from '../models/mentor-parameters';
import { MentorResponseForOutput } from '../models/mentor-response-output';

@Injectable({
  providedIn: 'root',
})
export class FilterMentorService {
  constructor(private http: HttpClient) {}

  getAllMentors(): Observable<IMentor> {
    return this.http.get<IMentor>(
      `${environment.baseAPI}/mentor/getAll`
    );
  }

  filter(
    mentorParameter: MentorParameter
  ): Observable<MentorResponseForOutput>{
    return this.http.post<MentorResponseForOutput>(
      `${environment.baseAPI}/mentor/filter`,
      mentorParameter
    )
  }
}
