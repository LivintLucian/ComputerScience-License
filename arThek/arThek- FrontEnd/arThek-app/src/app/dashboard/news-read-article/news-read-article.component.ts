import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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

  constructor(private news: NewsService, private route: ActivatedRoute) {}

  ngOnInit(): void {
  }

  closeFilter() {
    this.filterClose.emit(!this.isFilterOpen);
  }
}
