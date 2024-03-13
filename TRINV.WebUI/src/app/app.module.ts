import { NgModule } from '@angular/core';
import { AppComponent } from './app-component/app.component';
import { AppRoutingModule } from './app.config';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MenuModule } from '../widgets/menu/menu.module';
import { AppStoreModule } from './store/app-store.module';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [AppComponent],
  imports: [
    AppRoutingModule,
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    MenuModule,
    AppStoreModule
  ],
  exports: [BrowserModule, BrowserAnimationsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
