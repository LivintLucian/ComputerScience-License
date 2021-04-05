import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { NotificationService } from 'src/app/core/services/notification.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  email = new FormControl('', [Validators.required, Validators.email]);
  password = new FormControl('', [Validators.required]);

  loginForm = new FormGroup({
    email: this.email,
    password: this.password,
  });

  constructor(
    private router: Router,
    private notifications: NotificationService,
    private authService: AuthenticationService
  ) {}

  onSubmit() {
    this.authService.login(this.email.value, this.password.value).subscribe(
      (u) => {
        this.router.navigate(['home']);
      },
      (e) => {
        if (e.status === 404) {
          this.notifications.showError(
            'This user does not exist!',
            'Login Error',
            5000
          );
        } else {
          this.notifications.showError(
            'This user does not exist!',
            'Login Error',
            5000
          );
        }
      }
    );
  }
}
