import { HttpErrorResponse } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DomSanitizer } from '@angular/platform-browser';
import { SafeUrl } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import moment from 'moment';
import { AuthenticationService } from 'src/app/core/services/authentication.service';
import { NotificationService } from 'src/app/core/services/notification.service';
import { RegistrationSystemService } from 'src/app/core/services/registration-system.service';
import { ICreateArticle, INews } from '../models/news';
import { LiveStreamingService } from '../services/live-streaming.service';
import { NewsService } from '../services/news.service';

@Component({
  selector: 'app-news-publish-article',
  templateUrl: './news-publish-article.component.html',
  styleUrls: ['./news-publish-article.component.scss'],
})
export class NewsPublishArticleComponent implements OnInit {
  @Input() isFilterOpen = true;
  @Output() filterClose: EventEmitter<boolean> = new EventEmitter<boolean>();
  publishArticleFormState: INews;
  publishArticleForm: FormGroup;
  articleImage: File;
  reader = new FileReader();
  url: SafeUrl;

  constructor(
    private router: Router,
    private routeActivated: ActivatedRoute,
    private notificationService: NotificationService,
    private authService: AuthenticationService,
    private domSanitizer: DomSanitizer,
    private articleService: NewsService
  ) {
  }

  selectFile(ev) {
    this.articleImage = <File>ev.target.files[0];
    const preview = <HTMLInputElement>(
      document.getElementById('publish-article--image')
    );
    const file = (<HTMLInputElement>document.querySelector('input[type=file]'))
      .files[0];
    const reader = new FileReader();

    this.reader.onload = (ev) =>
      (this.url = this.domSanitizer.bypassSecurityTrustUrl(
        ev.target.result as string
      ));
    this.reader.readAsDataURL(new Blob([this.publishArticleFormState.image]));
    reader.addEventListener(
      'load',
      function () {
        preview.src = reader.result as string;
      },
      false
    );

    if (file) {
      reader.readAsDataURL(file);
    }
  }

  ngOnInit(): void {
    this.publishArticleFormState = this.initForm();
    let user = this.authService.getUserFromLocalStorage();

    this.publishArticleForm = new FormGroup({
      image: new FormControl(''),
      title: new FormControl(this.publishArticleFormState.title, [
        Validators.required,
        Validators.maxLength(24),
      ]),
      content: new FormControl(this.publishArticleFormState.content),
      category: new FormControl(user.category),
      publishDate: new FormControl(this.publishArticleFormState.publishDate),
      authorId: new FormControl(user.id),
      authorName: new FormControl(user.emailAddress.split('@')[0]),
    });
  }

  publishArticleSubmit() {
    let article = <ICreateArticle>this.publishArticleForm.value;

    article.image = this.articleImage;

    let formData = this.createFormData(article);
    this.articleService.publishArticle(formData).subscribe(
      () => {
        this.notificationService.showSuccess(
          'Success',
          'Article was published'
        );
      },
      (error: HttpErrorResponse) => {
        this.notificationService.showError(error.message, 'Error');
      }
    );
    this.closeFilter();
  }

  createFormData(article: ICreateArticle): FormData {
    let formData = new FormData();
    let clone = Object.assign({}, article);

    for (var key in clone) {
      formData.append(key, article[key]);
    }

    return formData;
  }

  initForm(): INews {
    return {
      id: '',
      image: null,
      title: '',
      content: '',
      category: '',
      publishDate: moment().format('YYYY-MM-DD[T]HH:mm'),
      authorId: '',
      authorName: '',
    };
  }

  closeFilter() {
    this.filterClose.emit(!this.isFilterOpen);
  }

  get image() {
    return this.publishArticleForm.get('image');
  }
  get title() {
    return this.publishArticleForm.get('title');
  }
  get content() {
    return this.publishArticleForm.get('content');
  }
  get category() {
    return this.publishArticleForm.get('category');
  }
  get publishDate() {
    return this.publishArticleForm.get('publishDate');
  }
  get authorId() {
    return this.publishArticleForm.get('authorId');
  }
}
