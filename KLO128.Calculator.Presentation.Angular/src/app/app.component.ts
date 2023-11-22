import { Component, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { SharedService } from '../shared/shared.service';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'KLO128.Calculator';

  languageToggle = false;

  constructor(private sharedService: SharedService, private router: Router) {
    router.events.subscribe((val: any) => {
      if (val instanceof NavigationEnd) {
        this.onLanguageChange();
      }
    });
  }

  ngOnInit(): void {
    this.sharedService.initTranslations();
  }

  onLanguageChange(data?: any) {
    this.sharedService.setCurrentLang();
    this.languageToggle = !this.languageToggle;
  }
}
