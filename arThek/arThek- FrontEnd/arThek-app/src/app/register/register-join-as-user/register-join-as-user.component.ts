import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegistrationSystemService } from 'src/app/core/services/registration-system.service';

@Component({
  selector: 'app-register-join-as-user',
  templateUrl: './register-join-as-user.component.html',
  styleUrls: ['./register-join-as-user.component.scss'],
})
export class RegisterJoinAsUserComponent {
  email = new FormControl('', [Validators.required, Validators.email]);
  password = new FormControl('', [Validators.required]);
  confirmPassword = new FormControl('', [Validators.required]);
  domain = new FormControl('');

  joinAsUserForm = new FormGroup({
    email: this.email,
    password: this.password,
    confirmPassword: this.confirmPassword,
    domain: this.domain,
  });

  constructor(
    private route: Router,
    private registrationService: RegistrationSystemService
  ) {}

  joinAsUserSubmit() {}
}
