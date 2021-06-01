import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { LocalStorageService } from 'src/app/core/services/local-storage.service';
import { NewsService } from '../services/news.service';

@Component({
  selector: 'app-news-read-article',
  templateUrl: './news-read-article.component.html',
  styleUrls: ['./news-read-article.component.scss'],
})
export class NewsReadArticleComponent implements OnInit {
  id: string;
  @Input() isFilterOpen = true;
  @Input() image: Uint8Array;
  @Input() title: string;
  @Input() content: string;
  @Output() filterClose: EventEmitter<boolean> = new EventEmitter<boolean>();
  rating = new FormControl(null);

  constructor(
    private news: NewsService,
    private route: ActivatedRoute,
    private localStorageService: LocalStorageService
  ) {}

  ngOnInit(): void {
    console.log(this.localStorageService.get('articleId'));
  }

  closeFilter() {
    this.filterClose.emit(!this.isFilterOpen);
  }

  articleRating() {
    console.log(this.rating.value);
    console.log(this.localStorageService.get('articleId'));
    this.news
      .updateArticleRating(
        this.rating.value,
        this.localStorageService.get('articleId')
      )
      .subscribe((data) => {
        console.log(data);
      });
  }
}
