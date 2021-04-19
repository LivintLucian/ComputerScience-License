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
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-register-join-as-user',
  templateUrl: './register-join-as-user.component.html',
  styleUrls: ['./register-join-as-user.component.scss'],
})
export class RegisterJoinAsUserComponent implements OnInit {
  id: string;
  joinAsUserFormState: IMentee;
  joinAsUserForm: FormGroup;
  matcher = new MyErrorStateMatcher();
  options: string[] = [
    'Logo Designer',
    'Graphic Designer',
    'Ui/Ux',
    'Web Designer',
    'Animation Designer',
  ];
  filteredOptions: Observable<string[]>;
  profileImage: File;
  reader = new FileReader();
  url: SafeUrl;

  constructor(
    private router: Router,
    private registrationService: RegistrationSystemService,
    private routeActivated: ActivatedRoute,
    private notificationService: NotificationService,
    private domSanitizer: DomSanitizer
  ) {}

  selectFile(ev) {
    this.profileImage = <File>ev.target.files[0];
    const preview = document.querySelector('img');
    const file = (<HTMLInputElement>document.querySelector('input[type=file]')).files[0];
    const reader = new FileReader();

    this.reader.onload = (ev) => this.url = this.domSanitizer.bypassSecurityTrustUrl(ev.target.result as string);
    this.reader.readAsDataURL(new Blob([this.joinAsUserFormState.profileImagePath]));
    reader.addEventListener("load", function(){
      preview.src = reader.result as string;
    }, false)

    if(file){
      reader.readAsDataURL(file);
    }
  }

  ngOnInit(): void {
    this.id = this.routeActivated.snapshot.params['id'];

    if (this.id === undefined) {
      this.joinAsUserFormState = this.initForm();
    } else {
      this.registrationService.getMenteeById(this.id).subscribe(
        (data) => {
          this.joinAsUserFormState = data;

          this.joinAsUserForm.patchValue({
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
    this.joinAsUserFormState = this.initForm();

    this.joinAsUserForm = new FormGroup(
      {
        userRole: new FormControl(this.joinAsUserFormState.userRole, []),
        userName: new FormControl(
          this.joinAsUserFormState.email.split('@')[0],
          []
        ),
        email: new FormControl(this.joinAsUserFormState.email, [
          Validators.required,
          Validators.email,
        ]),
        password: new FormControl(this.joinAsUserFormState.password, [
          Validators.required,
        ]),
        confirmPassword: new FormControl(
          this.joinAsUserFormState.confirmPassword,
          [Validators.required]
        ),
        domain: new FormControl(this.joinAsUserFormState.domain, [
          Validators.required,
        ]),
        userCreationDate: new FormControl(
          this.joinAsUserFormState.userCreationDate,
          []
        ),
        profileImagePath: new FormControl(
          ''
        ),
      },
      { validators: this.checkPasswords }
    );
    this.filteredOptions = this.domain.valueChanges.pipe(
      startWith(''),
      map((value) => this._filter(value))
    );
  }

  joinAsUserSubmit() {
    let mentee = <ICreateMentee>this.joinAsUserForm.value;

    mentee.profileImagePath = this.profileImage;

    let formData = this.createFormData(mentee);
    if (this.id === undefined) {
      this.registrationService.createMentee(formData).subscribe(
        () => {
          this.notificationService.showSuccess('Success', 'Mentee Added');
          this.router.navigate(['']);
        },
        (error: HttpErrorResponse) => {
          this.notificationService.showError(error.message, 'Error');
        }
      );
    }
  }

  createFormData(mentee: ICreateMentee): FormData {
    let formData = new FormData();
    let clone = Object.assign({}, mentee);

    for (var key in clone) {
      if (key === 'userName') {
        formData.append(key, mentee['email'].split('@')[0]);
        console.log(mentee['email'].split('@')[0]);
      } else {
        formData.append(key, mentee[key]);
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
      profileImagePath: undefined,
      userCreationDate: moment().format('YYYY-MM-DD[T]HH:mm'),
    };
  }

  get userRole() {
    return this.joinAsUserForm.get('userRole');
  }
  get userName() {
    return this.joinAsUserForm.get('userName');
  }
  get email() {
    return this.joinAsUserForm.get('email');
  }
  get password() {
    return this.joinAsUserForm.get('password');
  }
  get confirmPassword() {
    return this.joinAsUserForm.get('confirmPassword');
  }
  get domain() {
    return this.joinAsUserForm.get('domain');
  }
  get profileImagePath() {
    return this.joinAsUserForm.get('profileImagePath');
  }
  get chatMessageId() {
    return this.joinAsUserForm.get('chatMessageId');
  }
  get userCreationDate() {
    return this.joinAsUserForm.get('userCreationDate');
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
