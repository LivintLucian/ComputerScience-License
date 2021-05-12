import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ICreateArticle, INews } from '../models/news';

@Injectable({
  providedIn: 'root',
})
export class NewsService {
  constructor(private http: HttpClient) {}

  getAllNews(): Observable<INews> {
    return this.http.get<INews>(
      `${environment.baseAPI}/news`
    );
  }

  getArticleById(id: string): Observable<INews> {
    return this.http.get<INews>(
      `${environment.baseAPI}/news/${id}`
    );
  }

  publishArticle(article: FormData) {
    return this.http.post(
      `${environment.baseAPI}/news/publish-article`, article 
    );
  }
}
