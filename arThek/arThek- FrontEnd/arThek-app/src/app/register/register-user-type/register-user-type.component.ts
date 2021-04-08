import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RegistrationSystemService } from 'src/app/core/services/registration-system.service';

@Component({
  selector: 'app-register-user-type',
  templateUrl: './register-user-type.component.html',
  styleUrls: ['./register-user-type.component.scss'],
})
export class RegisterUserTypeComponent implements OnInit {
  constructor(
    private router: Router,
    private registrationService: RegistrationSystemService
  ) {}

  ngOnInit(): void {}

  joinAsUser() {
    this.router.navigate(['register/join-as-user']);
  }

  joinAsMentor() {
    this.router.navigate(['register/join-as-mentor']);
  }
}
