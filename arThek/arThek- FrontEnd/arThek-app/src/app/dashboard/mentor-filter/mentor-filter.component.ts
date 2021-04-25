import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IMentee } from 'src/app/register/models/createMentee';
import { IMentor } from 'src/app/register/models/createMentor';
import { FilterForm } from '../models/filter-form';
import { FilterOptions } from '../models/filter-options';
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

  constructor(private filterService: FilterMentorService) {}

  ngOnInit(): void {
    this.loadTableData();
  }

  profileSelected(id: string) {
    console.log(id);
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
}
