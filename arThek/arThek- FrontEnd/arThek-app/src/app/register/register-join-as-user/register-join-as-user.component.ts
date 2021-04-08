import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { RegistrationSystemService } from 'src/app/core/services/registration-system.service';
import { ICreateMentee, IMentee } from '../models/createMentee';
import * as moment from 'moment';
import { NotificationService } from 'src/app/core/services/notification.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-register-join-as-user',
  templateUrl: './register-join-as-user.component.html',
  styleUrls: ['./register-join-as-user.component.scss'],
})
export class RegisterJoinAsUserComponent implements OnInit {
  id: string;
  joinAsUserFormState: IMentee;
  joinAsUserForm: FormGroup;

  constructor(
    private router: Router,
    private registrationService: RegistrationSystemService,
    private routeActivated: ActivatedRoute,
    private notificationService: NotificationService
  ) {}

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
            userName: data.userName,
            email: data.email,
            password: data.password,
            confirmPassword: data.confirmPassword,
            domain: data.domain,
            chatMessageId: data.chatMessageId,
            userCreationDate: moment(data.userCreationDate),
            profileImagePath: data.profileImagePath
          });
        },
        (err) => {
          this.router.navigate(['home']);
          this.notificationService.showError(err.message, 'Error');
        }
      );
    }
    this.joinAsUserFormState = this.initForm();

    this.joinAsUserForm = new FormGroup({
      userRole: new FormControl(this.joinAsUserFormState.userRole,[]),
      userName: new FormControl(this.joinAsUserFormState.userName,[]),
      email: new FormControl(this.joinAsUserFormState.email,
        [
          Validators.required,
          Validators.email
        ]),
      password: new FormControl(this.joinAsUserFormState.password,
        [
          Validators.required
        ]),
      confirmPassword: new FormControl(this.joinAsUserFormState.confirmPassword,
        [
          Validators.required,
        ]),
      domain: new FormControl(this.joinAsUserFormState.domain,
        [
          Validators.required,
        ]),
      chatMessageId: new FormControl(this.joinAsUserFormState.chatMessageId,[]),
      userCreationDate: new FormControl(this.joinAsUserFormState.userCreationDate,[]),
      profileImagePath: new FormControl(this.joinAsUserFormState.profileImagePath)
    })
  }

  joinAsUserSubmit() {
    let mentee = <ICreateMentee>this.joinAsUserForm.value;

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
      formData.append(key, mentee[key]);
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
      chatMessageId: '',
      userCreationDate: moment()
        .hour(8)
        .minute(0)
        .second(0)
        .format('YYYY-MM-DD[T]HH:mm'),
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

  url: string;
  onSelectImage(event) {
    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();

      reader.readAsDataURL(event.target.files[0]); // read file as data url

      reader.onload = (event) => { // called once readAsDataURL is completed
        this.url = event.target.result as string;
      }
      this.joinAsUserFormState.profileImagePath = this.url;
    }
  }
}
