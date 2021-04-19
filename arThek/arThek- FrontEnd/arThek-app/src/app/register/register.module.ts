import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RegisterRoutingModule } from './register-routing.module';
import { RegisterUserTypeComponent } from './register-user-type/register-user-type.component';
import { RegisterJoinAsUserComponent } from './register-join-as-user/register-join-as-user.component';
import { RegisterJoinAsMentorComponent } from './register-join-as-mentor/register-join-as-mentor.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select'
import { MatFormFieldModule } from '@angular/material/form-field';
import { RegisterMentorVolunteerTypeComponent } from './register-mentor-volunteer-type/register-mentor-volunteer-type.component';
import { RegisterMentorAditionalDataComponent } from './register-mentor-aditional-data/register-mentor-aditional-data.component';
import { RegisterMentorProfileComponent } from './register-mentor-profile/register-mentor-profile.component';

@NgModule({
  declarations: [
    RegisterUserTypeComponent,
    RegisterJoinAsUserComponent,
    RegisterJoinAsMentorComponent,
    RegisterMentorVolunteerTypeComponent,
    RegisterMentorAditionalDataComponent,
    RegisterMentorProfileComponent,
  ],
  imports: [
    CommonModule,
    RegisterRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatAutocompleteModule,
    MatSelectModule,
    MatInputModule,
    MatFormFieldModule,
  ],
  exports: [
    RegisterUserTypeComponent,
    RegisterJoinAsUserComponent,
    RegisterJoinAsMentorComponent,
  ],
})
export class RegisterModule {}
