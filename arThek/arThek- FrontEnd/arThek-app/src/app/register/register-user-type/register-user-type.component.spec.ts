import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterUserTypeComponent } from './register-user-type.component';

describe('RegisterUserTypeComponent', () => {
  let component: RegisterUserTypeComponent;
  let fixture: ComponentFixture<RegisterUserTypeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterUserTypeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterUserTypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
