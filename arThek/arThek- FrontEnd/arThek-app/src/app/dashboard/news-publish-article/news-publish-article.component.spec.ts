import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewsPublishArticleComponent } from './news-publish-article.component';

describe('NewsPublishArticleComponent', () => {
  let component: NewsPublishArticleComponent;
  let fixture: ComponentFixture<NewsPublishArticleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewsPublishArticleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewsPublishArticleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
