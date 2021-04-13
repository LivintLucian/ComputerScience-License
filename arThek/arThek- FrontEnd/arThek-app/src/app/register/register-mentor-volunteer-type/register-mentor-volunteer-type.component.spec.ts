import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterMentorVolunteerTypeComponent } from './register-mentor-volunteer-type.component';

describe('RegisterMentorVolunteerTypeComponent', () => {
  let component: RegisterMentorVolunteerTypeComponent;
  let fixture: ComponentFixture<RegisterMentorVolunteerTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterMentorVolunteerTypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterMentorVolunteerTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
