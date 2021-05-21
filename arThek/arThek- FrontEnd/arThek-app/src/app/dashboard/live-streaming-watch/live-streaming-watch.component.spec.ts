import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LiveStreamingWatchComponent } from './live-streaming-watch.component';

describe('LiveStreamingWatchComponent', () => {
  let component: LiveStreamingWatchComponent;
  let fixture: ComponentFixture<LiveStreamingWatchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LiveStreamingWatchComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LiveStreamingWatchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
