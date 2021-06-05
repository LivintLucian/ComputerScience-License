import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IMentor } from 'src/app/register/models/createMentor';
import { MentorParameter } from '../models/mentor-parameters';
import { MentorResponseForOutput } from '../models/mentor-response-output';
import { FollowModel } from '../models/followModel';

@Injectable({
  providedIn: 'root',
})
export class FilterMentorService {
  constructor(private http: HttpClient) {}

  getAllMentors(): Observable<IMentor> {
    return this.http.get<IMentor>(`${environment.baseAPI}/mentor/getAll`);
  }

  filter(mentorParameter: MentorParameter): Observable<IMentor> {
    return this.http.post<IMentor>(
      `${environment.baseAPI}/mentor/filter`,
      mentorParameter
    );
  }

  getAllFollowers(): Observable<FollowModel>{
    return this.http.get<FollowModel>(`${environment.baseAPI}/notification/follow/getAll`);
  }

  
  getAllMenteeFollowing(menteeId: string): Observable<FollowModel>{
    return this.http.get<FollowModel>(`${environment.baseAPI}/notification/follow/mentee-following?menteeId=${menteeId}`);
  }

  followMentor(followParameters: FollowModel): Observable<FollowModel> {
    return this.http.post<FollowModel>(
      `${environment.baseAPI}/notification/follow`,
      followParameters
    );
  }

  unfollowMentor(mentorId: string, menteeId: string) {
    return this.http.put(
      `${environment.baseAPI}/notification/unfollow?mentorId=${mentorId}&menteeId=${menteeId}`,
      {}
    );
  }
}
