import { Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { IMenuItem } from './menu-item';
import { Subject } from 'rxjs';
import { SharedService } from '../../shared/shared.service';

@Component({
  selector: 'menu-item',
  templateUrl: './menu-item.component.html',
})
export class MenuItemComponent implements OnChanges, OnInit {

  constructor(private sharedService: SharedService) {
  }
  ngOnInit(): void {
    var currentUrl = this.sharedService.getCurrentFullPath();

    if (currentUrl.substring(1) === this.url || currentUrl.length <= 1 && !this.url?.includes('/')) {
        this.linkClassName = "nav-link active";
      } else {
        this.linkClassName = "nav-link";
      }
    }

  ngOnChanges(): void {
    if (this.urlNotifier === this.url) {
      this.linkClassName = "nav-link active";
    } else {
      this.resetLinkClassName();
    }
  }

  @Input() title: string | undefined;
  @Input() icon: string | undefined;
  @Input() url: string | undefined;

  public className = 'nav-item';
  public linkClassName = "nav-link";

  @Input() urlNotifier: string | undefined;
  @Output() notifyClick = new EventEmitter<IMenuItem>();

  onClick(): void {
    this.notifyClick.emit({ icon: this.icon!, title: this.title!, url: this.url! });
  }

  resetLinkClassName(): void {
    this.linkClassName = "nav-link";
  }
}
