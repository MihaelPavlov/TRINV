import { NgModule } from '@angular/core';
import { SharedModule } from '../../../../shared/shared.module';
import { AddAccountDialogComponent } from './add-account-dialog.component';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogClose, MatDialogModule } from '@angular/material/dialog';
import { MatTooltipModule } from '@angular/material/tooltip';

@NgModule({
  declarations: [AddAccountDialogComponent],
  imports: [
    SharedModule,
    MatIconModule,
    MatDialogClose,
    MatDialogModule,
    MatTooltipModule,
  ],
  exports: [AddAccountDialogComponent],
  providers: [],
})
export class AddAccountDialogModule {}
