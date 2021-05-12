import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewsReadArticleComponent } from './news-read-article.component';

describe('NewsReadArticleComponent', () => {
  let component: NewsReadArticleComponent;
  let fixture: ComponentFixture<NewsReadArticleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewsReadArticleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewsReadArticleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
