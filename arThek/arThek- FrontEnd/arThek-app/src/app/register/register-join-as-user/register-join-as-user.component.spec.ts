import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RegisterJoinAsUserComponent } from './register-join-as-user.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

describe('RegisterJoinAsUserComponent', () => {
  let component: RegisterJoinAsUserComponent;
  let fixture: ComponentFixture<RegisterJoinAsUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormsModule, ReactiveFormsModule],
      declarations: [RegisterJoinAsUserComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterJoinAsUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
