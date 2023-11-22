import { NgModule } from '@angular/core';
import { HomeComponent } from './home.component';
import { sharedModule } from '../shared/shared.module';
import { ExpressionEntryComponent } from './expression-entry/expression-entry.component';
import { HomeViewStatePipe } from './home-view-state.pipe';
import { ResultTextPipe } from './result-text.pipe';

@NgModule({
  declarations: [
    HomeComponent,
    ExpressionEntryComponent,
    HomeViewStatePipe,
    ResultTextPipe
  ],
  imports: [
    sharedModule
  ],
  providers: [],
  exports: [HomeComponent]
})
export class HomeModule { }
