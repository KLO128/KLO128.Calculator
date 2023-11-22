import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { MenuItemComponent } from './menu-item/menu-item.component';
import { SharedService } from '../shared/shared.service';
import { IMenuItem } from './menu-item/menu-item';
import { Subject } from 'rxjs';

@Component({
  selector: 'menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css'],
  styles: [`
    :host {
        margin: 0;
      }
  `]
})
export class MenuComponent implements OnChanges {
  menuLinks: IMenuItem[];
  @Input() languageToggle = false;

  constructor(private sharedService: SharedService) {
    this.menuLinks = this.initLinks();
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.menuLinks = this.initLinks();
  }

  initLinks(): IMenuItem[] {
    return [{ title: this.sharedService.getTranslation('Home'), icon: "home", url: this.sharedService.currentLang }, { title: this.sharedService.getTranslation('About'), icon: "help", url: this.sharedService.currentLang + '/about' }];
  }

  activeUrl: string | undefined;

  onNotify(obj: IMenuItem): void {
    this.activeUrl = obj.url;
  }


}
