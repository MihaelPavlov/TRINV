import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterOutlet,
    FormsModule,
  ],
  exports: [CommonModule, RouterOutlet, FormsModule],
  providers: [],
})
export class SharedModule {}
