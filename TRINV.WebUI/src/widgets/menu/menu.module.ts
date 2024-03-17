import { NgModule } from '@angular/core';
import { MenuComponent } from './menu.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { SharedModule } from '../../shared/shared.module';
import { AppRoutingModule } from '../../app/app.config';
import { AddAccountDialogModule } from '../../features/add-account/components/add-account-dialog.module';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  declarations: [MenuComponent],
  imports: [
    AppRoutingModule,
    MatIconModule,
    MatTooltipModule,
    SharedModule,
    AddAccountDialogModule,
  ],
  exports: [MenuComponent],
  providers: [],
})
export class MenuModule {}
