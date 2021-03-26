import { ToastrModule } from 'ngx-toastr';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { SkipSelf, NgModule, Optional } from '@angular/core';
import { NotificationService } from './services/notification.service';
import { AuthenticationService } from './services/authentication.service';
import { LocalStorageService } from './services/local-storage.service';

@NgModule({
  providers: [ NotificationService, AuthenticationService, LocalStorageService ],
  declarations: [],
  imports: [
    ToastrModule.forRoot({
      positionClass: 'toast-top-right',
      progressBar: true,
      closeButton: true,
      onActivateTick: true,
      enableHtml: true,
      timeOut: 2000
    }),
    HttpClientModule,
    RouterModule
  ]
})
export class CoreModule { 
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    if (parentModule) {
      throw new Error(
        'CoreModule is already loaded. Import it in the AppModule only'
      );
    }
  }
}
