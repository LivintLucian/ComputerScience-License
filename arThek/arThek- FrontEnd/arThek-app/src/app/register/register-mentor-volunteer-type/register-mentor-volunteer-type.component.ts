import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RegistrationSystemService } from 'src/app/core/services/registration-system.service';

@Component({
  selector: 'app-register-mentor-volunteer-type',
  templateUrl: './register-mentor-volunteer-type.component.html',
  styleUrls: ['./register-mentor-volunteer-type.component.scss'],
})
export class RegisterMentorVolunteerTypeComponent implements OnInit {
  constructor(
    private router: Router,
    private registrationService: RegistrationSystemService
  ) {}

  ngOnInit(): void {}

  volunteer() 
  {
    this.registrationService.isMentorVolunteer(true).subscribe(
      (u) =>{
        this.router.navigate(['register/mentor/aditional-data']);
      }
    )
  }
  unVolunteer(){
    this.registrationService.isMentorVolunteer(false).subscribe(
      (u) =>{
        this.router.navigate(['register/mentor/aditional-data']);
      }
    )
  }
}
