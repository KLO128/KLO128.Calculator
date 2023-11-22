import { Component, EventEmitter, Output } from '@angular/core';
import { SharedService } from '../../shared/shared.service';
import { MenuItemComponent } from '../menu-item/menu-item.component';

@Component({
  selector: 'menu-lang-dropdown',
  templateUrl: './menu-lang-dropdown.component.html'
})
export class MenuLangDropdownComponent {
  constructor(public sharedService: SharedService) {

  }
}
