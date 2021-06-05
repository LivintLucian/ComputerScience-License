import {
  AfterViewChecked,
  AfterViewInit,
  Component,
  ElementRef,
  OnInit,
  Renderer2,
  ViewChild,
} from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Button } from 'selenium-webdriver';
import { User } from 'src/app/core/models/User';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { LocalStorageService } from 'src/app/core/services/local-storage.service';
import { IMentee } from 'src/app/register/models/createMentee';
import { IMentor } from 'src/app/register/models/createMentor';
import { FilterForm } from '../models/filter-form';
import { FilterOptions } from '../models/filter-options';
import { FollowModel } from '../models/followModel';
import { MentorParameter } from '../models/mentor-parameters';
import { MentorResponse } from '../models/mentor-response';
import { MentorResponseForOutput } from '../models/mentor-response-output';
import { FilterMentorService } from '../services/filter-mentors.service';

@Component({
  selector: 'app-mentor-filter',
  templateUrl: './mentor-filter.component.html',
  styleUrls: ['./mentor-filter.component.scss'],
})
export class MentorFilterComponent implements OnInit {
  mentors: IMentor;
  isFilterToggled = false;
  filterFormData: FilterForm = this.initialFormState();
  filterOptions: FilterOptions;
  isFiltred = false;
  followModel: FollowModel = new FollowModel();
  followModel2: FollowModel = new FollowModel();
  user: User;
  htmlCollection: HTMLCollection;

  constructor(
    private filterService: FilterMentorService,
    private router: Router,
    private localStorage: LocalStorageService,
    private authService: AuthenticationService,
    private render: Renderer2
  ) {}

  ngOnInit(): void {
    this.user = this.authService.getUserFromLocalStorage();
    this.loadTableData();
    this.getMenteesFollowing();
  }

  profileSelected(id: string) {
    this.router.navigate(['dashboard/mentors/mentor-profile', id]);
  }

  onFilterChange(event: FilterForm) {
    this.filterFormData = event;
    this.convertFormDataToFilterOptions(event);
    this.isFiltred = !this.checkIfNoFilters(event);
    this.loadTableData();
  }

  convertFormDataToFilterOptions(event: FilterForm) {
    this.filterOptions = {
      userName: event.userName,
      domain: event.domain,
      isVolunteer: event.isVolunteer,
    };
  }

  checkIfNoFilters(data: FilterForm): boolean {
    return Object.values(data).every(
      (t) =>
        this.isEmptyString(t) || this.isNullOrUndefined(t) || this.isFalse(t)
    );
  }

  loadTableData() {
    const mentorParameter: MentorParameter = {
      filterMentorsDto: this.filterOptions,
    };
    if (this.isFiltred) {
      this.filterService
        .filter(mentorParameter)
        .subscribe((data: MentorResponseForOutput) => {
          this.mentors = data;
        });
    } else {
      this.filterService
        .getAllMentors()
        .subscribe((data: MentorResponseForOutput) => {
          console.log(data);
          this.mentors = data;
        });
    }
  }

  initialFormState(): FilterForm {
    return {
      userName: '',
      domain: '',
      isVolunteer: undefined,
    };
  }

  isFalse(value): boolean {
    return (value === true || value === false) && value === false;
  }

  isNullOrUndefined(value): boolean {
    return value === null || value === undefined;
  }

  isEmptyString(value): boolean {
    return typeof value === 'string' && value === '';
  }

  filterToggle() {
    this.isFilterToggled = !this.isFilterToggled;
  }

  filterClose(event) {
    this.isFilterToggled = event;
  }

  follow(e, mentorId) {
    let followButton = e.target;
    this.followModel2.menteeId = this.user.id;
    this.followModel2.mentorId = mentorId;

    console.log(followButton.innerHTML);
    if (followButton.innerHTML == '+ Follow') {
      followButton.style.color = '#fff';
      followButton.innerHTML = 'Followed';
      followButton.style.backgroundColor = '#699eee';
      followButton.style.opacity = '0.5';

      this.filterService.followMentor(this.followModel2).subscribe((data) => {
        console.log(data);
      });
    } else {
      followButton.innerHTML = '+ Follow';
      followButton.style.color = '#3399FF';
      followButton.style.borderColor = '#3399FF';
      followButton.style.backgroundColor = '#fff';
      followButton.style.opacity = '1';
      console.log('else ul asta');
      console.log(this.followModel2);

      this.filterService
        .unfollowMentor(this.followModel2.mentorId, this.followModel2.menteeId)
        .subscribe((data) => {
          console.log(data);
        });
    }
  }

  checkIfFollowed(mentorId){
    for(let i in this.followModel){
      if(this.followModel[i].mentorId === mentorId && this.followModel[i].unfollowed === false){
        return true;
      }
    }
    return false;
  }

  getMenteesFollowing() {
    this.filterService.getAllMenteeFollowing(this.user.id).subscribe((data) => {
      this.followModel = data;
    });
  }
}
