import { NgModule } from '@angular/core';
import { MenuComponent } from './menu.component';
import { MenuItemComponent } from './menu-item/menu-item.component';
import { MenuLangDropdownComponent } from './menu-lang-dropdown/menu-lang-dropdown.component';
import { sharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    MenuComponent,
    MenuItemComponent,
    MenuLangDropdownComponent
  ],
  imports: [
    sharedModule,
    RouterModule
  ],
  providers: [],
  exports: [MenuComponent]
})
export class MenuModule { }
