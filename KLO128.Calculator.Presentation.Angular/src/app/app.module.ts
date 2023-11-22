import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { HomeModule } from '../home/home.module';
import { AboutModule } from '../about/about.module';
import { HomeComponent } from '../home/home.component';
import { MenuModule } from '../menu/menu.module';
import { sharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    sharedModule,
    MenuModule,
    HomeModule,
    AboutModule,
    RouterModule.forRoot([
      { path: ':lang', component: HomeComponent },
      { path: '', component: HomeComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
