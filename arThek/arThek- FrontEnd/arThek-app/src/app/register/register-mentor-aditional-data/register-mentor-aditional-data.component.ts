import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NotificationService } from 'src/app/core/services/notification.service';
import { RegistrationSystemService } from 'src/app/core/services/registration-system.service';
import { IMentor, IMentorAdditionalData } from '../models/createMentor';

@Component({
  selector: 'app-register-mentor-aditional-data',
  templateUrl: './register-mentor-aditional-data.component.html',
  styleUrls: ['./register-mentor-aditional-data.component.scss'],
})
export class RegisterMentorAditionalDataComponent {
  resumeSelected: File;
  linkdlnUrl = new FormControl('', []);
  dribbleUrl = new FormControl('', []);
  behanceUrl = new FormControl('', []);
  carbonMadeUrl = new FormControl('', []);
  resume = new FormControl('', []);

  joinAsMentorForm = new FormGroup({
    linkdlnUrl: this.linkdlnUrl,
    dribbleUrl: this.dribbleUrl,
    behanceUrl: this.behanceUrl,
    carbonMadeUrl: this.carbonMadeUrl,
    resume: this.resume,
  });

  constructor(
    private router: Router,
    private registrationService: RegistrationSystemService,
    private routeActivated: ActivatedRoute,
    private notificationService: NotificationService
  ) {}

  selectFile(ev) {
    this.resumeSelected = <File>ev.target.files[0];

    if (!this.resumeSelected.name.endsWith('.pdf')) {
      this.joinAsMentorForm.setErrors({ format: true });
    } else {
      this.joinAsMentorForm.updateValueAndValidity();
    }
  }

  joinAsMentorSubmit() {
    let mentor = <IMentorAdditionalData>this.joinAsMentorForm.value;

    mentor.resume = this.resumeSelected;

    let formData = this.createFormData(mentor);
    this.registrationService.mentorAdditionalData(formData).subscribe((u) => {
      this.router.navigate(['register/mentor/profile-preview']);
    });
  }

  createFormData(mentor: IMentorAdditionalData): FormData {
    let formData = new FormData();
    let clone = Object.assign({}, mentor);

    for (var key in clone) {
      formData.append(key, mentor[key]);
    }

    return formData;
  }
}
