import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { RegistrationSystemService } from 'src/app/core/services/registration-system.service';
import { ICreateMentee, IMentee } from '../models/createMentee';
import * as moment from 'moment';
import { NotificationService } from 'src/app/core/services/notification.service';
import { HttpErrorResponse } from '@angular/common/http';
import { MyErrorStateMatcher } from 'src/app/core/error-state-matcher/error-state-matcher';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';

@Component({
  selector: 'app-register-join-as-mentor',
  templateUrl: './register-join-as-mentor.component.html',
  styleUrls: ['./register-join-as-mentor.component.scss'],
})
export class RegisterJoinAsMentorComponent implements OnInit {
  id: string;
  joinAsMentorFormState: IMentee;
  joinAsMentorForm: FormGroup;
  matcher = new MyErrorStateMatcher();
  options: string[] = [
    'Logo Designer',
    'Graphic Designer',
    'Ui/Ux',
    'Web Designer',
    'Animation Designer',
  ];
  filteredOptions: Observable<string[]>;

  constructor(
    private router: Router,
    private registrationService: RegistrationSystemService,
    private routeActivated: ActivatedRoute,
    private notificationService: NotificationService
  ) {}

  ngOnInit(): void {
    this.id = this.routeActivated.snapshot.params['id'];

    if (this.id === undefined) {
      this.joinAsMentorFormState = this.initForm();
    } else {
      this.registrationService.getMentorById(this.id).subscribe(
        (data) => {
          this.joinAsMentorFormState = data;

          this.joinAsMentorForm.patchValue({
            userRole: data.userRole,
            userName: data.email.split('@')[0],
            email: data.email,
            password: data.password,
            confirmPassword: data.confirmPassword,
            domain: data.domain,
            userCreationDate: moment(data.userCreationDate),
            profileImagePath: data.profileImagePath,
          });
        },
        (err) => {
          this.router.navigate(['home']);
          this.notificationService.showError(err.message, 'Error');
        }
      );
    }
    this.joinAsMentorFormState = this.initForm();

    this.joinAsMentorForm = new FormGroup(
      {
        userRole: new FormControl(this.joinAsMentorFormState.userRole, []),
        userName: new FormControl(
          this.joinAsMentorFormState.email.split('@')[0],
          []
        ),
        email: new FormControl(this.joinAsMentorFormState.email, [
          Validators.required,
          Validators.email,
        ]),
        password: new FormControl(this.joinAsMentorFormState.password, [
          Validators.required,
        ]),
        confirmPassword: new FormControl(
          this.joinAsMentorFormState.confirmPassword,
          [Validators.required]
        ),
        domain: new FormControl(this.joinAsMentorFormState.domain, [
          Validators.required,
        ]),
        userCreationDate: new FormControl(
          this.joinAsMentorFormState.userCreationDate,
          []
        ),
        profileImagePath: new FormControl(
          this.joinAsMentorFormState.profileImagePath
        ),
      },
      { validators: this.checkPasswords }
    );
    this.filteredOptions = this.domain.valueChanges.pipe(
      startWith(''),
      map((value) => this._filter(value))
    );
  }

  joinAsMentorSubmit() {
    let mentor = <ICreateMentee>this.joinAsMentorForm.value;

    let formData = this.createFormData(mentor);
    if (this.id === undefined) {
      this.registrationService.createMentor(formData).subscribe(
        () => {
          this.notificationService.showSuccess('Success', 'Mentor Added');
          this.router.navigate(['register/mentor/volunteer-type']);
        },
        (error: HttpErrorResponse) => {
          this.notificationService.showError(error.message, 'Error');
        }
      );
    }
  }

  createFormData(mentor: ICreateMentee): FormData {
    let formData = new FormData();
    let clone = Object.assign({}, mentor);

    for (var key in clone) {
      if (key === 'userName'){
        formData.append(key, mentor['email'].split('@')[0]);
        console.log(mentor['email'].split('@')[0]);
      }
      else {
        formData.append(key, mentor[key]);
      }
    }

    return formData;
  }

  initForm(): IMentee {
    return {
      id: '',
      userRole: 0,
      userName: '',
      email: '',
      password: '',
      confirmPassword: '',
      domain: '',
      profileImagePath: this.url,
      userCreationDate: moment()
        .format('YYYY-MM-DD[T]HH:mm'),
    };
  }

  get userRole() {
    return this.joinAsMentorForm.get('userRole');
  }
  get userName() {
    return this.joinAsMentorForm.get('userName');
  }
  get email() {
    return this.joinAsMentorForm.get('email');
  }
  get password() {
    return this.joinAsMentorForm.get('password');
  }
  get confirmPassword() {
    return this.joinAsMentorForm.get('confirmPassword');
  }
  get domain() {
    return this.joinAsMentorForm.get('domain');
  }
  get profileImagePath() {
    return this.joinAsMentorForm.get('profileImagePath');
  }
  get userCreationDate() {
    return this.joinAsMentorForm.get('userCreationDate');
  }

  url: string;
  onSelectImage(event) {
    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();

      reader.readAsDataURL(event.target.files[0]);

      reader.onload = (event) => {
        this.url = event.target.result as string;
      };
      this.joinAsMentorFormState.profileImagePath = this.url;
    }
  }

  checkPasswords(group: FormGroup) {
    const password = group.get('password').value;
    const confirmPassword = group.get('confirmPassword').value;

    return password === confirmPassword ? null : { notSame: true };
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.options.filter((option) =>
      option.toLowerCase().includes(filterValue)
    );
  }
}
