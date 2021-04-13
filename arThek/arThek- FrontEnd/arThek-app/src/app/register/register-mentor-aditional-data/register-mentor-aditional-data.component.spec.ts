import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterMentorAditionalDataComponent } from './register-mentor-aditional-data.component';

describe('RegisterMentorAditionalDataComponent', () => {
  let component: RegisterMentorAditionalDataComponent;
  let fixture: ComponentFixture<RegisterMentorAditionalDataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterMentorAditionalDataComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterMentorAditionalDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
