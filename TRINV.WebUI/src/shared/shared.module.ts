import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterOutlet,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [CommonModule, RouterOutlet, FormsModule,ReactiveFormsModule],
  providers: [],
})
export class SharedModule {}
