import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegisterRoutingModule } from './register-routing.module';
import { RegisterUserTypeComponent } from './register-user-type/register-user-type.component';


@NgModule({
  declarations: [RegisterUserTypeComponent],
  imports: [
    CommonModule,
    RegisterRoutingModule
  ],
  exports:[
    RegisterUserTypeComponent
  ]
})
export class RegisterModule { }
