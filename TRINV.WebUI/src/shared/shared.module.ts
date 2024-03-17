import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { FormatNumberWithColorPipe } from './pipes/format-number-with-color.pipe';
import { FormatNumberPipe } from './pipes/round-number.pipe';

@NgModule({
  declarations: [FormatNumberPipe, FormatNumberWithColorPipe],
  imports: [CommonModule, RouterOutlet, FormsModule, ReactiveFormsModule],
  exports: [
    CommonModule,
    RouterOutlet,
    FormsModule,
    ReactiveFormsModule,
    FormatNumberPipe,
    FormatNumberWithColorPipe,
  ],
  providers: [],
})
export class SharedModule {}
