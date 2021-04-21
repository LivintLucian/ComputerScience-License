import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MatRadioChange } from '@angular/material/radio';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { FilterForm } from '../models/filter-form';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss'],
})
export class FilterComponent implements OnInit {
  filterForm: FormGroup;
  removableChip = true;
  openDropDown = false;
  inputName = '';
  inputTrainer = '';
  @Input() isFilterOpen = true;
  @Input() formInit: FilterForm;
  @Output() filterClose: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() onFilterChange = new EventEmitter<FilterForm>();
  options: string[] = [
    'Logo Designer',
    'Graphic Designer',
    'Ui/Ux',
    'Web Designer',
    'Animation Designer',
  ];
  filteredOptions: Observable<string[]>;

  constructor() {}

  ngOnInit(): void {
    this.filterForm = new FormGroup({
      userName: new FormControl(this.formInit.userName),
      domain: new FormControl(this.formInit.domain),
      isVolunteer: new FormControl(this.formInit.isVolunteer),
    });

    this.filteredOptions = this.domain.valueChanges.pipe(
      startWith(''),
      map((value) => this._filter(value))
    );
  }

  onSubmit() {
    let formData = <FilterForm>this.filterForm.value;
    if (this.formInit.isVolunteer === true) {
      formData.isVolunteer = true;
    } else {
      formData.isVolunteer = false;
    }
    console.log(formData);
    this.onFilterChange.emit(formData);
    this.closeFilter();
  }

  closeFilter() {
    this.filterClose.emit(!this.isFilterOpen);
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.options.filter((option) =>
      option.toLowerCase().includes(filterValue)
    );
  }

  radioChange(event: MatRadioChange) {
    if (event.value === 'volunteerMentor') {
      this.formInit.isVolunteer = true;
    } else {
      this.formInit.isVolunteer = false;
    }
  }

  get domain() {
    return this.filterForm.get('domain');
  }

  get userName() {
    return this.filterForm.get('userName');
  }

  get IsVolunteer() {
    return this.filterForm.get('IsVolunteer');
  }
}
