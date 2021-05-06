import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { RegistrationSystemService } from 'src/app/core/services/registration-system.service';
import { NotificationService } from 'src/app/core/services/notification.service';
import { IMentor, IMentorProfile } from 'src/app/register/models/createMentor';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { FilterMentorService } from '../services/filter-mentors.service';
import { saveAs } from 'file-saver'

@Component({
  selector: 'app-mentor-profile',
  templateUrl: './mentor-profile.component.html',
  styleUrls: ['./mentor-profile.component.scss'],
})
export class MentorProfileComponent implements OnInit {
  id: any;
  joinAsMentorFormState: IMentor;
  joinAsMentorForm: FormGroup;
  reader = new FileReader();
  resumeUrl;

  constructor(
    private router: Router,
    private registrationService: RegistrationSystemService,
    private notificationService: NotificationService,
    private domSanitizer: DomSanitizer,
    private route: ActivatedRoute,
    private filterMentorsService: FilterMentorService
  ) {}

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.registrationService.getMentorById(this.id).subscribe(
      (data) => {
        console.log(data);
        this.joinAsMentorFormState = data;

        this.joinAsMentorForm.patchValue({
          profileImagePath: data?.profileImagePath,
          userName: data.userName,
          domain: data.domain,
          behanceUrl: this.domSanitizer.bypassSecurityTrustUrl(
            data?.behanceUrl
          ),
          carbonMadeUrl: this.domSanitizer.bypassSecurityTrustUrl(
            data?.carbonMadeUrl
          ),
          dribbleUrl: this.domSanitizer.bypassSecurityTrustUrl(
            data?.dribbleUrl
          ),
          linkdlnUrl: this.domSanitizer.bypassSecurityTrustUrl(
            data?.linkdlnUrl
          ),
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
  }
  base64ToArrayBuffer(base64:any):ArrayBuffer {
    var binary_string = window.atob(base64);
    var len = binary_string.length;
    var bytes = new Uint8Array(len);
    for (var i = 0; i < len; i++) {
      bytes[i] = binary_string.charCodeAt(i);
    }
    return bytes.buffer;
  }

  downloadPdf(){
    const blob = new Blob([this.base64ToArrayBuffer(this.joinAsMentorFormState.resume)], {type: "application/octet-stream" });
    const pdfName = this.joinAsMentorFormState.resumeFileName;
    saveAs(blob, pdfName, true);
  }
}

