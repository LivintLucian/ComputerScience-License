import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MentorFilterComponent } from './mentor-filter.component';

describe('MentorFilterComponent', () => {
  let component: MentorFilterComponent;
  let fixture: ComponentFixture<MentorFilterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MentorFilterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MentorFilterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
