import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { AppComponent } from './app-component/app.component';
import { AppRoutingModule } from './app.config';
import { BrowserModule } from '@angular/platform-browser';
import { TestModule } from '../features/test.module';
import { FormsModule } from '@angular/forms';
import { MenuComponent } from '../pages/menu/menu.component';
import { MatIconModule } from '@angular/material/icon';
import {MatTooltipModule} from '@angular/material/tooltip';

@NgModule({
  declarations: [AppComponent,MenuComponent],
  imports: [AppRoutingModule,
     CommonModule, RouterOutlet,BrowserModule,TestModule,FormsModule,MatIconModule,MatTooltipModule],
  exports: [],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {
  
}
