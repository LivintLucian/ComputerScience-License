import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/core/models/User';
import { AuthenticationService } from 'src/app/core/services/authentication.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  user: User;
  userName: string;
  constructor(
    private authService: AuthenticationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.user = this.authService.getUserFromLocalStorage();
    this.userName = this.user.emailAddress.split('@')[0].toLowerCase();
  }
  navigateToNews(){
    this.router.navigate(['dashboard']);
  }
  navigateToMentors(){
    this.router.navigate(['dashboard/mentors']);
  }
  logout() {
    this.authService.removeUserFromLocalStorage();
    this.router.navigate(['home']);
  }
  navigateToLiveChat(){
    this.router.navigate(['dashboard/public-chat']);
  }
  navigateToLiveStreaming(){
    this.router.navigate(['dashboard/live-streaming']);
  }
}
