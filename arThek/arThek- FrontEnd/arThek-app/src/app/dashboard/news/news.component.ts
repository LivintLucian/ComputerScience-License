import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { INews } from '../models/news';
import { NewsService } from '../services/news.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.scss'],
})
export class NewsComponent implements OnInit {
  isPublishArticleToggled = false;
  isReadArticleToggled = false;
  isUserTypeMentor = true;
  articles: INews;
  articleImage: Uint8Array;
  articleTitle: string;
  content: string;

  constructor(
    private news: NewsService,
    private authService: AuthenticationService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.news.getAllNews().subscribe((articlesAvaible) => {
      this.articles = articlesAvaible;
      console.log(this.articles);
    });

    let user = this.authService.getUserFromLocalStorage();
    console.log(user);
    if (user.userType == '0') this.isUserTypeMentor = false;
  }

  filterClose(event) {
    this.isPublishArticleToggled = event;
    this.isReadArticleToggled = event;
  }

  startPublishArticle() {
    this.isPublishArticleToggled = true;
  }

  readArticle(articleId) {
    this.isReadArticleToggled = true;
    this.news.getArticleById(articleId).subscribe((article) => {
      this.articleImage = article.image;
      this.articleTitle = article.title;
      this.content = article.content;
    });
    // this.router.navigate(['dashboard/read-article/', articleId]);
  }
}
