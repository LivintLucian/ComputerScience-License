import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterJoinAsMentorComponent } from './register-join-as-mentor.component';

describe('RegisterJoinAsMentorComponent', () => {
  let component: RegisterJoinAsMentorComponent;
  let fixture: ComponentFixture<RegisterJoinAsMentorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterJoinAsMentorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterJoinAsMentorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
