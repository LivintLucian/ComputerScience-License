import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { RegistrationSystemService } from 'src/app/core/services/registration-system.service';
import { NotificationService } from 'src/app/core/services/notification.service';
import { IMentorProfile } from 'src/app/register/models/createMentor';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { AuthenticationService } from 'src/app/core/services/authentication.service';

@Component({
  selector: 'app-register-mentor-profile',
  templateUrl: './register-mentor-profile.component.html',
  styleUrls: ['./register-mentor-profile.component.scss'],
})
export class RegisterMentorProfileComponent implements OnInit {
  id: any;
  joinAsMentorFormState: IMentorProfile;
  joinAsMentorForm: FormGroup;
  reader = new FileReader();

  constructor(
    private router: Router,
    private registrationService: RegistrationSystemService,
    private notificationService: NotificationService,
    private domSanitizer: DomSanitizer,
    private authService: AuthenticationService
  ) {}

  ngOnInit(): void {
    this.registrationService.getLastMentor().subscribe(
      (data) => {
        console.log(data.profileImagePath);
        this.joinAsMentorFormState = data;

        this.joinAsMentorForm.patchValue({
          profileImagePath: data.profileImagePath,
          userName: data.userName,
          domain: data.domain,
          behanceUrl: data.behanceUrl,
          carbonMadeUrl: data.carbonMadeUrl,
          dribbleUrl: data.dribbleUrl,
          aboutMe: data.aboutMe,
          basicPackage: data.basicPackage,
          standardPackage: data.standardPackage,
          premiumPackage: data.premiumPackage,
        });

      },
      (err) => {
        this.router.navigate(['home']);
        this.notificationService.showError(err.message, 'Error');
      }
    );

    this.joinAsMentorForm = new FormGroup({
      profileImagePath: new FormControl(''),
      userName: new FormControl('', []),
      domain: new FormControl('', []),
      behanceUrl: new FormControl('', []),
      carbonMadeUrl: new FormControl('', []),
      dribbleUrl: new FormControl('', []),
      aboutMe: new FormControl('', []),
      basicPackage: new FormControl('', []),
      standardPackage: new FormControl('', []),
      premiumPackage: new FormControl('', []),
    });
  }

  joinAsMentorSubmit() {
    let mentor = <IMentorProfile>this.joinAsMentorForm.value;

    let formData = this.createFormData(mentor);
    this.registrationService.mentorProfile(formData).subscribe((u) => {
      this.router.navigate(['home']);
    });
  }

  createFormData(mentor: IMentorProfile): FormData {
    let formData = new FormData();
    let clone = Object.assign({}, mentor);

    for (var key in clone) {
      formData.append(key, mentor[key]);
    }

    return formData;
  }

  get profileImagePath() {
    return this.joinAsMentorForm.get('profileImagePath');
  }
  get userName() {
    return this.joinAsMentorForm.get('userName');
  }
  get behanceUrl() {
    return this.joinAsMentorForm.get('behanceUrl');
  }
  get carbonMadeUrl() {
    return this.joinAsMentorForm.get('carbonMadeUrl');
  }
  get dribbleUrl() {
    return this.joinAsMentorForm.get('dribbleUrl');
  }
  get domain() {
    return this.joinAsMentorForm.get('domain');
  }
  get aboutMe() {
    return this.joinAsMentorForm.get('aboutMe');
  }
  get basicPackage() {
    return this.joinAsMentorForm.get('basicPackage');
  }
  get standardPackage() {
    return this.joinAsMentorForm.get('standardPackage');
  }
  get premiumPackage() {
    return this.joinAsMentorForm.get('premiumPackage');
  }
}
