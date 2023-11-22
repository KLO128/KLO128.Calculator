import { Directive, Injectable } from "@angular/core";
import { environment } from "../environments/environment";
import { CookieService } from "./cookie-service";
import { IDataJson } from "./data-json";
import * as translations from '../assets/translations.json';
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Observable, catchError, firstValueFrom, tap } from "rxjs";
import { HomeViewState } from "./home-view-state";

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  allLangs = ['en-US', 'cs-CZ'];
  currentLang = 'en-US';
  translations: any | undefined;
  homeViewState: HomeViewState = { expression: undefined, historyResults: [], result: undefined, resultAsInteger: false, useSeparators: false, loading: true };

  constructor(private http: HttpClient, private cookieService: CookieService) {

  }

  stringFormat(str: string, args: any[]): string {
    return str.replace(/{(\d+)}/g, function (match, number) {
      return typeof args[number] != 'undefined'
        ? args[number]
        : match
        ;
    });
  }

  formatErrorMessage(errCode: string, errArgs: string | any[]): string {
    return this.stringFormat(this.getTranslation(errCode), typeof errArgs === "string" ? JSON.parse(errArgs) : errArgs)
  }

  setCookie (name: string, value: any): void {
    if (value != null && value != '') {
      this.cookieService.setCookie(name, value, 10, '/');
    }
  }

  setCurrentLang(): void {
    for (var lang of this.allLangs) {
      if (window.location.pathname.includes(lang)) {
        this.currentLang = lang;
        return;
      }
    }

    this.currentLang = 'en-US';
  }

  getTranslation(term: string): string {
    if (this.translations === undefined) {
      var ret = term;
      setTimeout(() => ret = this._getTranslation(term), 500);

      return ret;
    } else {
      return this._getTranslation(term);
    }
  }

  _getTranslation(term: string): string {
    var texts = this.translations[this.currentLang];

    if (texts == null) {
      texts = this.translations['en-US']!;

      if (texts == null) {
        return term;
      }
    }

    return (texts[term] as string) || term;
  }

  getCurrentFullPath(): string {
    return window.location.pathname;
  }

  getCurrentLocalPath(): string {
    return this.getLocalPath(this.getCurrentFullPath());
  }

  getLocalPath(path: string): string {
    for (var lang of this.allLangs) {
      path = path.replace(lang, '');
    }

    return path.replace("//", "/");
  }

  getFullPath(lang: string, path?: string): string {
    if (lang == 'en-US' && (path === '/' || path === '')) {
      return '';
    }

    path = this.getLocalPath(path || this.getCurrentLocalPath());

    return lang + (!path?.startsWith('/') ? '/' : '') + path;
  }

  async initTranslations(): Promise<any> {
    this.translations = translations;
    //var that = this;
    //this.fetch("translations.json", 'GET', undefined, function (json: any) {
    //  that.translations = json;
    //});
  }

  async apiFetch(relativeUrl: string, method: string, dataJson: IDataJson | undefined): Promise<Observable<any>> {
    return await this.fetch(environment.apiEndpoint + relativeUrl, method, dataJson);
  }

  async fetch(url: string, method: string, dataJson: IDataJson | undefined): Promise<Observable<any>> {
    var headers: Record<string, string> | undefined;

    if (dataJson == null || dataJson.headers == null) {
      headers = {
        'Accept': 'application/json',
        'Content-Type': 'application/json',
      };
    } else if (dataJson.headers['Accept'] == null) {
      headers = dataJson.headers;
      headers['Accept'] = 'application/json';
    }

    var body = dataJson == null ? null : dataJson.body == null ? dataJson : dataJson.body;
    var bodyStr: string | undefined;

    if (method == null) {
      method = 'GET';
    }

    var response: Observable<any>;

    if (method == 'GET') {
      if (body != null) {
        url += '?';
        var first = true;
        for (var key in body) {
          if (!first) {
            url += '&';
          } else {
            first = false;
          }

          url += key + '=' + encodeURIComponent(body[key]);
        }

        body = null;
      }

      response = this.http.get(url, { headers, withCredentials: true });
    } else {
      response = this.http.post(url, body, { headers, withCredentials: true });
    }

    var ret: any;
    var observer = {
      next: (json: any) => {
        ret = json?.result || json;
      }
    };

    response.pipe((json: any) => json).subscribe(observer);

    observer.next(await firstValueFrom(response).catch((err: HttpErrorResponse) => {
      console.error(err.message);
      throw new Error(err.error['detail'] || err.message);
    }));

    return ret;
  }
}
