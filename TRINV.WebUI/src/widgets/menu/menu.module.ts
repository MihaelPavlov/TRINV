import { NgModule } from '@angular/core';
import { MenuComponent } from './menu.component';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { SharedModule } from '../../shared/shared.module';
import { AppRoutingModule } from '../../app/app.config';

@NgModule({
  declarations: [MenuComponent],
  imports: [AppRoutingModule, MatIconModule, MatTooltipModule, SharedModule],
  exports: [MenuComponent],
  providers: [],
})
export class MenuModule {}
