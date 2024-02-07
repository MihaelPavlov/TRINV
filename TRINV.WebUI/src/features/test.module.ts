import { BrowserModule } from '@angular/platform-browser';
import { TestComponent } from './test/test.component';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

@NgModule({
  declarations: [TestComponent],
  imports: [CommonModule, BrowserModule],
  exports: [TestComponent],
  providers: [],
})
export class TestModule {}
