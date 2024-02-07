import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { AppComponent } from './app-component/app.component';
import { AppRoutingModule } from './app.config';
import { BrowserModule } from '@angular/platform-browser';
import { TestModule } from '../features/test.module';

@NgModule({
  declarations: [AppComponent],
  imports: [AppRoutingModule, CommonModule, RouterOutlet, BrowserModule,TestModule],
  exports: [],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {
  
}
