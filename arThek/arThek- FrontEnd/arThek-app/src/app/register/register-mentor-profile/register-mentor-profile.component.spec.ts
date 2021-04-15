import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterMentorProfileComponent } from './register-mentor-profile.component';

describe('RegisterMentorProfileComponent', () => {
  let component: RegisterMentorProfileComponent;
  let fixture: ComponentFixture<RegisterMentorProfileComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterMentorProfileComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterMentorProfileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
