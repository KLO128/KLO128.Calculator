import { NgModule } from '@angular/core';
import { AboutComponent } from './about.component';
import { RouterModule } from '@angular/router';
import { sharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    AboutComponent
  ],
  imports: [
    sharedModule,
    RouterModule.forChild([
      { path: ':lang/about', component: AboutComponent }
    ])
  ],
  providers: [],
  exports: [AboutComponent]
})
export class AboutModule { }
