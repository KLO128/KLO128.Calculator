import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    HttpClientModule
  ],
  providers: [],
  exports: [
    CommonModule,
    FormsModule
  ]
})
export class sharedModule { }
